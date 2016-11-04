using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.WeChat.SDK.Helper;
using System.ComponentModel.DataAnnotations;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 卡券信息
    /// </summary>
    public abstract class CardInfo
    {
        /// <summary>
        /// 卡券类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("card_type")]
        public CardTypes CardType { get; set; }
    }

    /// <summary>
    /// 卡券类型
    /// </summary>
    public enum CardTypes
    {
        /// <summary>
        /// 团购券
        /// </summary>
        GROUPON,
        /// <summary>
        /// 代金券
        /// </summary>
        CASH,
        /// <summary>
        /// 折扣券
        /// </summary>
        DISCOUNT,
        /// <summary>
        /// 兑换券
        /// </summary>
        GIFT,
        /// <summary>
        /// 优惠券
        /// </summary>
        GENERAL_COUPON

    }
    /// <summary>
    /// 团购券
    /// </summary>
    public class Groupon : CardInfo
    {
        public Groupon()
        {
            this.CardType = CardTypes.GROUPON;
        }
        public class GrouponInfo
        {
            /// <summary>
            /// 卡券基础信息
            /// </summary>
            [JsonProperty("base_info")]
            public BaseInfo BaseInfo { get; set; }

            /// <summary>
            /// 卡券高级信息
            /// </summary>
            [JsonProperty("advanced_info")]
            public AdvancedInfo AdvancedInfo { get; set; }

            [JsonProperty("deal_detail")]
            public string DealDetail { get; set; }
        }
        [JsonProperty("groupon")]
        public GrouponInfo Groupon_ { get; set; }
    }
    /// <summary>
    /// 代金券
    /// </summary>
    public class Cash : CardInfo
    {
        public Cash()
        {
            this.CardType = CardTypes.CASH;
        }
        public class CashInfo
        {
            public BaseInfo base_info { get; set; }
            public AdvancedInfo advanced_info { get; set; }
            /// <summary>
            /// 代金券专用，表示起用金额（单位为分）,如果无起用门槛则填0。
            /// </summary>
            public int least_cost { get; set; }
            /// <summary>
            /// 代金券专用，表示减免金额。（单位为分）
            /// </summary>
            public int reduce_cost { get; set; }
        }
        public CashInfo cash { get; set; }
    }

    /// <summary>
    /// 折扣券
    /// </summary>
    public class Discount : CardInfo
    {
        public Discount()
        {
            this.CardType = CardTypes.DISCOUNT;
        }
        public class DiscountInfo
        {
            public BaseInfo base_info { get; set; }
            public AdvancedInfo advanced_info { get; set; }

            public int discount { get; set; }
        }
        public DiscountInfo discount { get; set; }

    }
    /// <summary>
    /// 兑换券
    /// </summary>
    public class Gift : CardInfo
    {
        public Gift()
        {
            this.CardType = CardTypes.GIFT;
        }
        public class GiftInfo
        {
            public BaseInfo base_info { get; set; }
            public AdvancedInfo advanced_info { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string gift { get; set; }
        }

        public GiftInfo gift { get; set; }
    }
    /// <summary>
    /// 优惠券
    /// </summary>
    public class GeneralCoupon : CardInfo
    {
        public GeneralCoupon()
        {
            this.CardType = CardTypes.GENERAL_COUPON;
        }
        public class GeneralCouponInfo
        {
            public BaseInfo base_info { get; set; }
            public AdvancedInfo advanced_info { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string default_detail { get; set; }
        }
        public GeneralCouponInfo general_coupon { get; set; }
    }

    public class BaseInfo
    {
        /// <summary>
        /// 卡券的商户logo，建议像素为300*300。
        /// </summary>
        [MaxLength(128)]
        [Required]
        [JsonRequired]
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 商户名字,字数上限为12个汉字。
        /// </summary>
        [JsonProperty("brand_name")]
        [Required]
        [JsonRequired]
        public string BrandName { get; set; }

        /// <summary>
        /// 码型
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("code_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CodeTypes CodeType { get; set; }

        /// <summary>
        /// 卡券名，字数上限为9个汉字。(建议涵盖卡券属性、服务及金额)。
        /// </summary>
        [JsonProperty("title")]
        [Required]
        [JsonRequired]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sub_title")]
        public string SubTitle { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("color")]
        public string Color { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("notice")]
        public string Notice { get; set; }

        [JsonProperty("service_phone")]
        public string ServicePhone { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 使用日期，有效期的信息。
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("date_info")]
        public DateInfo DateInfo { get; set; }

        [Required]
        [JsonRequired]
        [JsonProperty("sku")]
        public Sku Sku { get; set; }

        [JsonProperty("get_limit")]
        public int GetLimit { get; set; }

        [JsonProperty("use_custom_code")]
        public bool UseCustomCode { get; set; }

        [JsonProperty("bind_openid")]
        public bool BindOpenId { get; set; }

        [JsonProperty("can_share")]
        public bool CanShare { get; set; }

        [JsonProperty("can_give_friend")]
        public bool CanGiveFriend { get; set; }

        [JsonProperty("location_id_list")]
        public int[] LocationIdList { get; set; }

        [JsonProperty("center_title")]
        public string CenterTitle { get; set; }

        [JsonProperty("center_sub_title")]
        public string CenterSubTitle { get; set; }

        [JsonProperty("center_url")]
        public string CenterUrl { get; set; }

        [JsonProperty("custom_url_name")]
        public string CustomUrlName { get; set; }

        [JsonProperty("custom_url")]
        public string CustomUrl { get; set; }

        [JsonProperty("custom_url_sub_title")]
        public string CustomUrlSubTitle { get; set; }

        [JsonProperty("promotion_url_name")]
        public string PromotionUrlName { get; set; }

        [JsonProperty("promotion_url")]
        public string PromotionUrl { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    /// <summary>
    /// 码型
    /// </summary>
    public enum CodeTypes
    {
        /// <summary>
        /// 文本
        /// </summary>
        CODE_TYPE_TEXT,
        /// <summary>
        /// 一维码
        /// </summary>
        CODE_TYPE_BARCODE,
        /// <summary>
        /// 二维码
        /// </summary>
        CODE_TYPE_QRCODE,
        /// <summary>
        /// 二维码无code显示
        /// </summary>
        CODE_TYPE_ONLY_QRCODE,
        /// <summary>
        /// 一维码无code显示
        /// </summary>
        CODE_TYPE_ONLY_BARCODE,
        /// <summary>
        /// 不显示code和条形码类型
        /// </summary>
        CODE_TYPE_NONE
    }

    /// <summary>
    /// 使用日期，有效期的信息。
    /// </summary>
    public abstract class DateInfo
    {
        /// <summary>
        /// 使用时间的类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        [Required]
        [JsonRequired]
        public DateInfoTypes Type { get; internal set; }

        

    }
    /// <summary>
    /// 表示固定日期区间
    /// </summary>
    public class FixTimeRangeDateInfo : DateInfo
    {
        public FixTimeRangeDateInfo()
        {
            this.Type = DateInfoTypes.DATE_TYPE_FIX_TIME_RANGE;
        }
        [JsonIgnore]
        public DateTime? BeginTime { get; set; }

        [JsonProperty("begin_timestamp")]
        public long? BeginTimeStamp
        {
            get
            {
                if (BeginTime == null)
                    return default(long);
                return BeginTime.Value.ConvertToTimeStamp();
            }
        }

        /// <summary>
        /// 表示结束时间，建议设置为截止日期的23:59:59过期。（东八区时间,UTC+8）
        /// </summary>
        [JsonIgnore]
        public DateTime? EndTime { get; set; }


        /// <summary>
        /// 表示结束时间，建议设置为截止日期的23:59:59过期。（东八区时间,UTC+8，单位为秒）
        /// </summary>
        [JsonProperty("end_timestamp")]
        public long? EndTimestamp
        {
            get
            {
                if (EndTime == null)
                    return default(long);
                return EndTime.Value.ConvertToTimeStamp();
            }
        }
    }
    /// <summary>
    /// 表示固定时长（自领取后按天算）
    /// </summary>
    public class FixTermDateInfo : DateInfo
    {
        public FixTermDateInfo()
        {
            this.Type = DateInfoTypes.DATE_TYPE_FIX_TERM;
        }
        /// <summary>
        /// type为DATE_TYPE_FIX_TERM时专用，表示自领取后多少天内有效，不支持填写0。
        /// </summary>
        [JsonProperty("fixed_term")]
        public int? FixedTerm { get; set; }

        /// <summary>
        /// type为DATE_TYPE_FIX_TERM时专用，表示自领取后多少天开始生效，领取后当天生效填写0。（单位为天）
        /// </summary>
        [JsonProperty("fixed_begin_term")]
        public int? FixedBeginTerm { get; set; }

        /// <summary>
        /// 可用于DATE_TYPE_FIX_TERM时间类型，表示卡券统一过期时间，建议设置为截止日期的23:59:59过期。（东八区时间,UTC+8，单位为秒），设置了fixed_term卡券，当时间达到end_timestamp时卡券统一过期
        /// </summary>
        [JsonIgnore]
        public DateTime? EndTime { get; set; }


        /// <summary>
        /// 可用于DATE_TYPE_FIX_TERM时间类型，表示卡券统一过期时间，建议设置为截止日期的23:59:59过期。（东八区时间,UTC+8，单位为秒），设置了fixed_term卡券，当时间达到end_timestamp时卡券统一过期
        /// </summary>
        [JsonProperty("end_timestamp")]
        public long? EndTimestamp
        {
            get
            {
                if (EndTime == null)
                    return default(long);
                return EndTime.Value.ConvertToTimeStamp();
            }
        }
    }

    /// <summary>
    /// 使用时间的类型
    /// </summary>
    public enum DateInfoTypes
    {
        /// <summary>
        /// 表示固定日期区间
        /// </summary>
        DATE_TYPE_FIX_TIME_RANGE = 1,
        /// <summary>
        /// 表示固定时长（自领取后按天算。）
        /// </summary>
        DATE_TYPE_FIX_TERM = 2
    }

    public class Sku
    {
        [Required]
        [JsonRequired]
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    public class AdvancedInfo
    {
        [JsonProperty("use_condition")]
        public UseCondition UseCondition { get; set; }


        [JsonProperty("abstract")]
        public Abstract Abstract { get; set; }

        [JsonProperty("text_image_list")]
        public TextImageList[] TextImageList { get; set; }

        [JsonProperty("time_limit")]
        public TimeLimit[] TimeLimit { get; set; }

        [JsonProperty("business_service")]
        public string[] BusinessService { get; set; }
    }

    public class UseCondition
    {
        [JsonProperty("accept_category")]
        public string AcceptCategory { get; set; }

        [JsonProperty("reject_category")]
        public string RejectCategory { get; set; }

        [JsonProperty("can_use_with_other_discount")]
        public bool CanUseWithOtherDiscount { get; set; }
    }

    public class Abstract
    {
        /// <summary>
        /// 封面摘要简介。
        /// </summary>
        [JsonProperty("abstract")]
        public string AbstractInfo { get; set; }

        [JsonProperty("icon_url_list")]
        public string[] IconUrlList { get; set; }
    }

    public class TextImageList
    {
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// 使用时段限制
    /// </summary>
    public class TimeLimit
    {
        /// <summary>
        /// 限制类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public TimeLimitTypes Type { get; set; }

        [JsonProperty("begin_hour")]
        public int BeginHour { get; set; }

        [JsonProperty("end_hour")]
        public int EndHour { get; set; }

        [JsonProperty("begin_minute")]
        public int BeginMinute { get; set; }

        [JsonProperty("end_minute")]
        public int EndMinute { get; set; }
    }

    public enum TimeLimitTypes
    {
        /// <summary>
        ///  周一
        /// </summary>
        MONDAY,
        /// <summary>
        /// 周二
        /// </summary>
        TUESDAY,
        /// <summary>
        /// 周三
        /// </summary>
        WEDNESDAY,
        /// <summary>
        /// 周四
        /// </summary>
        THURSDAY,
        /// <summary>
        /// 周五
        /// </summary>
        FRIDAY,
        /// <summary>
        /// 周六
        /// </summary>
        SATURDAY,
        /// <summary>
        /// 周日
        /// </summary>
        SUNDAY,
        /// <summary>
        /// 节假日
        /// </summary>
        HOLIDAY
    }
}
