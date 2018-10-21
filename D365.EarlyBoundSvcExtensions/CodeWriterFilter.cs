using System;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions
{
    public class CodeWriterFilter : ICodeWriterFilterService
    {
        public bool GenerateOptionSet(OptionSetMetadataBase optionSetMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public bool GenerateOption(OptionMetadata optionMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public bool GenerateEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public bool GenerateAttribute(AttributeMetadata attributeMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public bool GenerateRelationship(RelationshipMetadataBase relationshipMetadata, EntityMetadata otherEntityMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public bool GenerateServiceContext(IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}
