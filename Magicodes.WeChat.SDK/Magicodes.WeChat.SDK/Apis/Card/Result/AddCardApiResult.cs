using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    /// <summary>
    /// 卡券添加结果
    /// </summary>
    public class AddCardApiResult : ApiResult
    {
        /// <summary>
        /// 卡券ID
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }
    }
}
