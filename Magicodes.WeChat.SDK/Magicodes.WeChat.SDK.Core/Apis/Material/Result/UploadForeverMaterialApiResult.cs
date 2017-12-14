using Magicodes.WeChat.SDK.Apis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Core.Apis.Material
{
    public class UploadForeverMaterialApiResult : ApiResult
    {
        /// <summary>
        /// 新增的永久素材的media_id
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 新增的图片素材的图片URL（仅新增图片素材时会返回该字段）
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
