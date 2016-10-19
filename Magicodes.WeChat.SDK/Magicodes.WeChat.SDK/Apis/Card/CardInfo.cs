using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public class CardInfo
    {
        /// <summary>
        /// 卡券类型
        /// </summary>
        public CardTypes card_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Groupon groupon { get; set; }
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
    public class Groupon
    {
        public Base_Info base_info { get; set; }
        public Advanced_Info advanced_info { get; set; }
        public string deal_detail { get; set; }
    }

    public class Base_Info
    {
        public string logo_url { get; set; }
        public string brand_name { get; set; }
        public string code_type { get; set; }
        public string title { get; set; }
        public string sub_title { get; set; }
        public string color { get; set; }
        public string notice { get; set; }
        public string service_phone { get; set; }
        public string description { get; set; }
        public Date_Info date_info { get; set; }
        public Sku sku { get; set; }
        public int get_limit { get; set; }
        public bool use_custom_code { get; set; }
        public bool bind_openid { get; set; }
        public bool can_share { get; set; }
        public bool can_give_friend { get; set; }
        public int[] location_id_list { get; set; }
        public string center_title { get; set; }
        public string center_sub_title { get; set; }
        public string center_url { get; set; }
        public string custom_url_name { get; set; }
        public string custom_url { get; set; }
        public string custom_url_sub_title { get; set; }
        public string promotion_url_name { get; set; }
        public string promotion_url { get; set; }
        public string source { get; set; }
    }

    public class Date_Info
    {
        public string type { get; set; }
        public int begin_timestamp { get; set; }
        public int end_timestamp { get; set; }
    }

    public class Sku
    {
        public int quantity { get; set; }
    }

    public class Advanced_Info
    {
        public Use_Condition use_condition { get; set; }
        public Abstract _abstract { get; set; }
        public Text_Image_List[] text_image_list { get; set; }
        public Time_Limit[] time_limit { get; set; }
        public string[] business_service { get; set; }
    }

    public class Use_Condition
    {
        public string accept_category { get; set; }
        public string reject_category { get; set; }
        public bool can_use_with_other_discount { get; set; }
    }

    public class Abstract
    {
        public string _abstract { get; set; }
        public string[] icon_url_list { get; set; }
    }

    public class Text_Image_List
    {
        public string image_url { get; set; }
        public string text { get; set; }
    }

    public class Time_Limit
    {
        public string type { get; set; }
        public int begin_hour { get; set; }
        public int end_hour { get; set; }
        public int begin_minute { get; set; }
        public int end_minute { get; set; }
    }

}
