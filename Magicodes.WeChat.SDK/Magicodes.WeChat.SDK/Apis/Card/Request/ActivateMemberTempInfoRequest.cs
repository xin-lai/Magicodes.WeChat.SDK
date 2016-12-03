using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    public class ActivateMemberTempInfoRequest
    {
        /// <summary>
        /// 激活凭证
        /// </summary>
        [JsonProperty("activate_ticket")]
        public string ActivateTicket { get; set; }
    }
}
