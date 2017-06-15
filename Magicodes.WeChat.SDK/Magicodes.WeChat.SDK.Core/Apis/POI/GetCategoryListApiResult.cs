using System.Collections.Generic;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class GetCategoryListApiResult : ApiResult
    {
        [JsonProperty("category_list")]
        public List<string> CategoryList { get; set; }
    }
}