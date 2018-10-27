using System;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Called during the process of CodeDOM generation, assuming the default instance of ICodeGenerationService,
    /// to determine whether a specific object or property should be generated.
    /// </summary>
    public class CodeWriterFilter : ICodeWriterFilterService
    {
        private ICodeWriterFilterService DefaultService { get; }

        public CodeWriterFilter(ICodeWriterFilterService defaultService)
        {
            DefaultService = defaultService;
        }

        public bool GenerateOptionSet(OptionSetMetadataBase optionSetMetadata, IServiceProvider services)
        {
            return DefaultService.GenerateOptionSet(optionSetMetadata, services);
        }

        public bool GenerateOption(OptionMetadata optionMetadata, IServiceProvider services)
        {
            return DefaultService.GenerateOption(optionMetadata, services);
        }

        public bool GenerateEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            return DefaultService.GenerateEntity(entityMetadata, services);
        }

        public bool GenerateAttribute(AttributeMetadata attributeMetadata, IServiceProvider services)
        {
            return DefaultService.GenerateAttribute(attributeMetadata, services);
        }

        public bool GenerateRelationship(RelationshipMetadataBase relationshipMetadata, EntityMetadata otherEntityMetadata,
            IServiceProvider services)
        {
            return DefaultService.GenerateRelationship(relationshipMetadata, otherEntityMetadata, services);
        }

        public bool GenerateServiceContext(IServiceProvider services)
        {
            return DefaultService.GenerateServiceContext(services);
        }
    }
}
