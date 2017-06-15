using System.Collections.Generic;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class GetApiResult : ApiResult
    {
        /// <summary>
        ///     门店信息
        /// </summary>
        [JsonProperty("business_list")]
        public List<BusinessInfo> BusinessList { get; set; }
    }
}