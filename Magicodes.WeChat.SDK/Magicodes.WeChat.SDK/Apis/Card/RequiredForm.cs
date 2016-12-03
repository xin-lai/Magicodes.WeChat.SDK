using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public class RequiredForm
    {
        /// <summary>
        /// 当前结构（required_form或者optional_form ）内的字段是否允许用户激活后再次修改，商户设置为true时，需要接收相应事件通知处理修改事件
        /// </summary>
        [JsonProperty("can_modify")]
        public bool CanModify { get; set; }

        /// <summary>
        /// 自定义富文本类型
        /// </summary>
        [JsonProperty("rich_field_list")]
        public RichField[] RichFieldList { get; set; }

        /// <summary>
        /// 微信格式化的选项类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("common_field_id_list")]
        public CommonFieldTypes[] CommonFieldidList { get; set; }
    }
}
