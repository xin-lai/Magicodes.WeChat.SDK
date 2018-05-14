using Magicodes.WeChat.MiniProgram.Apis.Profile.Dto;
using Magicodes.WeChat.MiniProgram.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Profile
{
    /// <summary>
    /// 个人信息获取
    /// </summary>
    public class ProfileApi : ApiBase
    {
        /// <summary>
        /// 获取解密的手机号码
        /// </summary>
        /// <param name="encryptedData">包括敏感数据在内的完整用户信息的加密数据</param>
        /// <param name="iv">加密算法的初始向量</param>
        /// <param name="sessionKey">会话密钥</param>
        /// <returns></returns>
        public GetPhoneNumberOutput GetPhoneNumber(string encryptedData, string iv, string sessionKey)
        {
            if (string.IsNullOrWhiteSpace(encryptedData))
            {
                throw new ArgumentException("参数不能为空!", nameof(encryptedData));
            }

            if (string.IsNullOrWhiteSpace(iv))
            {
                throw new ArgumentException("参数不能为空!", nameof(iv));
            }

            if (string.IsNullOrWhiteSpace(sessionKey))
            {
                throw new ArgumentException("参数不能为空!", nameof(sessionKey));
            }

            var result = EncryUtilHelper.MiniProgramDataDecrypt(encryptedData, iv, sessionKey);
            return JsonConvert.DeserializeObject<GetPhoneNumberOutput>(result);
        }
    }
}
