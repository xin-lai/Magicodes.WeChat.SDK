using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public class CommonField
    {
        [JsonProperty("name")]
        public CommonFieldTypes FieldName { get; set; }

        [JsonProperty("value")]
        public string FieldValue { get; set; }
    }
}
