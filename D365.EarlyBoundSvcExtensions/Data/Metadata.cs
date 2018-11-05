using System.Runtime.Serialization;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions.Data
{
    [DataContract(Namespace = "http://D365.EarlyBoundSvcExtensions.Data")]
    public class Metadata : IOrganizationMetadata, IExtensibleDataObject
    {
        [DataMember]
        public EntityMetadata[] Entities { get; set; }

        [DataMember]
        public OptionSetMetadataBase[] OptionSets { get; set; }

        private SdkMessages _messages;

        public SdkMessages Messages
        {
            get => _messages ?? (_messages = MetadataMessages);
            set
            {
                _messages = value;
                MetadataMessages = new MetadataMessages(value);
            }
        }

        [DataMember]
        public MetadataMessages MetadataMessages { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}
