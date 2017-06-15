using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class UploadImageApiResult : ApiResult
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}