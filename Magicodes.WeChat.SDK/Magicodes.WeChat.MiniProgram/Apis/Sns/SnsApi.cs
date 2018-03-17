using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.WeChat.MiniProgram.Apis.Sns.Dto;

namespace Magicodes.WeChat.MiniProgram.Apis.Sns
{
    public class SnsApi : ApiBase
    {
        private const string ApiName = "sns";
        /// <summary>
        /// 根据登录凭证获取Sns信息（openid、session_key、unionid）
        /// </summary>
        /// <param name="code">登录时获取的 code</param>
        public GetSnsInfoByCodeOutput GetSnsInfoByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("message", nameof(code));
            }
            //获取api请求url
            var url = $"{ApiRoot}/{ApiName}/jscode2session?appid={AppConfig.AppId}&secret={AppConfig.AppSecret}&js_code={code}&grant_type=authorization_code";
            return Get<GetSnsInfoByCodeOutput>(url);
        }
    }
}
