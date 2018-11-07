using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<string> EntityPrefixToSkip { get; set; }

        public HashSet<string> EntitiesToGenerate { get; set; }


        private ICodeWriterFilterService DefaultService { get; }

        public CodeWriterFilter(ICodeWriterFilterService defaultService)
        {
            DefaultService = defaultService;
            EntityPrefixToSkip = new List<string> { "msdyn_", "pvs_", "ball_", "adx_" };
            EntitiesToGenerate = new HashSet<string> { "account", "contact", "crmp_sap_accountdetail" };
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
            if (!DefaultService.GenerateEntity(entityMetadata, services))
            {
                return false;
            }

            if (EntitiesToGenerate.Any())
            {
                return EntitiesToGenerate.Contains(entityMetadata.LogicalName);
            }

            return !EntityPrefixToSkip.Any(prefix => entityMetadata.LogicalName.StartsWith(prefix));
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
