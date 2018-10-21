using System;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions
{
    public class Naming : INamingService
    {
        public string GetNameForOptionSet(EntityMetadata entityMetadata, OptionSetMetadataBase optionSetMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForOption(OptionSetMetadataBase optionSetMetadata, OptionMetadata optionMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForAttribute(EntityMetadata entityMetadata, AttributeMetadata attributeMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForRelationship(EntityMetadata entityMetadata, RelationshipMetadataBase relationshipMetadata,
            EntityRole? reflexiveRole, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForServiceContext(IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForEntitySet(EntityMetadata entityMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForMessagePair(SdkMessagePair messagePair, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForRequestField(SdkMessageRequest request, SdkMessageRequestField requestField,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public string GetNameForResponseField(SdkMessageResponse response, SdkMessageResponseField responseField,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}
