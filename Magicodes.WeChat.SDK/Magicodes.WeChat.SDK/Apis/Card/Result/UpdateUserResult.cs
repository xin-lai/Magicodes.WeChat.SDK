using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class UpdateUserResult : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result_bonus")]
        public int ResultBonus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result_balance")]
        public int ResultBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("openid")]
        public string Openid { get; set; }
    }
}
