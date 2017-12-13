using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Material
{
    /// <summary>
    /// 图片上传结果
    /// </summary>
    public class UploadImageApiResult : ApiResult
    {
        /// <summary>
        /// 上传图片的URL，可放置图文消息中、门店中使用
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}