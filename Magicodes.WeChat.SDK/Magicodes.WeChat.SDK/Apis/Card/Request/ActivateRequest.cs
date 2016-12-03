using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class ActivateRequest
    {
        /// <summary>
        /// 会员卡编号，由开发者填入，作为序列号显示在用户的卡包里。可与Code码保持等值。  
        /// </summary>
        [MaxLength(20)]
        [Required]
        [JsonRequired]
        [JsonProperty("membership_number")]
        public string MembershipNumber { get; set; }

        /// <summary>
        /// 会员卡编号，由开发者填入，作为序列号显示在用户的卡包里。可与Code码保持等值。  
        /// </summary>
        [MaxLength(20)]
        [Required]
        [JsonRequired]
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 卡券ID,自定义code卡券必填
        /// </summary>
        [MaxLength(32)]
        [JsonProperty("card_id")]
        public string card_id { get; set; }

        /// <summary>
        /// 商家自定义会员卡背景图，须先调用上传图片接口将背景图上传至CDN，否则报错，卡面设计请遵循微信会员卡自定义背景设计规范
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("background_pic_url")]
        public string BackgroundPicUrl { get; set; }

        /// <summary>
        /// 激活后的有效起始时间。若不填写默认以创建时的 data_info 为准。Unix时间戳格式。  
        /// </summary>
        [JsonProperty("activate_begin_time ")]
        public long ActivateBeginTime { get; set; }

        /// <summary>
        /// 激活后的有效截至时间。若不填写默认以创建时的 data_info 为准。Unix时间戳格式。  
        /// </summary>
        [JsonProperty("activate_end_time  ")]
        public long ActivateEndTime { get; set; }

        /// <summary>
        /// 初始积分
        /// </summary>
        [JsonProperty("init_bonus  ")]
        public long InitBonus { get; set; }

        /// <summary>
        /// 初始余额
        /// </summary>
        [JsonProperty("init_balance")]
        public long InitBalance { get; set; }

        /// <summary>
        /// 创建时字段custom_field1定义类型的初始值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("init_custom_field_value1 ")]
        public long InitCustomFieldValue1 { get; set; }

        /// <summary>
        /// 创建时字段custom_field3定义类型的初始值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("init_custom_field_value2 ")]
        public long InitCustomFieldValue2 { get; set; }

        /// <summary>
        /// 创建时字段custom_field3定义类型的初始值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("init_custom_field_value3 ")]
        public long InitCustomFieldValue3 { get; set; }
    }
}
