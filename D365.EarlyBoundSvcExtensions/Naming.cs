using System;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Called during the CodeDOM generation to determine the name for objects,
    /// assuming the default implementation.
    /// </summary>
    public class Naming : INamingService
    {
        private INamingService DefaultService { get; }

        public Naming(INamingService defaulService)
        {
            DefaultService = defaulService;
        }

        public string GetNameForOptionSet(EntityMetadata entityMetadata, OptionSetMetadataBase optionSetMetadata,
            IServiceProvider services)
        {
            return DefaultService.GetNameForOptionSet(entityMetadata, optionSetMetadata, services);
        }

        public string GetNameForOption(OptionSetMetadataBase optionSetMetadata, OptionMetadata optionMetadata,
            IServiceProvider services)
        {
            return DefaultService.GetNameForOption(optionSetMetadata, optionMetadata, services);
        }

        public string GetNameForEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            return DefaultService.GetNameForEntity(entityMetadata, services);
        }

        public string GetNameForAttribute(EntityMetadata entityMetadata, AttributeMetadata attributeMetadata,
            IServiceProvider services)
        {
            return DefaultService.GetNameForAttribute(entityMetadata, attributeMetadata, services);
        }

        public string GetNameForRelationship(EntityMetadata entityMetadata, RelationshipMetadataBase relationshipMetadata,
            EntityRole? reflexiveRole, IServiceProvider services)
        {
            return DefaultService.GetNameForRelationship(entityMetadata, relationshipMetadata, reflexiveRole, services);
        }

        public string GetNameForServiceContext(IServiceProvider services)
        {
            return DefaultService.GetNameForServiceContext(services);
        }

        public string GetNameForEntitySet(EntityMetadata entityMetadata, IServiceProvider services)
        {
            return DefaultService.GetNameForEntitySet(entityMetadata, services);
        }

        public string GetNameForMessagePair(SdkMessagePair messagePair, IServiceProvider services)
        {
            return DefaultService.GetNameForMessagePair(messagePair, services);
        }

        public string GetNameForRequestField(SdkMessageRequest request, SdkMessageRequestField requestField,
            IServiceProvider services)
        {
            return DefaultService.GetNameForRequestField(request, requestField, services);
        }

        public string GetNameForResponseField(SdkMessageResponse response, SdkMessageResponseField responseField,
            IServiceProvider services)
        {
            return DefaultService.GetNameForResponseField(response, responseField, services);
        }
    }
}
