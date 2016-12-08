using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class GetBatchCardListResult :ApiResult
    {
        /// <summary>
        /// 卡券ID列表。
        /// </summary>
        [JsonProperty("card_id_list")]
        public List<string> CardIdList { get; set; }

        /// <summary>
        /// 该商户名下卡券ID总数。
        /// </summary>
        [JsonProperty("total_num")]
        public int TotalNum { get; set; }
    }
}
