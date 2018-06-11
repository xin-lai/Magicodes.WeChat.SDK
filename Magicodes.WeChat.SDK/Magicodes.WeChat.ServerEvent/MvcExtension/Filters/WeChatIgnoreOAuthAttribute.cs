using System;
using Abp.Dependency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Magicodes.WeChat.Web.Core.MvcExtension.Filters
{
    /// <summary>
    /// 不触发OAuth验证来获取粉丝信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class WeChatIgnoreOAuthAttribute : AuthorizeAttribute, IAuthorizationFilter, ITransientDependency
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}