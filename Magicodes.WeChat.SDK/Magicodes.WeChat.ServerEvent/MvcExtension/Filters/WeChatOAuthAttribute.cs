using System;
using Abp.Dependency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Magicodes.WeChat.Web.Core.MvcExtension.Filters
{
    /// <summary>
    /// 必须触发OAuth验证来获取粉丝信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class WeChatOAuthAttribute : AuthorizeAttribute, IAuthorizationFilter, ITransientDependency
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}