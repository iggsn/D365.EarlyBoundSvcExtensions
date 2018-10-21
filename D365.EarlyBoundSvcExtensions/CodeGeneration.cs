using System;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions
{
    public class CodeGeneration : ICodeGenerationService
    {
        public void Write(IOrganizationMetadata organizationMetadata, string language, string outputFile, string targetNamespace,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForOptionSet(EntityMetadata entityMetadata, OptionSetMetadataBase optionSetMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForOption(OptionSetMetadataBase optionSetMetadata, OptionMetadata optionMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForEntity(EntityMetadata entityMetadata, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForAttribute(EntityMetadata entityMetadata, AttributeMetadata attributeMetadata,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForMessagePair(SdkMessagePair messagePair, IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForRequestField(SdkMessageRequest request, SdkMessageRequestField requestField,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }

        public CodeGenerationType GetTypeForResponseField(SdkMessageResponse response, SdkMessageResponseField responseField,
            IServiceProvider services)
        {
            throw new NotImplementedException();
        }
    }
}
