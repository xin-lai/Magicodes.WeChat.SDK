using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class AddPayGiftMemberRequest
    {
        /// <summary>
        /// 卡券ID，仅支持非自定义code模式的card_id和预存code模式的card_id，
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 模板消息跳转的url，可以是商户自定义的领卡网页链接。   
        /// </summary>
        [JsonProperty("card_id")]
        public string JumpUrl { get; set; }

        /// <summary>
        /// 支持赠券规则的商户号列表            
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("mchid_list")]
        public List<string> MchidList { get; set; }
        /// <summary>
        /// 规则生效时间
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("begin_time")]
        public long BeginTime { get; set; }

        /// <summary>
        /// 规则结束时间
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        /// <summary>
        /// 本次规则生效支付金额下限，以分为单位  
        /// </summary>
        [JsonRequired]
        [JsonProperty("min_cost")]
        public long MinCost { get; set; }

        /// <summary>
        /// 本次规则生效支付金额上限，以分为单位
        /// </summary>
        [JsonRequired]
        [JsonProperty("Max_cost")]
        public long MaxCost { get; set; }
        /// <summary>
        /// 是否允许其他appid设置本规则内已经设置过的商户号，默认为true
        /// </summary>
        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }
    }
}
