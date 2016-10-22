using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class GetApiResult : ApiResult
    {
        /// <summary>
        /// 门店信息
        /// </summary>
        [JsonProperty("business_list")]
        public List<BusinessInfo> BusinessList { get; set; }

    }
}
