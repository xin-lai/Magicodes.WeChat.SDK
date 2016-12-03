using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    /// <summary>
    ///  普通一键激活
    /// </summary>
    public class ActivateMemberUserformRequest
    {

        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 会员守则信息
        /// </summary>
        [JsonProperty("service_statement")]
        public NameUrls ServiceStatement { get; set; }

        /// <summary>
        /// 绑定老会员
        /// </summary>
        [JsonProperty("bind_old_card")]
        public NameUrls BindOldCard { get; set; }

        /// <summary>
        /// 会员卡激活时的必填选项。
        /// </summary>
        [JsonProperty("required_form")]
        public RequiredForm Requiredform { get; set; }

        /// <summary>
        /// 会员卡激活时的选填项。   
        /// </summary>
        [JsonProperty("optional_form")]
        public OptionalForm Optionalform { get; set; }
    }
}
