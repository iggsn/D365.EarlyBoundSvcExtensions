using System.Collections.Generic;
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

        public MetadataProvider(IMetadataProviderService defaultService, IDictionary<string, string> parameters)
        {
            DefaultService = defaultService;

            OrganizationService = GetOrganizationService(parameters);
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

            if ( /*config to be from file && file exist*/ false)
            {
                // try to read Metadata from file to get client timestamp
                // if client timestamp get server timestamp to verify correctness
                // otherwise load internal
            }
            else
            {
                metadata = DefaultService.LoadMetadata();

            }

            // if to be serialized --> serialize
            
            return metadata;
        }
        #endregion 
    }
}
