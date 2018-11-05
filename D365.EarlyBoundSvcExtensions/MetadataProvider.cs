using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using D365.EarlyBoundSvcExtensions.Core;
using D365.EarlyBoundSvcExtensions.Data;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Called to retrieve the metadata from the server. This may be called multiple times during the
    /// generation process, so the data should be cached.
    /// </summary>
    public class MetadataProvider : IMetadataProviderService
    {
        private IOrganizationMetadata Metadata { get; set; }

        private IMetadataProviderService DefaultService { get; }

        private IOrganizationService OrganizationService { get; }

        private string _serverTimeStamp;

        private string ServerTimStamp => _serverTimeStamp ?? (_serverTimeStamp = RetrieveServerTimeStamp());

        public string FilePath;

        public bool SerializeMetadata;

        public bool ReadSerializedMetadata;

        public MetadataProvider(IMetadataProviderService defaultService, IDictionary<string, string> parameters)
        {
            DefaultService = defaultService;

            OrganizationService = GetOrganizationService(parameters);

            SerializeMetadata = true;
            ReadSerializedMetadata = true;
            FilePath = "metadata.json";
        }

        public IOrganizationMetadata LoadMetadata()
        {
            return Metadata ?? (Metadata = LoadMetadataInternal());
        }

        #region private
        private IOrganizationService GetOrganizationService(IDictionary<string, string> parameters)
        {
            var connectionString = $"AuthType = Office365; Url={parameters["url"]};Username={parameters["username"]};Password={parameters["password"]}";
            CrmServiceClient connection = new CrmServiceClient(connectionString);
            IOrganizationService organizationService = connection.OrganizationWebProxyClient != null
                ? (IOrganizationService)connection.OrganizationWebProxyClient
                : connection.OrganizationServiceProxy;

            return organizationService;
        }

        private string RetrieveServerTimeStamp()
        {
            RetrieveTimestampRequest timestampRequest = new RetrieveTimestampRequest();

            var timestampResponse = (RetrieveTimestampResponse)OrganizationService.Execute(timestampRequest);
            return timestampResponse.Timestamp;
        }

        private IOrganizationMetadata LoadMetadataInternal()
        {
            IOrganizationMetadata metadata;

            if (!ReadSerializedMetadata && !File.Exists(RootPath(FilePath)))
            {
                metadata = DefaultService.LoadMetadata();

                if (SerializeMetadata)
                {
                    SerializeMetadataToFile(metadata, FilePath);
                }
            }
            else
            {
                metadata = DeserializeMetadata(FilePath);
            }

            return metadata;
        }

        private static void SerializeMetadataToFile(IOrganizationMetadata metadata, string filePath)
        {
            var localMetadata = new Metadata
            {
                Entities = metadata.Entities,
                OptionSets = metadata.OptionSets,
                Messages = metadata.Messages
            };

            filePath = RootPath(filePath);
            var serialized = Serializer.SerializeJsonDc(localMetadata);
            File.WriteAllText(filePath, serialized);
        }

        private static IOrganizationMetadata DeserializeMetadata(string filePath)
        {
            filePath = RootPath(filePath);
            string fileContent = File.ReadAllText(filePath);
            MemoryStream metadataJson = new MemoryStream(Encoding.UTF8.GetBytes(fileContent));
            return Serializer.DeserializeJsonDc<Metadata>(metadataJson);
        }

        private static string RootPath(string filePath)
        {
            if (!Path.IsPathRooted(filePath))
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }
            return filePath;
        }
        #endregion 
    }
}
