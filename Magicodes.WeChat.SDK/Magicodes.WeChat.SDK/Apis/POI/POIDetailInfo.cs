using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class POIDetailInfo : POIInfo
    {
        /// <summary>
        /// 门店Id
        /// </summary>
        [JsonProperty("poi_id")]
        public string PoiId { get; set; }
        /// <summary>
        /// 门店是否可用状态。
        /// 1 表示系统错误、2 表示审核中、3 审核通过、4 审核驳回。当该字段为1、2、4 状态时，poi_id 为空
        /// </summary>
        [JsonProperty("available_state")]
        public AvailableState AvailableState { get; set; }
        /// <summary>
        /// 扩展字段是否正在更新中。
        /// 1 表示扩展字段正在更新中，尚未生效，不允许再次更新； 0 表示扩展字段没有在更新中或更新已生效，可以再次更新
        /// </summary>
        [JsonProperty("update_status")]
        public int UpdateStatus { get; set; }
    }
    public enum AvailableState
    {
        系统错误 = 1,
        审核中 = 2,
        审核通过 = 3,
        审核驳回 = 4
    }
}
