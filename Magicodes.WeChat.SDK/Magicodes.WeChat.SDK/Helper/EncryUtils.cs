using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeiChat.Unity
{
    public static class EncryUtils
    {
        public static string GetWeChatMD5(this string encypStr)
        {
            return EncryUtils.MD5(encypStr, "GB2312");
        }

        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string MD5(string encypStr, string charset)
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

    }
}
