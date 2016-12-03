using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 会员卡
    /// </summary>
    public class MemberCardInfo : CardInfo
    {
        [Required]
        [JsonRequired]
        [JsonProperty("member_card")]
        public MemberCard MemberCard
        {
            get;
            set;
        }
    }
    #region MemberBaseInfo
    public class MemberBaseInfo
    {
        /// <summary>
        /// 是string(128)卡券的商户logo，建议像素为300*300。
        /// 修改：是，需要提审
        /// </summary>
        [MaxLength(128)]
        [Required]
        [JsonRequired]
        [JsonProperty("logo_url")]
        public string Logo_url
        {
            get;
            set;
        }

        /// <summary>
        /// 是string(16)Code展示类型，  "CODE_TYPE_TEXT" 文本   "CODE_TYPE_BARCODE" 一维码 "CODE_TYPE_QRCODE" 二维码 "CODE_TYPE_ONLY_QRCODE"仅显示二维码  "CODE_TYPE_ONLY_BARCODE"仅显示一维码"CODE_TYPE_NONE" 不显示任何码型
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(16)]
        [Required]
        [JsonRequired]
        [JsonProperty("code_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CodeTypes Code_type
        {
            get;
            set;
        }

        /// <summary>
        /// 是string（36）商户名字,字数上限为12个汉字。
        /// 修改：否
        /// </summary>
        [MaxLength(36)]
        [Required]
        [JsonRequired]
        [JsonProperty("brand_name")]
        public string Brand_name
        {
            get;
            set;
        }

        /// <summary>
        /// 是string（27）卡券名，字数上限为9个汉字(建议涵盖卡券属性、服务及金额)。
        /// 修改：否
        /// </summary>
        [MaxLength(27)]
        [Required]
        [JsonRequired]
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 是string（16）券颜色。按色彩规范标注填写Color010-Color100
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(16)]
        [Required]
        [JsonRequired]
        [JsonProperty("color")]
        public string Color
        {
            get;
            set;
        }

        /// <summary>
        /// 是string（48）卡券使用提醒，字数上限为16个汉字。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(48)]
        [Required]
        [JsonRequired]
        [JsonProperty("notice")]
        public string Notice
        {
            get;
            set;
        }

        /// <summary>
        /// 是string（3072）卡券使用说明，字数上限为1024个汉字。
        /// 修改：是，需要提审
        /// </summary>
        [MaxLength(1024)]
        [Required]
        [JsonRequired]
        [JsonProperty("description")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 是JSON结构商品信息。
        /// 修改：否
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("sku")]
        public Sku Sku
        {
            get;
            set;
        }

        /// <summary>
        /// 是JSON结构使用日期，有效期的信息。
        /// 修改：是，不需要提审
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("date_info")]
        public DateInfo Date_info
        {
            get;
            set;
        }

        /// <summary>
        /// 否bool是否自定义Code码。填写true或false，默认为false通常自有优惠码系统的开发者选择自定义Code码，详情见是否自定义code
        /// 修改：否
        /// </summary>
        [JsonProperty("use_custom_code")]
        public bool Use_custom_code
        {
            get;
            set;
        }

        /// <summary>
        /// 否bool是否指定用户领取，填写true或false。默认为false
        /// 修改：否
        /// </summary>
        [JsonProperty("bind_openid")]
        public bool Bind_openid
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（24）客服电话
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(24)]
        [JsonProperty("service_phone")]
        public string Service_phone
        {
            get;
            set;
        }

        /// <summary>
        /// 否array门店位置ID。调用POI门店管理接口获取门店位置ID。
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("location_id_list")]
        public int[] Location_id_list
        {
            get;
            set;
        }

        /// <summary>
        /// 否	bool	会员卡是否支持全部门店，填写后商户门店更新时会自动同步至卡券
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("use_all_locations")]
        public bool Use_all_locations
        {
            get;
            set;
        }

        /// <summary>
        /// 否	string（18） 卡券中部居中的按钮，仅在卡券激活后且可用状态时显示
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(18)]
        [JsonProperty("center_title")]
        public string Center_title
        {
            get;
            set;
        }

        /// <summary>
        /// 否   string（24）  显示在入口下方的提示语，仅在卡券激活后且可用状态时显示
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(24)]
        [JsonProperty("center_sub_title")]
        public string Center_sub_title
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（128）顶部居中的url，仅在卡券激活后且可用状态时显示
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("center_url")]
        public string Center_url
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（15）自定义跳转外链的入口名字。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(15)]
        [JsonProperty("custom_url_name")]
        public string Custom_url_name
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（128）自定义跳转的URL。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("custom_url")]
        public string Custom_url
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（18）显示在入口右侧的提示语。
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("custom_url_sub_title")]
        [MaxLength(18)]
        public string Custom_url_sub_title
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（15）营销场景的自定义入口名称。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(15)]
        [JsonProperty("promotion_url_name")]
        public string Promotion_url_name
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（128）入口跳转外链的地址链接。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("promotion_url")]
        public string Promotion_url
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（18）显示在营销入口右侧的提示语。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(18)]
        [JsonProperty("promotion_url_sub_title")]
        public string Promotion_url_sub_title
        {
            get;
            set;
        }

        /// <summary>
        /// 否 int 每人可领券的数量限制，建议会员卡每人限领一张
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("get_limit")]
        public int GetLimit { get; set; }

        /// <summary>
        /// 否bool卡券领取页面是否可分享，默认为true
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("can_share")]
        public bool Can_share
        {
            get;
            set;
        }

        /// <summary>
        /// 否bool卡券是否可转赠,默认为true
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("can_give_friend")]
        public bool Can_give_friend
        {
            get;
            set;
        }

        /// <summary>
        /// 否bool填写true为用户点击进入会员卡时推送事件，默认为false。详情见进入会员卡事件推送
        /// 修改：否
        /// </summary>
        [JsonProperty("need_push_on_view")]
        public bool Need_push_on_view
        {
            get;
            set;
        }

        /// <summary>
        /// 微信支付刷卡
        /// </summary>
        [JsonProperty("pay_info")]
        public PayInfo PayInfo { get; set; }
    }

    public class PayInfo
    {
        [JsonProperty("swipe_card")]
        public SwipeCard SwipeCard { get; set; }
    }
    public class SwipeCard
    {
        [JsonProperty("is_swipe_card")]
        public bool IsSwipeCard { get; set; }
    }
    #endregion

    #region MemberCard
    public class MemberCard
    {

        /// <summary>
        /// 先调用上传图片接口将背景图上传至CDN，否则报错，卡面设计请遵循微信会员卡自定义背景设计规范  ,像素大小控制在1000像素*600像素以下
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("background_pic_url")]
        public string BackgroundPicUrl { get; set; }

        /// <summary>
        /// 基础信息
        /// </summary>
        [JsonProperty("base_info")]
        public MemberBaseInfo Baseinfo { get; set; }

        /// <summary>
        /// 会员卡特权说明。  
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(3072)]
        [Required]
        [JsonRequired]
        [JsonProperty("prerogative")]
        public string Prerogative { get; set; }

        /// <summary>
        /// 填入该字段后，自定义code卡券方可进行导入code并投放的动作。
        /// </summary>
        [JsonProperty("get_custom_code_mode")]
        public string GetCustomCodeMode { get; set; }



        /// <summary>
        ///  否 bool 设置为true时用户领取会员卡后系统自动将其激活，无需调用激活接口，详情见自动激活。 
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("auto_activate")]
        public bool AutoActivate { get; set; }

        /// <summary>
        ///  否 bool 设置为true时会员卡支持一键开卡，不允许同时传入activate_url字段，否则设置wx_activate失效。填入该字段后仍需调用接口设置开卡项方可生效，详情见一键开卡。 
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("wx_activate")]
        public bool WxActivate { get; set; }

        /// <summary>
        /// 是 显示积分，填写true或false，如填写true，积分相关字段均为必填。
        /// 修改：是，需要提审
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("supply_bonus")]
        public bool SupplyBonus { get; set; }

        /// <summary>
        ///  否 string(128) 设置跳转外链查看积分详情。仅适用于积分无法通过激活接口同步的情况下使用该字段。  
        /// </summary>
        [JsonProperty("bonus_url")]
        public string BonusUrl { get; set; }

        /// <summary>
        /// 是 bool 是否支持储值，填写true或false。如填写true，储值相关字段均为必填。 
        /// 修改：是，需要提审
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("supply_balance")]
        public bool SupplyBalance { get; set; }

        /// <summary>
        ///  否 string(128) 设置跳转外链查看余额详情。仅适用于余额无法通过激活接口同步的情况下使用该字段。 
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("balance_url")]
        public string balance_url { get; set; }

        /// <summary>
        /// 自定义会员信息类目，会员卡激活后显示,包含name_type(name)和url字段  
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("custom_field1")]
        public CustomField CustomField1 { get; set; }

        /// <summary>
        /// 自定义会员信息类目，会员卡激活后显示,包含name_type(name)和url字段  
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("custom_field2")]
        public CustomField CustomField2 { get; set; }

        /// <summary>
        /// 自定义会员信息类目，会员卡激活后显示,包含name_type(name)和url字段  
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("custom_field3")]
        public CustomField CustomField3 { get; set; }

        /// <summary>
        ///  是 string（128） 激活会员卡的url。 
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(128)]
        [Required]
        [JsonRequired]
        [JsonProperty("activate_url")]
        public string ActivateUrl { get; set; }

        /// <summary>
        /// 自定义会员信息类目，会员卡激活后显示。
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("custom_cell1")]
        public CustomCell CustomCell1 { get; set; }

        /// <summary>
        /// 积分规则
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("bonus_rule")]
        public BonusRule BonusRules { get; set; }

        /// <summary>
        /// 否 int 折扣，该会员卡享受的折扣优惠,填10就是九折。    
        /// 修改：是，需要提审
        /// </summary>
        [JsonProperty("discount")]
        public int Discount { get; set; }
    }
    #endregion  
}
