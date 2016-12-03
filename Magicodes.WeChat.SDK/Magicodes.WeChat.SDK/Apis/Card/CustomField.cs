using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 自定义字段
    /// </summary>
    public class CustomField
    {
        [MaxLength(24)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("name_type")]
        public NameTypes NameType { get; set; }

        [MaxLength(128)]
        [JsonProperty("url")]

        public string Url { get; set; }
    }
}
