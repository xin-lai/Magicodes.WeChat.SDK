// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : QRCodeCreateApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.QRCode
{
    /// <summary>
    /// </summary>
    public class QRCodeCreateApiResult : ApiResult
    {
        /// <summary>
        ///     获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。
        /// </summary>
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        /// <summary>
        ///     该二维码有效时间，以秒为单位。 最大不超过2592000（即30天）。
        /// </summary>
        [JsonProperty("expire_seconds")]
        public int ExpireSeconds { get; set; }

        /// <summary>
        ///     二维码图片解析后的地址，开发者可根据该地址自行生成需要的二维码图片
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        public DateTime? ExpireTime
        {
            get
            {
                if (ExpireSeconds != 0)
                    return DateTime.Now.AddSeconds(ExpireSeconds);
                return null;
            }
        }
    }
}