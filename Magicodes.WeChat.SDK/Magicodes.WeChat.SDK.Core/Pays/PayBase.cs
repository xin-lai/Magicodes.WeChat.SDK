// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : PayBase.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Pays
{
    using Magicodes.WeChat.SDK.Helper;
    using System;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Defines the <see cref="PayBase" />
    /// </summary>
    public class PayBase
    {
        /// <summary>
        /// Defines the Key
        /// </summary>
        protected object Key;

        /// <summary>
        /// Gets the PayConfig
        /// 获取微信配置
        /// </summary>
        public IWeChatPayConfig PayConfig => Key == null
            ? WeChatConfigManager.Current.GetPayConfig()
            : WeChatConfigManager.Current.GetPayConfig(Key);

        /// <summary>
        /// Gets the WeChatConfig
        /// </summary>
        public IWeChatConfig WeChatConfig => Key == null
            ? WeChatConfigManager.Current.GetConfig()
            : WeChatConfigManager.Current.GetConfig(Key);

        /// <summary>
        /// The SetKey
        /// </summary>
        /// <param name="key">The key<see cref="object"/></param>
        public void SetKey(object key)
        {
            Key = key;
        }

        /// <summary>
        /// The GetKey
        /// </summary>
        /// <returns>The <see cref="object"/></returns>
        public object GetKey()
        {
            return Key;
        }

        /// <summary>
        /// POST提交请求，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="obj">提交的数据对象</param>
        /// <param name="serializeStrFunc">The serializeStrFunc<see cref="Func{string, string}"/></param>
        /// <returns>ApiResult对象</returns>
        protected T PostXML<T>(string url, object obj, Func<string, string> serializeStrFunc = null) where T : PayResult
        {
            var wr = new WeChatApiWebRequestHelper();
            string resultStr = null;
            var result = wr.HttpPost<T>(url, obj, out resultStr, serializeStrFunc,
                WebRequestDataTypes.XML, WebRequestDataTypes.XML);
            if (result != null)
                result.DetailResult = resultStr;
            return result;
        }

        /// <summary>
        /// POST提交请求，带证书，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="obj">提交的数据对象</param>
        /// <param name="cer">The cer<see cref="X509Certificate2"/></param>
        /// <param name="serializeStrFunc">The serializeStrFunc<see cref="Func{string, string}"/></param>
        /// <returns>ApiResult对象</returns>
        protected T PostXML<T>(string url, object obj, X509Certificate2 cer,
            Func<string, string> serializeStrFunc = null) where T : PayResult
        {
            var wr = new WeChatApiWebRequestHelper();
            string resultStr = null;
            var result = wr.HttpPost<T>(url, obj, cer, out resultStr, serializeStrFunc,
                WebRequestDataTypes.XML, WebRequestDataTypes.XML);
            if (result != null)
                result.DetailResult = resultStr;
            return result;
        }
    }
}
