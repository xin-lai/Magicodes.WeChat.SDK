using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public class UploadImageApiResult : ApiResult
    {
        /// <summary>
        /// 商户图片url，用于创建卡券接口中填入。特别注意：该链接仅用于微信相关业务，不支持引用。
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
