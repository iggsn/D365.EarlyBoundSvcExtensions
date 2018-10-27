using System;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions
{
    /// <summary>
    /// Core implementation of the CodeDOM generation. If this is changed, the other extensions may not behave in the
    /// manner described.
    /// </summary>
    public class CodeGeneration : ICodeGenerationService
    {
        private ICodeGenerationService DefaultService { get; }

        public CodeGeneration(ICodeGenerationService service)
        {
            DefaultService = service;
        }

        public void Write(IOrganizationMetadata organizationMetadata, string language, string outputFile, string targetNamespace,
            IServiceProvider services)
        {
            DefaultService.Write(organizationMetadata, language, outputFile, targetNamespace, services);
        }

        public CodeGenerationType GetTypeForOptionSet(EntityMetadata entityMetadata, OptionSetMetadataBase optionSetMetadata,
            IServiceProvider services)
        {
            return DefaultService.GetTypeForOptionSet(entityMetadata, optionSetMetadata, services);
        }

        public CodeGenerationType GetTypeForOption(OptionSetMetadataBase optionSetMetadata, OptionMetadata optionMetadata,
            IServiceProvider services)
        {
            return DefaultService.GetTypeForOption(optionSetMetadata, optionMetadata, services);
        }

        public CodeGenerationType GetTypeForEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            return DefaultService.GetTypeForEntity(entityMetadata, services);
        }

        public CodeGenerationType GetTypeForAttribute(EntityMetadata entityMetadata, AttributeMetadata attributeMetadata,
            IServiceProvider services)
        {
            return DefaultService.GetTypeForAttribute(entityMetadata, attributeMetadata, services);
        }

        public CodeGenerationType GetTypeForMessagePair(SdkMessagePair messagePair, IServiceProvider services)
        {
            return DefaultService.GetTypeForMessagePair(messagePair, services);
        }

        public CodeGenerationType GetTypeForRequestField(SdkMessageRequest request, SdkMessageRequestField requestField,
            IServiceProvider services)
        {
            return DefaultService.GetTypeForRequestField(request, requestField, services);
        }

        public CodeGenerationType GetTypeForResponseField(SdkMessageResponse response, SdkMessageResponseField responseField,
            IServiceProvider services)
        {
            return DefaultService.GetTypeForResponseField(response, responseField, services);
        }
    }
}
