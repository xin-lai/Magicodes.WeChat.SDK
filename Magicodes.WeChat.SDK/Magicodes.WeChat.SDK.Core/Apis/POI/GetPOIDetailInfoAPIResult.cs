using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    /// <summary>
    ///     POI详细信息API结果
    /// </summary>
    public class GetPOIDetailInfoAPIResult : ApiResult
    {
        /// <summary>
        ///     门店信息
        /// </summary>
        [JsonProperty("business")]
        public BusinessInfo Business { get; set; }
    }
}