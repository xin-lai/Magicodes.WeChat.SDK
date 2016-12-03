using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 积分规则 
    /// </summary>
    public class BonusRule
    {
        /// <summary>
        /// 否 int 消费金额。以分为单位。
        /// </summary>
        [JsonProperty("cost_money_unit")]
        public int Cost_money_unit
        {
            get;
            set;
        }

        /// <summary>
        /// 否 int 对应增加的积分。
        /// </summary>
        [JsonProperty("increase_bonus")]
        public int Increase_bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否 int 用户单次可获取的积分上限。
        /// </summary>
        [JsonProperty("max_increase_bonus")]
        public int Max_increase_bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否 int 初始设置积分。
        /// </summary>
        [JsonProperty("init_increase_bonus")]
        public int Init_increase_bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否 int 每使用5积分。
        /// </summary>
        [JsonProperty("cost_bonus_unit")]
        public int Cost_bonus_unit
        {
            get;
            set;
        }

        /// <summary>
        /// 否  int 抵扣xx元，（这里以分为单位）
        /// </summary>
        [JsonProperty("reduce_money")]
        public int Reduce_money
        {
            get;
            set;
        }

        /// <summary>
        /// 否  int 抵扣条件，满xx元（这里以分为单位）可用。
        /// </summary>
        [JsonProperty("least_money_to_use_bonus")]
        public int Least_money_to_use_bonus
        {
            get;
            set;
        }

        /// <summary>
        /// 否 int 抵扣条件，单笔最多使用xx积分。
        /// </summary>
        [JsonProperty("max_reduce_bonus")]
        public int Max_reduce_bonus
        {
            get;
            set;
        }
    }
}
