using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    public class UpdateUserRequest
    {
        /// <summary>
        /// 是string(20)1231123卡券Code码。
        /// </summary>
        [MaxLength(20)]
        [Required]
        [JsonProperty("code")]
        [JsonRequired]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 是string（32）p1Pj9jr90_SQ    卡券ID。RaVqYI239Ka1erkI
        /// </summary>
        [MaxLength(32)]
        [Required]
        [JsonProperty("card_id")]
        [JsonRequired]
        public string Card_id
        {
            get;
            set;
        }

        /// <summary>
        /// 否            	string（128）           	https:mmbiz.qlogo.cn/    支持商家激活时针对单个会员卡分配自定义的会员卡背景。
        /// </summary>
        [MaxLength(128)]
        [JsonProperty("background_pic_url")]
        public string Background_pic_url
        {
            get;
            set;
        }

        /// <summary>
        /// 否            	int100需要设置的积分全量值，传入的数值会直接显示
        /// </summary>
        [JsonProperty("bonus")]
        public int Bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否string(42)消费30元，获得3积分商家自定义积分消耗记录，不超过14个汉字。
        /// </summary>
        [MaxLength(42)]
        [JsonProperty("record_bonus")]
        public string Record_bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否           	int100需要设置的余额全量值，传入的数值会直接显示
        /// </summary>
        [JsonProperty("balance")]
        public int Balance
        {
            get;
            set;
        }

        /// <summary>
        /// 否string(42)购买焦糖玛    商家自定义金额消耗记录，不超过14个汉字。 琪朵一杯，扣除金额30元。
        /// </summary>
        [MaxLength(42)]
        [JsonProperty("record_balance")]
        public string Record_balance
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（12）白金创建时字段custom_field1定义类型的最新数值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("custom_field_value1")]
        public string Custom_field_value1
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（12）8折创建时字段custom_field2定义类型的最新数值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("custom_field_value2")]
        public string Custom_field_value2
        {
            get;
            set;
        }

        /// <summary>
        /// 否string（12）500创建时字段custom_field3定义类型的最新数值，限制为4个汉字，12字节。
        /// </summary>
        [MaxLength(12)]
        [JsonProperty("custom_field_value3")]
        public string Custom_field_value3
        {
            get;
            set;
        }

        [JsonProperty("notify_optional")]
        public NotifyOptional Notifyoptional { get; set; }
    }
}
