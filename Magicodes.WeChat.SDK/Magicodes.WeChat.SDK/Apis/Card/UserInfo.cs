using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 会员信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 微信标准信息 
        /// </summary>
        [JsonProperty("common_field_list")]
        public CommonField[] CommonFieldList { get; set; }


        /// <summary>
        /// 开发者设置的会员卡会员信息类目，如等级。 
        /// </summary>
        [JsonProperty("custom_field_list")]
        public CustomField[] CustomFieldList { get; set; }
    }
}
