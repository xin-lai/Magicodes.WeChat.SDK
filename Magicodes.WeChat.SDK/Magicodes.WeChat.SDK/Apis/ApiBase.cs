// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ApiBase.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;
using Magicodes.Logger;
using Magicodes.WeChat.SDK.Helper;
using Newtonsoft.Json;
using System.IO;

namespace Magicodes.WeChat.SDK.Apis
{
    public class ApiBase
    {
        /// <summary>
        ///     微信API地址
        /// </summary>
        protected const string ApiRoot = "https://api.weixin.qq.com/cgi-bin";

        protected object Key;

        /// <summary>
        ///     日志记录
        /// </summary>
        protected LoggerBase Logger = WeChatHelper.ApiLogger;

        /// <summary>
        ///     接口访问凭据
        /// </summary>
        protected string AccessToken
        {
            get
            {
                return WeChatConfigManager.Current.GetAccessToken(GetKey());
            }
        }

        /// <summary>
        ///     获取微信配置
        /// </summary>
        public IWeChatConfig AppConfig
        {
            get { return WeChatConfigManager.Current.GetConfig(GetKey()); }
        }

        public void SetKey(object key)
        {
            Key = key;
        }

        public object GetKey()
        {
            return Key;
        }

        /// <summary>
        ///     获取API访问Url
        /// </summary>
        /// <param name="apiAction">操作名</param>
        /// <param name="apiName">API名称</param>
        /// <param name="apiRoot">API根路径</param>
        /// <param name="urlParams">url参数</param>
        /// <returns>API地址</returns>
        protected string GetAccessApiUrl(string apiAction, string apiName, string apiRoot = ApiRoot,
            Dictionary<string, string> urlParams = null)
        {
            var paramsStr = string.Empty;
            if ((urlParams != null) && (urlParams.Count > 0))
                foreach (var item in urlParams)
                    paramsStr += string.Format("&{0}={1}", item.Key, item.Value);
            var urlMain = string.IsNullOrEmpty(apiAction) ? apiName : string.Format("{0}/{1}", apiName, apiAction);
            return string.Format("{0}/{1}?access_token={2}{3}", apiRoot, urlMain, AccessToken, paramsStr);
        }

        /// <summary>
        ///     获取请求JSON
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns>JSON字符串</returns>
        private string Get(string url)
        {
            Logger.LogFormat(LoggerLevels.Trace, "pre Get{1}url:{0}", url, Environment.NewLine);
            var wr = new WeChatApiWebRequestHelper();
            var result = wr.HttpGet(url);
            Logger.LogFormat(LoggerLevels.Trace, "Get success {2}url:{0}{2}result:{1}", url, result,
                Environment.NewLine);
            return result;
        }

        /// <summary>
        ///     POST提交请求，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="obj">提交的数据对象</param>
        /// <returns>ApiResult对象</returns>
        protected T Post<T>(string url, object obj, Func<string, string> serializeStrFunc = null) where T : ApiResult
        {
            var wr = new WeChatApiWebRequestHelper();
            string resultStr = null;
            var result = wr.HttpPost<T>(url, obj, out resultStr);
            if (result != null)
                result.DetailResult = resultStr;
            RefreshAccessTokenWhenTimeOut(result);
            return result;
        }

        protected T Post<T>(string url, object obj, Stream fileStream, Func<string, string> serializeStrFunc = null) where T : ApiResult
        {
            var wr = new WeChatApiWebRequestHelper();
            string resultStr = null;
            var result = wr.HttpPost<T>(url, obj, out resultStr);

            if (result != null)
                result.DetailResult = resultStr;
            RefreshAccessTokenWhenTimeOut(result);
            return result;
        }

        private void RefreshAccessTokenWhenTimeOut<T>(T result) where T : ApiResult
        {
            if ((result.ReturnCode == ReturnCodes.access_token超时) ||
                (result.ReturnCode == ReturnCodes.获取access_token时AppSecret错误或者access_token无效))
                WeChatConfigManager.Current.RefreshAccessToken(Key);
        }

        /// <summary>
        ///     POST提交请求，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="jsonData">提交的数据</param>
        /// <returns>ApiResult对象</returns>
        protected T Post<T>(string url, string jsonData) where T : ApiResult
        {
            var wr = new WeChatApiWebRequestHelper();

            Logger.LogFormat(LoggerLevels.Trace, "Pre POST Url:{0}；JSON：{1}；", url, jsonData);
            var result = wr.HttpPost(url, jsonData);
            var obj = JsonConvert.DeserializeObject<T>(result);
            if (obj != null)
                obj.DetailResult = result;
            RefreshAccessTokenWhenTimeOut(obj);
            return obj;
        }
        /// <summary>
        ///     POST提交请求，上传文件，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="fileStream">文件流</param>
        /// <returns></returns>
        protected T Post<T>(string url, string fileName, Stream fileStream) where T : ApiResult
        {
            var wr = new WeChatApiWebRequestHelper();
            string result = null;
            var obj = wr.HttpPost<T>(url, fileName, fileStream, out result);
            if (obj != null)
                obj.DetailResult = result;
            RefreshAccessTokenWhenTimeOut(obj);
            return obj;
        }


        /// <summary>
        ///     GET提交请求，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <returns>ApiResult对象</returns>
        protected T Get<T>(string url) where T : ApiResult
        {
            var result = Get(url);
            var obj = JsonConvert.DeserializeObject<T>(result);
            if (obj != null)
                obj.DetailResult = result;
            RefreshAccessTokenWhenTimeOut(obj);
            return obj;
        }

        /// <summary>
        ///     GET提交请求，返回ApiResult对象
        /// </summary>
        /// <typeparam name="T">ApiResult对象</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="jsonConverts">Json转换器</param>
        /// <returns>ApiResult对象</returns>
        protected T Get<T>(string url, params JsonConverter[] jsonConverts) where T : ApiResult
        {
            var result = Get(url);
            var obj = JsonConvert.DeserializeObject<T>(result, jsonConverts);
            if (obj != null)
                obj.DetailResult = result;
            RefreshAccessTokenWhenTimeOut(obj);
            return obj;
        }
    }
}