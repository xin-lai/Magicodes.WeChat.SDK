// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MD5UtilHelper.cs
//          description :
//  
//          created by 李文强 at  2018/04/10 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Security.Cryptography;
using System.Text;

namespace Magicodes.WeChat.MiniProgram.Helper
{
    /// <summary>
    ///     MD5UtilHelper 的摘要说明。
    /// </summary>
    public class EncryUtilHelper
    {
        /// <summary>
        ///     获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, string charset)
        {
            string retStr;
            var m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }

        /// <summary>
        /// 根据微信小程序平台提供的解密算法解密数据  
        /// </summary>
        /// <param name="encryptedData"></param>
        /// <param name="iv"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public static string MiniProgramDataDecrypt(string encryptedData, string iv, string sessionKey)
        {
            //创建解密器生成工具实例  
            var aes = new AesCryptoServiceProvider
            {
                //设置解密器参数  
                Mode = CipherMode.CBC,
                BlockSize = 128,
                Padding = PaddingMode.PKCS7
            };
            //格式化待处理字符串  
            var byte_encryptedData = Convert.FromBase64String(encryptedData);
            var byte_iv = Convert.FromBase64String(iv);
            var byte_sessionKey = Convert.FromBase64String(sessionKey);

            aes.IV = byte_iv;
            aes.Key = byte_sessionKey;
            //根据设置好的数据生成解密器实例  
            using (var transform = aes.CreateDecryptor())
            {
                //解密  
                var final = transform.TransformFinalBlock(byte_encryptedData, 0, byte_encryptedData.Length);

                //获取结果  
                return Encoding.UTF8.GetString(final);
            }
        }
    }
}