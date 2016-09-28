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
    ///     客服接口
    /// </summary>
    public class OAuthApi : ApiBase
    {
        private const string ApiName = "oauth2";

        /// <summary>
        ///     获取AccessToken
        /// </summary>
        /// <returns></returns>
        public OAuthTokenApiResult Get()
        {
            var url = string.Format("{0}/{1}?grant_type=authorization_code&appid={2}&secret={3}", "https://api.weixin.qq.com/sns", ApiName,
                AppConfig.AppId, AppConfig.AppSecret);
            var result = Get<OAuthTokenApiResult>(url);
            result.ExpiresTime = DateTime.Now.AddSeconds(result.Expires - 30);
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