using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Shorturl.Result
{
    public class ShortUrlApiResult : ApiResult
    {
        /// <summary>
        ///     短链接
        /// </summary>
        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }
}