using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    /// <summary>
    /// 获取真实code
    /// </summary>
    public class DecrCodeApiResult : ApiResult
    {
        /// <summary>
        ///  解密后的卡券CODE
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
