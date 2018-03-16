using System;

namespace Magicodes.WeChat.MiniProgram.Apis.Token.Dto
{
    public interface IAccesstokenInfo
    {
        /// <summary>
        /// 
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        ///     凭证有效时间，单位：秒
        /// </summary>
        int Expires { get; set; }

        /// <summary>
        /// 凭证过期时间
        /// </summary>
        DateTime ExpiresTime { get; set; }
    }
}