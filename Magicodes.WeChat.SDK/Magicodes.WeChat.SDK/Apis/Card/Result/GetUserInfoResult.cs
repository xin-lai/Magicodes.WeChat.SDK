using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class GetUserInfoResult : ApiResult
    {
        /// <summary>
        /// 用户在本公众号内唯一识别码
        /// </summary>
        [JsonProperty("openid")]
        public string Openid
        {
            get;
            set;
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname
        {
            get;
            set;
        }

        /// <summary>
        /// 积分信息
        /// </summary>
        [JsonProperty("bonus")]
        public string Bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 余额信息
        /// </summary>
        [JsonProperty("balance")]
        public string Balance
        {
            get;
            set;
        }

        /// <summary>
        /// 用户性别
        /// </summary>
        [JsonProperty("sex")]
        public string Sex
        {
            get;
            set;
        }

        /// <summary>
        /// 会员信息
        /// </summary>
        [JsonProperty("user_info")]
        public UserInfo User_info
        {
            get;
            set;
        }

        /// <summary>
        /// 开发者设置的会员卡会员信息类目，如等级。
        /// </summary>
        [JsonProperty("custom_field_list")]
        public string Custom_field_list
        {
            get;
            set;
        }

        /// <summary>
        /// 会员信息类目名称
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 会员卡信息类目值，比如等级值等
        /// </summary>
        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// 当前用户的会员卡状态
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("user_card_status")]
        public UserCardStatus User_card_status
        {
            get;
            set;
        }

        /// <summary>
        /// 该卡是否已经被激活，true表示已经被激活，false表示未被激活
        /// </summary>
        [JsonProperty("has_active")]
        public bool Has_active
        {
            get;
            set;
        }
    }
}
