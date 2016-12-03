using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Result
{
    public class CreateQRCodeResult : ApiResult
    {

        /// <summary>
        /// 获取的二维码ticket，凭借此ticket调用通过ticket换取二维码接口可以在有效时间内换取二维码。
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        /// <summary>
        /// 二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 二维码显示地址，点击后跳转二维码页面
        /// </summary>
        [JsonProperty("show_qrcode_url")]
        public string ShowQrCodeUrl { get; set; }
    }
}
