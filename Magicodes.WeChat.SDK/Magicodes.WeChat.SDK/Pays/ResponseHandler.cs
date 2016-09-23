// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ResponseHandler.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Pays
{
    /** 
    '============================================================================
    'Api说明：
    'GetKey()/setKey(),获取/设置密钥
    'GetParameter()/setParameter(),获取/设置参数值
    'GetAllParameters(),获取所有参数
    'IsTenpaySign(),是否正确的签名,true:是 false:否
    'IsWXsign(),是否正确的签名,true:是 false:否
    ' * IsWXsignfeedback判断微信维权签名
    ' *GetDebugInfo(),获取debug信息 
    '============================================================================
    */

    public class ResponseHandler
    {
        /// <summary>
        ///     xmlMap
        /// </summary>
        private readonly Hashtable XmlMap;

        /// <summary>
        ///     appkey
        /// </summary>
        private string Appkey;

        private string Charset = "gb2312";

        /// <summary>
        ///     原始内容
        /// </summary>
        protected string Content;

        /// <summary>
        ///     debug信息
        /// </summary>
        private string DebugInfo;

        protected HttpContext HttpContext;

        /// <summary>
        ///     密钥
        /// </summary>
        private string Key;

        /// <summary>
        ///     应答的参数
        /// </summary>
        protected Hashtable Parameters;

        /// <summary>
        ///     获取页面提交的get和post参数
        /// </summary>
        /// <param name="httpContext"></param>
        public ResponseHandler(HttpContext httpContext)
        {
            Parameters = new Hashtable();
            XmlMap = new Hashtable();

            HttpContext = httpContext ?? HttpContext.Current;
            NameValueCollection collection;
            //post data
            if (HttpContext.Request.HttpMethod == "POST")
            {
                collection = HttpContext.Request.Form;
                foreach (string k in collection)
                {
                    var v = collection[k];
                    SetParameter(k, v);
                }
            }
            //query string
            collection = HttpContext.Request.QueryString;
            foreach (string k in collection)
            {
                var v = collection[k];
                SetParameter(k, v);
            }
            if (HttpContext.Request.InputStream.Length > 0)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Request.InputStream);
                var root = xmlDoc.SelectSingleNode("xml");
                var xnl = root.ChildNodes;

                foreach (XmlNode xnf in xnl)
                {
                    XmlMap.Add(xnf.Name, xnf.InnerText);
                    SetParameter(xnf.Name, xnf.InnerText);
                }
            }
        }

        /// <summary>
        ///     初始化函数
        /// </summary>
        public virtual void Init()
        {
        }


        /// <summary>
        ///     获取密钥
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            return Key;
        }

        /// <summary>
        ///     设置密钥
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(string key)
        {
            Key = key;
        }

        /// <summary>
        ///     获取参数值
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public string GetParameter(string parameter)
        {
            var s = (string) Parameters[parameter];
            return s ?? "";
        }

        /// <summary>
        ///     设置参数值
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="parameterValue"></param>
        public void SetParameter(string parameter, string parameterValue)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                if (Parameters.Contains(parameter))
                    Parameters.Remove(parameter);

                Parameters.Add(parameter, parameterValue);
            }
        }

        /// <summary>
        ///     是否财付通签名,规则是:按参数名称a-z排序,遇到空值的参数不参加签名。return boolean
        /// </summary>
        /// <returns></returns>
        public virtual bool IsTenpaySign()
        {
            var sb = new StringBuilder();

            var akeys = new ArrayList(Parameters.Keys);
            akeys.Sort();

            foreach (string k in akeys)
            {
                var v = (string) Parameters[k];
                if ((null != v) && ("".CompareTo(v) != 0)
                    && ("sign".CompareTo(k) != 0) && ("key".CompareTo(k) != 0))
                    sb.Append(k + "=" + v + "&");
            }

            sb.Append("key=" + GetKey());
            var sign = MD5UtilHelper.GetMD5(sb.ToString(), GetCharset()).ToLower();
            SetDebugInfo(sb + " &sign=" + sign);
            //debug信息
            return GetParameter("sign").ToLower().Equals(sign);
        }

        /// <summary>
        ///     获取debug信息
        /// </summary>
        /// <returns></returns>
        public string GetDebugInfo()
        {
            return DebugInfo;
        }

        /// <summary>
        ///     设置debug信息
        /// </summary>
        /// <param name="debugInfo"></param>
        protected void SetDebugInfo(string debugInfo)
        {
            DebugInfo = debugInfo;
        }

        protected virtual string GetCharset()
        {
            return HttpContext.Request.ContentEncoding.BodyName;
        }

        /// <summary>
        ///     输出XML
        /// </summary>
        /// <returns></returns>
        public string ParseXML()
        {
            var sb = new StringBuilder();
            sb.Append("<xml>");
            foreach (string k in Parameters.Keys)
            {
                var v = (string) Parameters[k];
                if (Regex.IsMatch(v, @"^[0-9.]$"))
                    sb.Append("<" + k + ">" + v + "</" + k + ">");
                else
                    sb.Append("<" + k + "><![CDATA[" + v + "]]></" + k + ">");
            }
            sb.Append("</xml>");
            return sb.ToString();
        }
    }
}