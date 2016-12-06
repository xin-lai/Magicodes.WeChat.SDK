using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    /// <summary>
    /// 查询卡卷状态返回数据实体
    /// </summary>
    public class CodeStatusResult : ApiResult
    {
        /// <summary>
        /// 用户openid
        /// </summary>
        [JsonProperty("openid")]
        public string Openid { get; set; }

        /// <summary>
        /// 是否可以核销，true为可以核销，false为不可核销
        /// </summary>
        [JsonProperty("can_consume")]
        public bool CanConsume { get; set; }

        /// <summary>
        /// 当前code对应卡券的状态,code未被添加或被转赠领取的情况则统一报错：invalid serial code
        /// </summary>
        [JsonProperty("user_card_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserCardStatus UserCardStatus { get; set; }

        /// <summary>
        /// 会员卡信息
        /// </summary>
        [JsonProperty("card")]
        public CardInfo Card { get; set; }
    }
    public class CardInfo
    {
        /// <summary>
        /// 卡券ID
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 起始使用时间
        /// </summary>
        [JsonProperty("begin_time")]
        public long BeginTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [JsonProperty("end_time")]
        public long EndTime { get; set; }
    }
    /// <summary>
    /// 核销卡卷返回数据实体
    /// </summary>
    public class ConsumeCardResult : ApiResult
    {
        /// <summary>
        /// 卡卷ID
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        /// <summary>
        /// 用户在该公众号内的唯一身份标识。
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }
    }

}
