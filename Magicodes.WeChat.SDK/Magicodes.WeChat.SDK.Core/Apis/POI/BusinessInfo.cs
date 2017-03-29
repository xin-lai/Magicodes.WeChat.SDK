using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    /// <summary>
    /// 门店信息
    /// </summary>
    public class BusinessInfo
    {
        [JsonProperty("base_info")]
        public POIDetailInfo POIDetailInfo { get; set; }
    }
}
