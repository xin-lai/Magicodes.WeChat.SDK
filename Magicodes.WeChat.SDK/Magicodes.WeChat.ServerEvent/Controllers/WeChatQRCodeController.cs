// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatQRCodeController.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 13:52:08
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.ServerEvent.Controllers
{
    using Magicodes.WeChat.SDK;
    using Magicodes.WeChat.SDK.Helper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [AllowAnonymous]
    [Route("WeChat/QRCode")]
    public class WeChatQRCodeController : Controller
    {
        /// <summary>
        /// 根据key和Value显示二维码
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult> QRCode(string key, string value)
        {
            var result = WeChatApisContext.Current.QrCodeApi.
                CreateByStringValue(value, expireSeconds: 259200);
            if (result.IsSuccess())
            {
                var url = WeChatApisContext.Current.QrCodeApi.GetQrCodeUrl(result.Ticket);
                return Redirect(url);
            }
            else
            {
                LoggerHelper.Error("生成二维码失败:" + result.GetFriendlyMessage());
                return Content("无法生成二维码,请重试或联系管理员!");
            }
        }
    }
}
