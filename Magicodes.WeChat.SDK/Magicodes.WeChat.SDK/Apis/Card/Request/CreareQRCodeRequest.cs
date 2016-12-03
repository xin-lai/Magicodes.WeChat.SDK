using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    /// <summary>
    /// 创建卡券二维码请求实体
    /// </summary>
    public class CreareQRCodeRequest
    {
        /// <summary>
        /// QR_CARD(扫描二维码领取单张卡券);QR_MULTIPLE_CARD(扫描二维码领取多张卡券使用)
        /// </summary>
        [JsonProperty("action_name")]
        public string ActionName { get; set; }

        /// <summary>
        /// 指定二维码的有效时间，范围是60 ~ 1800秒。不填默认为365天有效
        /// </summary>
        [JsonProperty("expire_seconds")]
        public int ExpireSeconds { get; set; }


        [JsonProperty("action_info")]
        public ActionInfo ActionInfo { get; set; }
    }

    /// <summary>
    /// 当ActionName 设置为“QR_CARD”实例化“CardInfo”，设置为“QR_MULTIPLE_CARD”，实例化“MultipleCard”
    /// </summary>
    public class ActionInfo
    {
        /// <summary>
        /// 开发者可以设置扫描二维码领取单张卡券，
        /// </summary>
        [JsonProperty("card")]
        public QRCardInfo CardInfo { get; set; }

        /// <summary>
        /// 当开发者设置扫描二维码领取多张卡券使用
        /// </summary>
        [JsonProperty("multiple_card")]
        public MultipleCard MultipleCard { get; set; }
    }

    public class MultipleCard
    {
        [JsonProperty("card_list")]
        public List<QRCardInfo> Cardlist { get; set; }
    }

    public class QRCardInfo
    {
        /// <summary>
        /// 卡券Code码,use_custom_code字段为true的卡券必须填写，非自定义code和导入code模式的卡券不必填写。
        /// </summary>
        [JsonProperty("code")]
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// 卡券ID。
        /// </summary>
        [MaxLength(32)]
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        /// <summary>
        /// 指定领取者的openid，只有该用户能领取。bind_openid字段为true的卡券必须填写，非指定openid不必填写。
        /// </summary>
        [JsonProperty("openid")]
        [MaxLength(32)]
        public string Openid { get; set; }


        /// <summary>
        /// 指定下发二维码，生成的二维码随机分配一个code，领取后不可再次扫描。填写true或false。默认false，注意填写该字段时，卡券须通过审核且库存不为0。
        /// </summary>
        [JsonProperty("is_unique_code")]
        public bool IsUniqueCode { get; set; }

        /// <summary>
        /// 领取场景值，用于领取渠道的数据统计，默认值为0，字段类型为整型，长度限制为60位数字。用户领取卡券后触发的事件推送中会带上此自定义场景值。
        /// </summary>
        [JsonProperty("outer_id")]
        public int Outer_id { get; set; }

        /// <summary>
        /// 对于会员卡的二维码，用户每次扫码打开会员卡后点击任何url，会将该值拼入url中，方便开发者定位扫码来源
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("outer_str")]
        public string Outer_str { get; set; }
    }
}
