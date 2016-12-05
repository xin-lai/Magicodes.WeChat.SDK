using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class AddPayGiftMemberResult : ApiResult
    {
        /// <summary>
        /// 设置成功的mchid列表    
        /// </summary>
        [JsonProperty("succ_list")]
        public List<string> SuccList { get; set; }

        /// <summary>
        /// 设置失败的mchid列表 
        /// </summary>
        [JsonProperty("fail_list")]
        public List<FailedResult> FailList { get; set; }
    }
    /// <summary>
    /// 设置失败的mchid
    /// </summary>
    public class FailedResult : ApiResult
    {
        /// <summary>
        /// 支付的商户号   
        /// </summary>
        [JsonProperty("mchid")]
        public string MchId { get; set; }

        /// <summary>
        /// 设置失败原因为重复设置时，该mchid当前被占用的appid，商户须使用该appid解除绑定后重新设置。
        /// </summary>
        [JsonProperty("occupy_appid")]
        public string OccupyAppid { get; set; }
    }
    /// <summary>
    /// 可以查询某个商户号是否支持支付即会员功能返回数据
    /// </summary>
    public class GetPayGiftMemberResult : ApiResult
    {
        public string CardId { get; set; }

        /// <summary>
        /// 设置失败原因为重复设置时，该mchid当前被占用的appid，商户须使用该appid解除绑定后重新设置。
        /// </summary>
        [JsonProperty("occupy_appid")]
        public string OccupyAppid { get; set; }

        /// <summary>
        /// 是否允许其他appid设置本规则内已经设置过的商户号，默认为true
        /// </summary>
        [JsonProperty("is_locked")]
        public bool IsLocked { get; set; }
    }
}
