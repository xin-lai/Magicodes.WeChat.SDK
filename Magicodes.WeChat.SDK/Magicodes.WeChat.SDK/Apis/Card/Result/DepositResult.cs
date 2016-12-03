using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    /// <summary>
    /// 导入自定义Code返回数据实体
    /// </summary>
    public class DepositCustomCodeResult : ApiResult
    {
        /// <summary>
        /// 成功数量
        /// </summary>
        [JsonProperty("succ_code")]
        public int SuccCode { get; set; }

        /// <summary>
        /// 重复导入的Code
        /// </summary>
        [JsonProperty("duplicate_code")]
        public string DuplicateCode { get; set; }

        /// <summary>
        /// 失败的数量
        /// </summary>
        [JsonProperty("fail_code")]
        public int FailCode { get; set; }
    }
    /// <summary>
    /// 查询导入code数目接口返回实体
    /// </summary>
    public class GetDepositCountResult : ApiResult
    {
        /// <summary>
        /// 已经成功存入的code数目
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }
    /// <summary>
    /// 核查code接口返回数据
    /// </summary>
    public class CheckCodeResult : ApiResult
    {
        /// <summary>
        /// 已经成功存入的code。
        /// </summary>
        [JsonProperty("exist_code")]
        public List<string> ExistCode { get; set; }

        /// <summary>
        /// 没有存入的code。
        /// </summary>
        [JsonProperty("not_exist_code")]
        public List<string> NotExistCode { get; set; }

    }
}
