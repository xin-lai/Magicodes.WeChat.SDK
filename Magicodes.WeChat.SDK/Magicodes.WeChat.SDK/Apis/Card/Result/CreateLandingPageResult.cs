using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class CreateLandingPageResult : ApiResult
    {
        /// <summary>
        /// 货架链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 货架ID。货架的唯一标识。
        /// </summary>
        [JsonProperty("page_id")]
        public int PageId { get; set; }
    }
}
