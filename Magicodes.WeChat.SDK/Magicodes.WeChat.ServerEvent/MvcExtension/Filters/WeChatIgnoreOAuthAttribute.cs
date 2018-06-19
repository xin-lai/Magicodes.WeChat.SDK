// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatIgnoreOAuthAttribute.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:55:22
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.Web.Core.MvcExtension.Filters
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    /// <summary>
    /// 不触发OAuth验证来获取粉丝信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class WeChatIgnoreOAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// The OnAuthorization
        /// </summary>
        /// <param name="context">The context<see cref="AuthorizationFilterContext"/></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
