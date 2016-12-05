using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    /// <summary>
    /// 拉取卡券概况返回数据
    /// </summary>
    public class CardBizuinInfoResult : ApiResult
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("list")]
        public List<ViewResultInfo> ResultList { get; set; }
    }

    public class ViewResultInfo
    {
        /// <summary>
        /// 日期信息
        /// </summary>
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        /// <summary>
        /// 子商户类型
        /// </summary>
        [JsonProperty("merchanttype")]
        public string MerchantType { get; set; }


        /// <summary>
        /// 子商户ID
        /// </summary>
        [JsonProperty("submerchantid")]
        public string SubmerChantId { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        [JsonProperty("view_cnt")]
        public int ViewCont { get; set; }
        /// <summary>
        /// 浏览人数
        /// </summary>
        [JsonProperty("view_user")]
        public int ViewUser { get; set; }

        /// <summary>
        /// 领取次数
        /// </summary>
        [JsonProperty("receive_cnt")]
        public int ReceiveCount { get; set; }

        /// <summary>
        /// 领取人数
        /// </summary>
        [JsonProperty("receive_user")]
        public int ReceiveUser { get; set; }
        /// <summary>
        /// 使用次数
        /// </summary>
        [JsonProperty("verify_cnt")]
        public int VerifyCount { get; set; }

        /// <summary>
        /// 使用人数
        /// </summary>
        [JsonProperty("verify_user")]
        public int VerifyUser { get; set; }

        /// <summary>
        /// 激活人数
        /// </summary>
        [JsonProperty("active_user")]
        public int ActiveUser { get; set; }

        /// <summary>
        /// 有效会员总人数
        /// </summary>
        [JsonProperty("total_user")]
        public int TotalUser { get; set; }
        /// <summary>
        /// 历史领取会员卡总人数
        /// </summary>
        [JsonProperty("total_receive_user")]
        public int TotalReceiveUser { get; set; }

        /// <summary>
        /// 新用户数
        /// </summary>
        [JsonProperty("new_user")]
        public int NewUser { get; set; }

        /// <summary>
        /// 应收金额（仅限使用快速买单的会员卡）
        /// </summary>
        [JsonProperty("payOriginalFee")]
        public int PayOriginalFee { get; set; }

        /// <summary>
        /// 实收金额（仅限使用快速买单的会员卡）
        /// </summary>
        [JsonProperty("Fee")]
        public int Fee { get; set; }

    }
}
