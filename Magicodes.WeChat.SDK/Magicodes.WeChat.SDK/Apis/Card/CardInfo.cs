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
    public class CardInfo
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
        [Display(Name = "团购券")]
        GROUPON,
        /// <summary>
        /// 代金券
        /// </summary>
        [Display(Name = "代金券")]
        CASH,
        /// <summary>
        /// 折扣券
        /// </summary>
        [Display(Name = "折扣券")]
        DISCOUNT,
        /// <summary>
        /// 兑换券
        /// </summary>
        [Display(Name = "兑换券")]
        GIFT,
        /// <summary>
        /// 优惠券
        /// </summary>
        [Display(Name = "优惠券")]
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
        [Display(Name = "文本")]
        CODE_TYPE_TEXT,
        /// <summary>
        /// 一维码
        /// </summary>
        [Display(Name = "一维码")]
        CODE_TYPE_BARCODE,
        /// <summary>
        /// 二维码
        /// </summary>
        [Display(Name = "二维码")]
        CODE_TYPE_QRCODE,
        /// <summary>
        /// 二维码无code显示
        /// </summary>
        [Display(Name = "二维码无code显示")]
        CODE_TYPE_ONLY_QRCODE,
        /// <summary>
        /// 一维码无code显示
        /// </summary>
        [Display(Name = "一维码无code显示")]
        CODE_TYPE_ONLY_BARCODE,
        /// <summary>
        /// 不显示code和条形码类型
        /// </summary>
        [Display(Name = "不显示code和条形码类型")]
        CODE_TYPE_NONE
    }

    /// <summary>
    /// 使用日期，有效期的信息。
    /// </summary>
    public class DateInfo
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
        [JsonProperty("begin_time")]
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
        [JsonProperty("end_time")]
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
        [JsonProperty("end_time")]
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
        [Display(Name = "固定日期空间")]
        DATE_TYPE_FIX_TIME_RANGE = 1,
        /// <summary>
        /// 表示固定时长（自领取后按天算。）
        /// </summary>
        [Display(Name = "自领取后固定天数")]
        DATE_TYPE_FIX_TERM = 2
    }

    /// <summary>
    /// 商品信息
    /// </summary>
    public class Sku
    {
        /// <summary>
        /// 卡券库存的数量，上限为100000000
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }

    /// <summary>
    /// 优惠券特有的高级字段
    /// </summary>
    public class AdvancedInfo
    {
        /// <summary>
        /// 使用门槛（条件）字段，若不填写使用条件则在券面拼写：无最低消费限制，全场通用，不限品类；并在使用说明显示：可与其他优惠共享
        /// </summary>
        [JsonProperty("use_condition")]
        public UseCondition UseCondition { get; set; }

        /// <summary>
        /// 封面摘要
        /// </summary>
        [JsonProperty("abstract")]
        public Abstract Abstract { get; set; }

        /// <summary>
        /// 图文列表，显示在详情内页，优惠券券开发者须至少传入一组图文列表
        /// </summary>
        [JsonProperty("text_image_list")]
        public TextImageList[] TextImageList { get; set; }

        /// <summary>
        /// 使用时段限制
        /// </summary>
        [JsonProperty("time_limit")]
        public TimeLimit[] TimeLimit { get; set; }

        /// <summary>
        /// 商家服务类型：        
        ///     BIZ_SERVICE_DELIVER 外卖服务；
        ///     BIZ_SERVICE_FREE_PARK 停车位；
        ///     BIZ_SERVICE_WITH_PET 可带宠物；
        ///     BIZ_SERVICE_FREE_WIFI 免费wifi
        /// ，可多选
        /// </summary>
        [JsonProperty("business_service")]
        public string[] BusinessService { get; set; }
    }

    /// <summary>
    /// 使用门槛（条件）字段，若不填写使用条件则在券面拼写：无最低消费限制，全场通用，不限品类；并在使用说明显示：可与其他优惠共享
    /// </summary>
    public class UseCondition
    {
        /// <summary>
        /// 指定可用的商品类目，仅用于代金券类型，填入后将在券面拼写适用于xxx
        /// </summary>
        [JsonProperty("accept_category")]
        public string AcceptCategory { get; set; }

        /// <summary>
        /// 指定不可用的商品类目，仅用于代金券类型，填入后将在券面拼写不适用于xxxx
        /// </summary>
        [JsonProperty("reject_category")]
        public string RejectCategory { get; set; }

        /// <summary>
        /// 满减门槛字段，可用于兑换券和代金券，填入后将在全面拼写消费满xx元可用。
        /// </summary>
        [JsonProperty("least_cost")]
        public int LeastCost { get; set; }

        /// <summary>
        /// 购买xx可用类型门槛，仅用于兑换，填入后自动拼写购买xxx可用。
        /// </summary>
        [JsonProperty("object_use_for")]
        public string ObjectUseFor { get; set; }

        /// <summary>
        /// 不可以与其他类型共享门槛，填写false时系统将在使用须知里拼写“不可与其他优惠共享”，填写true时系统将在使用须知里拼写“可与其他优惠共享”，默认为true
        /// </summary>
        [JsonProperty("can_use_with_other_discount")]
        public bool CanUseWithOtherDiscount { get; set; }
    }

    /// <summary>
    /// 封面摘要
    /// </summary>
    public class Abstract
    {
        /// <summary>
        /// 封面摘要简介。
        /// </summary>
        [JsonProperty("abstract")]
        public string AbstractInfo { get; set; }

        /// <summary>
        /// 封面图片列表，仅支持填入一个封面图片链接，上传图片接口上传获取图片获得链接，填写非CDN链接会报错，并在此填入。建议图片尺寸像素850*350
        /// </summary>
        [JsonProperty("icon_url_list")]
        public string[] IconUrlList { get; set; }
    }
    /// <summary>
    /// 图文列表，显示在详情内页，优惠券券开发者须至少传入一组图文列表
    /// </summary>
    public class TextImageList
    {
        /// <summary>
        /// 图片链接，必须调用上传图片接口，上传图片获得链接，并在此填入，否则报错
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 图文描述
        /// </summary>
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

        /// <summary>
        /// 当前type类型下的起始时间（小时），如当前结构体内填写了MONDAY，此处填写了10，则此处表示周一 10:00可用
        /// </summary>
        [JsonProperty("begin_hour")]
        public int BeginHour { get; set; }

        /// <summary>
        /// 当前type类型下的结束时间（小时），如当前结构体内填写了MONDAY，此处填写了20，则此处表示周一 10:00-20:00可用
        /// </summary>
        [JsonProperty("end_hour")]
        public int EndHour { get; set; }

        /// <summary>
        /// 当前type类型下的起始时间（分钟），如当前结构体内填写了MONDAY，begin_hour填写10，此处填写了59，则此处表示周一 10:59可用
        /// </summary>
        [JsonProperty("begin_minute")]
        public int BeginMinute { get; set; }

        /// <summary>
        /// 当前type类型下的结束时间（分钟），如当前结构体内填写了MONDAY，begin_hour填写10，此处填写了59，则此处表示周一 10:59-00:59可用
        /// </summary>
        [JsonProperty("end_minute")]
        public int EndMinute { get; set; }
    }

    /// <summary>
    /// 使用时段限制类型
    /// </summary>
    public enum TimeLimitTypes
    {
        /// <summary>
        ///  周一
        /// </summary>
        [Display(Name = "周一")]
        MONDAY,
        /// <summary>
        /// 周二
        /// </summary>
        [Display(Name = "周二")]
        TUESDAY,
        /// <summary>
        /// 周三
        /// </summary>
        [Display(Name = "周三")]
        WEDNESDAY,
        /// <summary>
        /// 周四
        /// </summary>
        [Display(Name = "周四")]
        THURSDAY,
        /// <summary>
        /// 周五
        /// </summary>
        [Display(Name = "周五")]
        FRIDAY,
        /// <summary>
        /// 周六
        /// </summary>
        [Display(Name = "周六")]
        SATURDAY,
        /// <summary>
        /// 周日
        /// </summary>
        [Display(Name = "周日")]
        SUNDAY,
        /// <summary>
        /// 节假日
        /// </summary>
        [Display(Name = "节假日")]
        HOLIDAY
    }
}
