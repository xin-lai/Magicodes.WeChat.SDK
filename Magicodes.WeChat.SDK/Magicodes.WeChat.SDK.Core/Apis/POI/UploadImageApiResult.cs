using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    public class UploadImageApiResult : ApiResult
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
