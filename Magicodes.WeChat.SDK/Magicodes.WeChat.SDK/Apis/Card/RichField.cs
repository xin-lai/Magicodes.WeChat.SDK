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
    public class RichField
    {
        /// <summary>
        /// FORM_FIELD_RADIO：自定义单选；FORM_FIELD_SELECT：自定义选择项；FORM_FIELD_CHECK_BOX：自定义多选
        /// </summary>
        [MaxLength(32)]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public RichFieldTypes EditType { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [MaxLength(32)]
        [JsonProperty("name")]
        public string EditName { get; set; }

        /// <summary>
        /// 选择项
        /// </summary>
        [JsonProperty("values")]
        public string[] EditValues { get; set; }
    }
}
