using System;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Token
{
    public class TokenApiResult: ApiResult
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// 凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        internal int Expires { get; set; }
        /// <summary>
        /// 凭证过期时间
        /// </summary>
        public DateTime ExporesTime { get; set; }
    }
}