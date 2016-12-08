using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class CardDetailResult : ApiResult
    {
        /// <summary>
        /// 卡券信息
        /// </summary>
        [JsonProperty("card")]
        public dynamic Card { get; set; }
    }
}
