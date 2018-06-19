// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatOauthController.cs
//          description :定义微信授权控制器,简化微信授权操作
//  
//          created by codelove1314@live.cn at  2018-06-19 14:41:01
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.ServerEvent.Controllers
{
    using Magicodes.WeChat.Web.Core.MvcExtension.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// 定义微信授权控制器,简化微信授权操作<see cref="WeChatOauthController" />
    /// </summary>
    [AllowAnonymous]
    [Route("WeChat/Oauth")]
    public class WeChatOauthController : Controller
    {
        /// <summary>
        /// 微信授权获取授权Code
        /// 将通过url参数返回code
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        [HttpGet("")]
        [WeChatOAuth]
        public ActionResult Oauth(string redirectUrl)
        {
            return Content("授权成功!");
        }

        /// <summary>
        /// 微信授权获取OpenId
        /// 将通过url参数返回openId
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        [HttpGet("OpenId")]
        [WeChatOAuth(IsOnlyGetOpenId = true)]
        public ActionResult OauthOnlyGetOpenId(string redirectUrl)
        {
            return Content("授权成功!");
        }
    }
}
