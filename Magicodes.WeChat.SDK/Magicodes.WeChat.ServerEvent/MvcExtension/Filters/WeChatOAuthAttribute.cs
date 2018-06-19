// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatOAuthAttribute.cs
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
    using Magicodes.WeChat.SDK;
    using Magicodes.WeChat.SDK.Apis.Token;
    using Magicodes.WeChat.SDK.Helper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;

    /// <summary>
    /// 必须触发OAuth验证来获取粉丝信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class WeChatOAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private const string RedirectUrlCookieName = "Magicodes.Wechat_RedirectUrlCookie";
        private const string State = "magicodes.wechat";

        /// <summary>
        /// 仅获取OpenId
        /// </summary>
        public bool IsOnlyGetOpenId { get; set; }

        public WeChatOAuthAttribute() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isOnlyGetOpenId">仅获取OpenId</param>
        public WeChatOAuthAttribute(bool isOnlyGetOpenId)
        {
            IsOnlyGetOpenId = isOnlyGetOpenId;
        }

        /// <summary>
        /// The OnAuthorization
        /// </summary>
        /// <param name="context">The context<see cref="AuthorizationFilterContext"/></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            LoggerHelper.Debug(string.Format("Action:{0}正在获取授权并且获得粉丝信息。", context.ActionDescriptor.DisplayName));
            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var code = request.Query["code"];
            var state = request.Query["state"];
            var userAgent = request.Headers["User-Agent"].ToString().ToLower();
            //是否来自微信端请求
            if (!userAgent.Contains("micromessenger"))
            {
                context.Result = new ContentResult()
                {
                    Content = "不支持除微信浏览器以外的请求!",
                };
                return;
            }

            #region 如果是从微信验证页面跳转回来

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(state))
            {
                LoggerHelper.DebugFormat("根据授权Code获取粉丝信息。Code:{0}   State:{1} ...", code, state);

                var redirectUrlCookie = request.Cookies[RedirectUrlCookieName];
                if (string.IsNullOrEmpty(redirectUrlCookie)) return;
                var redirectUrl = redirectUrlCookie;
                if (IsOnlyGetOpenId)
                {
                    //通过code换取access_token,Code只能用一次
                    //网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
                    var result = WeChatApisContext.Current.OAuthApi.Get(code);
                    if (!result.IsSuccess())
                    {
                        if (result.ReturnCode == SDK.Apis.ReturnCodes.OAUTH授权码已被使用)
                        {
                            LoggerHelper.Warn(result.ReturnCode + "!正在重新跳转以进行授权！");
                            CreateRedirectUrl(context, httpContext);
                            return;
                        }
                        LoggerHelper.Error("授权出错，获取access_token失败！" + result.GetFriendlyMessage());
                        throw new Exception("授权出错，获取access_token失败！");
                    }
                    LoggerHelper.Debug("授权成功：" + result.DetailResult);
                    redirectUrl += (redirectUrl.Contains("?") ? "&" : "?") + "openId=" + result.OpenId;
                }
                else
                {
                    if (!redirectUrl.Contains("code="))
                    {
                        redirectUrl += (redirectUrl.Contains("?") ? "&" : "?") + "code=" + code;
                    }

                    if (!redirectUrl.Contains("state="))
                    {
                        redirectUrl += (redirectUrl.Contains("?") ? "&" : "?") + "state=" + state;
                    }
                }

                httpContext.Response.Cookies.Delete(RedirectUrlCookieName);
                context.Result = new RedirectResult(redirectUrl);
            }

            #endregion

            #region 如果没有验证，则进行验证

            else
            {

                CreateRedirectUrl(context, httpContext);
            }

            #endregion
        }

        /// <summary>
        /// 生成授权跳转Url
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        private void CreateRedirectUrl(AuthorizationFilterContext context, Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            LoggerHelper.DebugFormat("即将跳转到微信服务器来并授权获取粉丝信息");
            string redirectUrl = httpContext.Request.Query["redirectUrl"];
            string state = httpContext.Request.Query["state"];
            if (string.IsNullOrWhiteSpace(redirectUrl))
            {
                redirectUrl = httpContext.Request.GetDisplayUrl();
            }
            //已获取授权
            if (!redirectUrl.ToLower().Contains("openid="))
            {
                httpContext.Response.Cookies.Append(RedirectUrlCookieName, redirectUrl);
                //获取授权Url
                var url = WeChatApisContext.Current.OAuthApi.GetAuthorizeUrl(redirectUrl, state ?? State);
                LoggerHelper.Debug(string.Format("跳转至微信服务器获取授权...\n{0}\n{1}", redirectUrl, url));
                context.Result = new RedirectResult(url);
            }
            else
            {
                context.Result = new RedirectResult(redirectUrl);
            }
        }
    }
}
