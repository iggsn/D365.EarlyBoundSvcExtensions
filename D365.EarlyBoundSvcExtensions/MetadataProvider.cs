using System.Collections.Generic;
using Microsoft.Crm.Services.Utility;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// If overridden, it allows to fetch the Metadata on your own style. For example it would be possible to fetch
    /// and store the Metadata as file to generate content offline.
    /// </summary>
    public class MetadataProvider : IMetadataProviderService
    {
        public IMetadataProviderService DefaultService { get; }

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
