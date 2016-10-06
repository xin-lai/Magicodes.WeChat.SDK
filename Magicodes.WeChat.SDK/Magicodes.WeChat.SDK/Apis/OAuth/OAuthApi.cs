// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : OAuthApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/26 16:48
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Magicodes.WeChat.SDK.Apis.OAuth;

namespace Magicodes.WeChat.SDK.Apis.Token
{
    /// <summary>
    ///     OAUTH验证接口
    /// </summary>
    public class OAuthApi : ApiBase
    {
        private const string ApiName = "oauth2";

        /// <summary>
        ///     获取oauthAccessToken
        /// </summary>
        /// <returns></returns>
        public OAuthTokenApiResult Get(string code)
        {
            var url = string.Format("https://api.weixin.qq.com/sns/{0}?grant_type=authorization_code&appid={1}&secret={2}&code={3}", ApiName, AppConfig.AppId, AppConfig.AppSecret, code);
            var result = Get<OAuthTokenApiResult>(url);
            result.ExpiresTime = DateTime.Now.AddSeconds(result.Expires - 30);
            return result;
        }

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="oauthAccessToken">网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同</param>
        /// <param name="openId">用户的唯一标识</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public GetUserInfoApiResult GetUserInfo(string oauthAccessToken, string openId, string lang = "zh_CN")
        {
            var url = string.Format("https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}", oauthAccessToken, openId, lang);
            var result = Get<GetUserInfoApiResult>(url);
            return result;
        }

        public void Update()
        {
            //var url = string.Format("{0}/{1}?grant_type=refresh_token&appid={2}&secret={3}&refresh_token=", "https://api.weixin.qq.com/sns", ApiName,
            //    AppConfig.AppId, AppConfig.AppSecret);
            //var result = Get<OAuthTokenApiResult>(url);
            //result.ExpiresTime = DateTime.Now.AddSeconds(result.Expires - 30);

        }
    }
}