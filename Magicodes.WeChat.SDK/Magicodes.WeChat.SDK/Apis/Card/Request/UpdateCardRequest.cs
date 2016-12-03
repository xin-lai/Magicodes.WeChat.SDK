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
    /// 更新会员卡信息实体
    /// </summary>
    public class UpdateCardRequest
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 会员卡信息
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("member_card")]
        public MemberCardUpdate MemberCard
        {
            get;
            set;
        }
    }

    public class MemberCardUpdate
    {
        /// <summary>
        /// 卡券修改实体
        /// </summary>
        [JsonProperty("base_info")]
        public UpdateBaseInfo UpdateBaseInfo { get; set; }

        /// <summary>
        /// 积分清零规则
        /// 非必填
        /// </summary>
        [JsonProperty("bonus_cleared")]
        public string Bonus_cleared { get; set; }

        /// <summary>
        /// 积分规则
        /// 非必填
        /// </summary>
        [JsonProperty("bonus_rules")]
        public string Bonus_rules { get; set; }

        /// <summary>
        /// 卡背景图
        /// 非必填
        /// </summary>
        [JsonProperty("background_pic_url")]
        public string Background_pic_url { get; set; }

        /// <summary>
        /// 会员卡特权说明。  
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(3072)]
        [JsonProperty("prerogative")]
        public string Prerogative { get; set; }

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
        [JsonProperty("supply_bonus")]
        public bool SupplyBonus { get; set; }

        /// <summary>
        ///  否 string(128) 设置跳转外链查看积分详情。仅适用于积分无法通过激活接口同步的情况下使用该字段。  
        /// </summary>
        [JsonProperty("bonus_url")]
        public string BonusUrl { get; set; }

        ///// <summary>
        ///// 初始设置积分 int型数据
        ///// 非必填,null时显示查看
        ///// </summary>
        //[JsonProperty("init_increase_bonus")]
        //public int Init_increase_bonus { get; set; }

        /// <summary>
        /// 是 bool 是否支持储值，填写true或false。如填写true，储值相关字段均为必填。 
        /// 修改：是，需要提审
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("supply_balance")]
        public bool SupplyBalance { get; set; }

        /// <summary>
        /// 储值说明
        /// 提审：否
        /// </summary>
        [JsonProperty("balance_rules")]
        public string Balance_rules { get; set; }

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
        /// 自定义会员信息类目，会员卡激活后显示。
        /// 修改：是，不需要提审
        /// </summary>
        [JsonProperty("custom_cell1")]
        public CustomCell CustomCell1 { get; set; }

        /// <summary>
        ///  是 string（128） 激活会员卡的url。 
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("activate_url")]
        public string ActivateUrl { get; set; }



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

    /// <summary>
    /// 卡券修改实体
    /// </summary>
    public class UpdateBaseInfo
    {
        /// <summary>
        /// 商户logo，建议像素为300*300。 
        /// 提审：是
        /// </summary>
        [JsonProperty("logo_url")]
        public string Logo_url { get; set; }

        /// <summary>
        /// 使用提醒，字数上限为16个字
        /// 提审：否
        /// </summary>
        [JsonProperty("notice")]
        public string Notice { get; set; }

        /// <summary>
        /// 使用说明
        /// 提审：是
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 客服电话
        /// 提审：否
        /// </summary>
        [JsonProperty("service_phone")]
        public string Service_phone { get; set; }

        /// <summary>
        /// 卡券颜色
        /// 提审：否
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        /// <summary>
        /// 门店列表
        /// 提审：否
        /// </summary>
        [JsonProperty("location_id_list")]
        public string Location_id_list { get; set; }

        /// <summary>
        /// 会员卡中部的跳转按钮名称，建议用作使用用途
        /// 提审：否
        /// </summary>
        [MaxLength(18)]
        [JsonProperty("center_title")]
        public string Center_title { get; set; }

        /// <summary>
        /// 会员卡中部按钮解释wording
        /// 提审：否
        /// </summary>
        [MaxLength(24)]
        [JsonProperty("center_sub_title")]
        public string Center_sub_title { get; set; }

        /// <summary>
        /// 会员卡中部按钮对应跳转的url           
        /// 提审：否
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("center_url")]
        public string Center_url { get; set; }

        /// <summary>
        /// 自定义跳转入口的名字。           
        /// 提审：否
        /// </summary>
        [MaxLength(16)]
        [JsonProperty("custom_url_name")]
        public string Custom_url_name { get; set; }
        /// <summary>
        /// 显示在入口右侧的提示语。           
        /// 提审：否
        /// </summary>
        [MaxLength(18)]
        [JsonProperty("custom_url_sub_title")]
        public string Custom_url_sub_title { get; set; }

        /// <summary>
        /// 自定义跳转的URL。     
        /// 提审：否
        /// </summary>
        [JsonProperty("custom_url")]
        public string Custom_url { get; set; }

        /// <summary>
        /// 否string（16）营销场景的自定义入口名称。
        /// 修改：是，不需要提审
        /// </summary>
        [MaxLength(16)]
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
        /// 是JSON结构使用日期，有效期的信息。
        /// 修改：不需要提审
        /// </summary>
        [JsonProperty("date_info")]
        public DateInfo Date_info
        {
            get;
            set;
        }
    }
}
