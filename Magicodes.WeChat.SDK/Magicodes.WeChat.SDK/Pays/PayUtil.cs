// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : PayUtil.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Pays
{
    public static class PayUtil
    {
        /// <summary>
        ///     随机生成Noncestr
        /// </summary>
        /// <returns></returns>
        public static string GetNoncestr()
        {
            var random = new Random();
            return MD5UtilHelper.GetMD5(random.Next(1000).ToString(), "GBK");
        }

        /// <summary>
        ///     根据当前系统时间加随机序列来生成订单号
        /// </summary>
        /// <returns>订单号</returns>
        public static string GenerateOutTradeNo()
        {
            var ran = new Random();
            return string.Format("{0}{1}", UnixStamp(), ran.Next(999));
        }

        /// <summary>
        ///     获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        ///     对字符串进行URL编码
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string UrlEncode(string instr, string charset)
        {
            //return instr;
            if ((instr == null) || (instr.Trim() == ""))
                return "";
            string res;

            try
            {
                res = HttpUtility.UrlEncode(instr, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                res = HttpUtility.UrlEncode(instr, Encoding.GetEncoding("GB2312"));
            }


            return res;
        }

        /// <summary>
        ///     对字符串进行URL解码
        /// </summary>
        /// <param name="instr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string UrlDecode(string instr, string charset)
        {
            if ((instr == null) || (instr.Trim() == ""))
                return "";
            string res;

            try
            {
                res = HttpUtility.UrlDecode(instr, Encoding.GetEncoding(charset));
            }
            catch (Exception ex)
            {
                res = HttpUtility.UrlDecode(instr, Encoding.GetEncoding("GB2312"));
            }


            return res;
        }


        /// <summary>
        ///     取时间戳生成随即数,替换交易单号中的后10位流水号
        /// </summary>
        /// <returns></returns>
        public static uint UnixStamp()
        {
            var ts = DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return Convert.ToUInt32(ts.TotalSeconds);
        }

        /// <summary>
        ///     取随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string BuildRandomStr(int length)
        {
            var rand = new Random();

            var num = rand.Next();

            var str = num.ToString();

            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            else if (str.Length < length)
            {
                var n = length - str.Length;
                while (n > 0)
                {
                    str.Insert(0, "0");
                    n--;
                }
            }

            return str;
        }

        /// <summary>
        ///     循环获取一个实体类每个字段的XmlAttribute属性的值
        /// </summary>
        /// <typeparam name="T"><peparam>
        /// <returns></returns>
        public static Dictionary<string, string> GetAuthors<T>(T model)
        {
            var _dict = new Dictionary<string, string>();

            var type = model.GetType(); //获取类型

            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var authAttr = attr as XmlElementAttribute;
                    if (authAttr != null)
                    {
                        var auth = authAttr.ElementName;

                        var property = type.GetProperty(prop.Name);
                        var value = property.GetValue(model, null); //获取属性值
                        _dict.Add(auth, value?.ToString());
                    }
                }
            }
            return _dict;
        }

        /// <summary>
        ///     创建md5摘要,规则是:按参数名称a-z排序,遇到空值的参数不参加签名
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        /// key和value通常用于填充最后一组参数
        /// <returns></returns>
        public static string CreateMd5Sign(Dictionary<string, string> dict, string value)
        {
            var akeys = new ArrayList();
            foreach (var x in dict)
            {
                if ("sign".CompareTo(x.Key) == 0)
                    continue;
                akeys.Add(x.Key);
            }
            var sb = new StringBuilder();
            akeys.Sort();

            foreach (string k in akeys)
            {
                var v = dict[k];
                if ((null != v) && ("".CompareTo(v) != 0)
                    && ("sign".CompareTo(k) != 0) && ("key".CompareTo(k) != 0))
                    sb.Append(k + "=" + v + "&");
            }
            sb.Append("key=" + value);
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
            var sbuilder = new StringBuilder();
            foreach (var b in bs)
                sbuilder.Append(b.ToString("x2"));
            //所有字符转为大写
            return sbuilder.ToString().ToUpper();
        }

        /// <summary>
        ///     接收post数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string PostInput(Stream stream)
        {
            var count = 0;
            var buffer = new byte[1024];
            var builder = new StringBuilder();
            while ((count = stream.Read(buffer, 0, 1024)) > 0)
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            return builder.ToString();
        }
    }
}