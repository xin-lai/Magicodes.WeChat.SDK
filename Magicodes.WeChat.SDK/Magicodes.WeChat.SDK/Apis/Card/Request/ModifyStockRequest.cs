using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    public class ModifyStockRequest
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 增加多少库存，支持不填或填0。
        /// </summary>
        [JsonProperty("increase_stock_value")]
        public int IncreaseStockValue { get; set; }

        /// <summary>
        /// 减少多少库存，可以不填或填0。
        /// </summary>
        [JsonProperty("reduce_stock_value")]
        public int ReduceStockValue { get; set; }
    }
}
