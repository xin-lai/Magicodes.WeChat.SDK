using Newtonsoft.Json;

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