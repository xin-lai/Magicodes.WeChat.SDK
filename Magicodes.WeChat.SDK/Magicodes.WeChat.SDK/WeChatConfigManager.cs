// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatConfigManager.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 16:33
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Concurrent;
using System.Web;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     微信配置管理对象
    /// </summary>
    public class WeChatConfigManager
    {
        private const string KEYNAME = "WeChatConfigManager_Key";

        private static readonly Lazy<WeChatConfigManager> Lazy =
            new Lazy<WeChatConfigManager>(() => new WeChatConfigManager());

        protected ConcurrentDictionary<object, IWeChatConfig> WeChatConfigs =
            new ConcurrentDictionary<object, IWeChatConfig>();

        /// <summary>
        ///     微信支付配置信息
        /// </summary>
        protected ConcurrentDictionary<object, IWeChatPayConfig> WeChatPayConfigs =
            new ConcurrentDictionary<object, IWeChatPayConfig>();

        public static WeChatConfigManager Current => Lazy.Value;

        /// <summary>
        ///     微信AppId
        /// </summary>
        public string AppId
        {
            get { return GetConfig().AppId; }
        }

        /// <summary>
        ///     接口访问密钥
        /// </summary>
        public string AppSecret
        {
            get { return GetConfig().AppSecret; }
        }

        /// <summary>
        ///     微信号
        /// </summary>
        public string WeiXinAccount
        {
            get { return GetConfig().WeiXinAccount; }
        }

        /// <summary>
        ///     接口访问凭据
        /// </summary>
        public string AccessToken => WeChatApisContext.Current.TokenApi.SafeGet().AccessToken;

        /// <summary>
        ///     设置配置Key，以便获取相关配置
        /// </summary>
        /// <param name="key"></param>
        public void SetKey(object key)
        {
            var context = HttpContext.Current;
            if (context == null)
                throw new HttpException("SetKey只能在当前请求线程中使用！");
            context.Session[KEYNAME] = key;
        }

        public object GetKey()
        {
            var context = HttpContext.Current;
            if (context == null)
                throw new HttpException("GetKey只能在当前请求线程中使用！");
            return context.Session[KEYNAME];
        }

        public IWeChatConfig GetConfig()
        {
            return GetConfig(GetKey());
        }

        public IWeChatPayConfig GetPayConfig()
        {
            return GetPayConfig(GetKey());
        }

        /// <summary>
        ///     获取支付配置
        /// </summary>
        /// <param name="key">唯一Key</param>
        /// <returns></returns>
        public IWeChatPayConfig GetPayConfig(object key)
        {
            if (key == null)
                throw new Exception("Key不能为NULL！");
            if (WeChatPayConfigs.ContainsKey(key))
                return WeChatPayConfigs[key];
            var result =
                WeChatFrameworkFuncsManager.Current.InvokeFunc(
                    WeChatFrameworkFuncTypes.Config_GetWeChatPayConfigByKey, new WeChatPayCallbackFuncArgInfo
                    {
                        Api = null,
                        Data = key
                    });
            if (result == null) throw new Exception(string.Format("通过Key：{0}获取Config失败！", key));
            var weChatConfig = result as IWeChatPayConfig;
            WeChatPayConfigs.AddOrUpdate(key, weChatConfig, (tKey, existingVal) => weChatConfig);
            return weChatConfig;
        }

        /// <summary>
        ///     获取配置
        /// </summary>
        /// <param name="key">唯一Key</param>
        /// <returns></returns>
        public IWeChatConfig GetConfig(object key)
        {
            if (key == null)
                throw new Exception("Key不能为NULL！");
            if (WeChatConfigs.ContainsKey(key))
                return WeChatConfigs[key];
            var result =
                WeChatFrameworkFuncsManager.Current.InvokeFunc(WeChatFrameworkFuncTypes.Config_GetWeChatConfigByKey,
                    new WeChatApiCallbackFuncArgInfo
                    {
                        Api = null,
                        Data = key
                    });
            if (result == null) throw new Exception(string.Format("通过Key：{0}获取Config失败！", key));
            var weChatConfig = result as IWeChatConfig;
            WeChatConfigs.AddOrUpdate(key, weChatConfig, (tKey, existingVal) => weChatConfig);
            return weChatConfig;
        }

        /// <summary>
        ///     获取当前页面JS配置信息
        /// </summary>
        /// <returns></returns>
        public JSSDKConfigInfo GetJSSDKConfigInfo()
        {
            var ticket = WeChatApisContext.Current.TicketApi.SafeGet().Ticket;
            var configInfo = new JSSDKConfigInfo
            {
                AppId = AppId,
                Timestamp = JSSDKHelper.GetTimestamp(),
                NonceStr = JSSDKHelper.GetNoncestr()
            };
            configInfo.Signature = JSSDKHelper.GetSignature(ticket, configInfo.NonceStr, configInfo.Timestamp,
                HttpContext.Current.Request.Url.AbsoluteUri);
            return configInfo;
        }

        /// <summary>
        ///     接口访问凭据
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public string GetAccessToken(string appId, string appSecret)
        {
            return WeChatApisContext.Current.TokenApi.SafeGet().AccessToken;
        }

        /// <summary>
        ///     刷新访问凭据
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        public void RefreshAccessToken(string appId, string appSecret)
        {
            WeChatApisContext.Current.TokenApi.Update();
        }

        /// <summary>
        ///     刷新配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="config"></param>
        public void RefreshConfig(object key, IWeChatConfig config)
        {
            WeChatConfigs.AddOrUpdate(key, config, (tKey, existingVal) => { return config; });
        }

        /// <summary>
        ///     刷新配置以及访问凭据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="config"></param>
        public void RefreshConfigAndAccessToken(object key, IWeChatConfig config)
        {
            RefreshConfig(key, config);
            RefreshAccessToken(config.AppId, config.AppSecret);
        }
    }
}