using System.Collections.Generic;
using Microsoft.Crm.Services.Utility;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Called to retrieve the metadata from the server. This may be called multiple times during the
    /// generation process, so the data should be cached.
    /// </summary>
    public class MetadataProvider : IMetadataProviderService
    {
        private IMetadataProviderService DefaultService { get; }

        public MetadataProvider(IMetadataProviderService defaultService, IDictionary<string, string> parameters)
        {
            DefaultService = defaultService;
        }

        public IOrganizationMetadata LoadMetadata()
        {
            IOrganizationMetadata metadata;
            metadata = DefaultService.LoadMetadata();

            return metadata;
        }
    }
}
