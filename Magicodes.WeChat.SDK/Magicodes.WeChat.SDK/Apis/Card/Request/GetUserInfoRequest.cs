using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    public class GetUserInfoRequest
    {
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
