using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.WeChat.MiniProgram.Apis.Profile.Dto
{
    public class GetPhoneNumberOutput
    {
        /// <summary>
        /// 用户绑定的手机号（国外手机号会有区号）
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 没有区号的手机号
        /// </summary>
        [JsonProperty("purePhoneNumber")]
        public string PurePhoneNumber { get; set; }

        /// <summary>
        /// 区号
        /// </summary>
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 数据水印
        /// </summary>
        [JsonProperty("watermark")]
        public WatermarkInfo Watermark { get; set; }
    }

    public class WatermarkInfo
    {
        /// <summary>
        /// 敏感数据归属appid，开发者可校验此参数与自身appid是否一致
        /// </summary>
        [JsonProperty("appid")]
        public string Appid { get; set; }

        /// <summary>
        /// 敏感数据获取的时间戳, 开发者可以用于数据时效性校验
        /// </summary>
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
    }
}
