using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Message.Result
{
    public class MessageApiResult : ApiResult
    {
        [JsonProperty("msg_id")]
        public string MessageId { get; set; }

        [JsonProperty("msg_data_id")]
        public string MessageDataId { get; set; }
    }
}
