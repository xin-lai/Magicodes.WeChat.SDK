using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Sns.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class GetSnsInfoByCodeOutput : ApiOutput
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 会话密钥
        /// </summary>
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        /// <summary>
        /// 用户在开放平台的唯一标识符。本字段在满足一定条件的情况下才返回。具体参看：https://mp.weixin.qq.com/debug/wxadoc/dev/api/uinionID.html
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}
