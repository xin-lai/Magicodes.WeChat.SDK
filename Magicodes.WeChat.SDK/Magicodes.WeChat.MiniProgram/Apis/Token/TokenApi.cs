using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.WeChat.MiniProgram.Apis.Token.Dto;
using Magicodes.WeChat.MiniProgram;

namespace Magicodes.WeChat.MiniProgram.Apis.Token
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenApi : ApiBase
    {
        /// <summary>
        /// 获取Accesstoken
        /// </summary>
        /// <param name="config">小程序配置，为NULL则自动获取默认</param>
        /// <returns></returns>
        public IAccesstokenInfo Get(IMiniProgramConfig config = null)
        {
            config = config ?? AppConfig;
            //判断Accesstoken是否从其他函数中获取，比如中控服务器
            if (MiniProgramConfigManager.Current.GetAccessTokenFunc != null)
            {
                var token = MiniProgramConfigManager.Current.GetAccessTokenFunc(config);
                MiniProgramConfigManager.Current.AccessTokenConcurrentDictionary.AddOrUpdate(config.MiniProgramAppId, token,
                    (tKey, existingVal) => token);
                return token;
            }

            if (config == null)
                throw new MiniProgramArgumentException("没有找到小程序配置信息，请配置！");
            var url = $"{ApiRoot}/cgi-bin/token?grant_type=client_credential&appid={config.MiniProgramAppId}&secret={config.MiniProgramAppSecret}";
            var result = Get<GetAccesstokenOutput>(url);
            if (!result.IsSuccess())
                throw new MiniProgramArgumentException("获取接口访问凭据失败：" + result.GetFriendlyMessage() + "（" + result.DetailResult + "）");
            result.ExpiresTime = DateTime.Now.AddSeconds(result.Expires - 30);

            //存储
            MiniProgramConfigManager.Current.AccessTokenConcurrentDictionary.AddOrUpdate(config.MiniProgramAppId, result,
                    (tKey, existingVal) => result);
            return result;
        }

        /// <summary>
        ///     安全获取AccessToken
        /// </summary>
        /// <returns></returns>
        public IAccesstokenInfo SafeGet(IMiniProgramConfig config = null)
        {
            config = config ?? AppConfig;
            if (MiniProgramConfigManager.Current.AccessTokenConcurrentDictionary.ContainsKey(config.MiniProgramAppId))
            {
                var token = MiniProgramConfigManager.Current.AccessTokenConcurrentDictionary[config.MiniProgramAppId];
                //判断Token是否过期
                if (DateTime.Now < token.ExpiresTime)
                    return token;
            }
            return Get();
        }
    }
}
