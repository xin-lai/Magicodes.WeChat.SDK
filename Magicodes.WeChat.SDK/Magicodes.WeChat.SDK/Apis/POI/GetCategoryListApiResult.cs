using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class GetCategoryListApiResult : ApiResult
    {
        [JsonProperty("category_list")]
        public List<string> CategoryList { get; set; }
    }
}
