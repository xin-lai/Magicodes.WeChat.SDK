using Magicodes.WeChat.SDK.Helper;
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
    /// 接口激活会员卡
    /// </summary>
    public class ActivateMemberCardRequest
    {
        /// <summary>
        /// 是string(20)会员卡编号，由开发者填入，作为序列号显示在用户的卡包里。可与Code码保持等值。
        /// </summary>
        [MaxLength(20)]
        [Required]
        [JsonRequired]
        [JsonProperty("membership_number")]
        public string Membership_number
        {
            get;
            set;
        }

        /// <summary>
        /// 是string(20)领取会员卡用户获得的code
        /// </summary>
        [MaxLength(20)]
        [Required]
        [JsonRequired]
        [JsonProperty("code")]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 否     	string（32）    	卡券ID,自定义code卡券必填
        /// </summary>
        [MaxLength(32)]
        [JsonProperty("card_id")]
        public string Card_id
        {
            get;
            set;
        }

        /// <summary>
        /// 否   	 string（128） 	商家自定义会员卡背景图，须先调用上传图片接口将背景图上传至CDN，否则报错，卡面设计请遵循微信会员卡自定义背景设计规范
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("background_pic_url")]
        public string Background_pic_url
        {
            get;
            set;
        }

        /// <summary>
        /// 否int初始积分，不填为0。
        /// </summary>
        [JsonProperty("init_bonus")]
        public int Init_bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否int初始余额，不填为0。
        /// </summary>
        [JsonProperty("init_balance")]
        public int Init_balance
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（12）创建时字段custom_field1定义类型的初始值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("init_custom_field_value1")]
        public string Init_custom_field_value1
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（12）创建时字段custom_field2定义类型的初始值，限制为4个汉字，12字节。
        /// </summary>
        [JsonProperty("init_custom_field_value2")]
        [MaxLength(12)]
        public string Init_custom_field_value2
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（12）创建时字段custom_field3定义类型的初始值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("init_custom_field_value3")]
        public string Init_custom_field_value3
        {
            get;
            set;
        }

        [JsonIgnore]
        [JsonProperty("begin_time")]
        public DateTime? BeginTime { get; set; }

        [JsonIgnore]
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("activate_begin_time")]
        public long? Activate_begin_time
        {
            get
            {
                if (BeginTime == null)
                    return default(long);
                return BeginTime.Value.ConvertToTimeStamp();
            }
        }

        /// <summary>
        /// 否unsigned int激活后的有效截至时间。若不填写默认以创建时的 data_info 为准。Unix时间戳格式。
        /// </summary>
        [JsonProperty("activate_end_time")]
        public long? Activate_end_time
        {
            get
            {
                if (EndTime == null)
                    return default(long);
                return EndTime.Value.ConvertToTimeStamp();
            }
        }
    }
}
