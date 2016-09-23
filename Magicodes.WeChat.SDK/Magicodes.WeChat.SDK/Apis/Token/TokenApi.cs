// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomMessageApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Magicodes.WeChat.SDK.Apis.CustomMessage;

namespace Magicodes.WeChat.SDK.Apis.Token
{
    /// <summary>
    ///     客服接口
    /// </summary>
    public class TokenApi : ApiBase
    {
        private const string ApiName = "token";
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public TokenApiResult Get()
        {
            var url = string.Format("{0}/{1}?grant_type=client_credential&appid={2}&secret={3}", ApiRoot, ApiName, AppConfig.AppId, AppConfig.AppSecret);
            var result = Get<TokenApiResult>(url);
            result.ExporesTime = DateTime.Now.AddSeconds(result.Expires - 30);
            return result;
        }
        /// <summary>
        /// 安全获取AccessToken
        /// </summary>
        /// <returns></returns>
        public TokenApiResult SafeGet()
        {
            var appConfig = AppConfig;
            TokenApiResult token;
            if (WeiChatApisContext.Current.AccessTokenConcurrentDictionary.ContainsKey(appConfig.AppId))
            {
                token = WeiChatApisContext.Current.AccessTokenConcurrentDictionary[appConfig.AppId];
                if (DateTime.Now < token.ExporesTime)
                    return token;
                token = Get();
                WeiChatApisContext.Current.AccessTokenConcurrentDictionary.AddOrUpdate(appConfig.AppId, token,
                    (tKey, existingVal) => token);
                return token;
            }
            token = Get();
            WeiChatApisContext.Current.AccessTokenConcurrentDictionary.AddOrUpdate(appConfig.AppId, token, (tKey, existingVal) => token);
            return token;
        }

        public void Update()
        {
            var appConfig = AppConfig;
            var token = Get();
            WeiChatApisContext.Current.AccessTokenConcurrentDictionary.AddOrUpdate(appConfig.AppId, token, (tKey, existingVal) => token);
        }

    }
}