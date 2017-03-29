using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class POIPhotoInfo
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonProperty("photo_url")]
        public string PhotoUrl { get; set; }
    }
}