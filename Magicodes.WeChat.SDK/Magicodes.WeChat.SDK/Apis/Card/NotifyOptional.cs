using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public class NotifyOptional
    {
        /// <summary>
        /// 否   bool	true	积分变动时是否触发系统模板消息，默认为true
        /// </summary>
        [JsonProperty("is_notify_bonus")]
        public bool IsNotifyBonus { get; set; }

        /// <summary>
        ///  否 bool	true	余额变动时是否触发系统模板消息，默认为true
        /// </summary>
        [JsonProperty("is_notify_balance")]
        public bool IsNotifyBalance { get; set; }

        /// <summary>
        /// 否 bool	false	自定义group1变动时是否触发系统模板消息，默认为false。（2、3同理）
        /// </summary>
        [JsonProperty("is_notify_custom_field1")]
        public bool IsNotifyCustomField1 { get; set; }
    }
}
