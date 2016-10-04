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

using System;
using System.Security.Cryptography.X509Certificates;
using Magicodes.Logger;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Pays
{
    public class PayBase
    {
        protected object Key;

        /// <summary>
        ///     日志记录
        /// </summary>
        protected LoggerBase Logger = WeChatHelper.PayLogger;

        /// <summary>
        ///     获取微信配置
        /// </summary>
        public IWeChatPayConfig PayConfig => Key == null
            ? WeChatConfigManager.Current.GetPayConfig()
            : WeChatConfigManager.Current.GetPayConfig(Key);

        public IWeChatConfig WeChatConfig => Key == null
            ? WeChatConfigManager.Current.GetConfig()
            : WeChatConfigManager.Current.GetConfig(Key);

        public void SetKey(object key)
        {
            Key = key;
        }

        public object GetKey()
        {
            return Key;
        }


        /// <summary>
        ///     POST提交请求，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="obj">提交的数据对象</param>
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
        ///     POST提交请求，带证书，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="obj">提交的数据对象</param>
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