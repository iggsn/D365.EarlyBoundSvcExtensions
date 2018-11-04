using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Services.Utility;
using Microsoft.Xrm.Sdk.Metadata;

namespace D365.EarlyBoundSvcExtensions.Data
{
    public class Metadata : IOrganizationMetadata, IExtensibleDataObject
    {
        [DataMember]
        public EntityMetadata[] Entities { get; set; }

        [DataMember]
        public OptionSetMetadataBase[] OptionSets { get; set; }

        [DataMember]
        public SdkMessages Messages { get; set;  }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}
