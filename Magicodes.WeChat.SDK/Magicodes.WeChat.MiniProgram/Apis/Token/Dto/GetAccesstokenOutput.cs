using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Token.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAccesstokenOutput : ApiOutput, IAccesstokenInfo
    {
        /// <summary>
        /// access_token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        public int Expires { get; set; }

        /// <summary>
        /// 凭证过期时间
        /// </summary>
        public DateTime ExpiresTime { get; set; }
    }
}
