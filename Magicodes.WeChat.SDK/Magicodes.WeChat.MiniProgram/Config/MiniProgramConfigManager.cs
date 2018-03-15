// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatConfigManager.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Concurrent;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     微信配置管理对象
    /// </summary>
    public class MiniProgramConfigManager
    {
        private static readonly Lazy<MiniProgramConfigManager> Lazy =
            new Lazy<MiniProgramConfigManager>(() => new MiniProgramConfigManager());

        /// <summary>
        /// 根据key获取配置
        /// </summary>
        internal static Func<string, IMiniProgramConfig> GetConfigByKeyFunc { get; set; }

        internal static Func<string> GetKeyFunc { get; set; }

        /// <summary>
        ///     公众号配置信息
        /// </summary>
        protected ConcurrentDictionary<string, IMiniProgramConfig> MiniProgramConfigs =
            new ConcurrentDictionary<string, IMiniProgramConfig>();

        /// <summary>
        /// 
        /// </summary>
        public static MiniProgramConfigManager Current => Lazy.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetKey() => GetKeyFunc();

        /// <summary>
        ///     获取配置
        /// </summary>
        /// <param name="key">唯一Key</param>
        /// <returns></returns>
        public IMiniProgramConfig GetConfig(string key = null)
        {
            if (key == null)
                key = GetKey();
            if (key == null)
                throw new Exception("Key不能为NULL！");

            IMiniProgramConfig weChatConfig = null;
            if (MiniProgramConfigs.ContainsKey(key))
                weChatConfig = MiniProgramConfigs[key];
            if (weChatConfig != null)
                return weChatConfig;
            var result =
                GetConfigByKeyFunc(key);

            weChatConfig = result as IMiniProgramConfig ?? throw new Exception(string.Format("通过Key：{0}获取Config失败！", key));
            if (weChatConfig == null)
                throw new MiniProgramArgumentException("获取微信配置失败。Key:" + key);
            if (string.IsNullOrWhiteSpace(weChatConfig.AppId))
                throw new MiniProgramArgumentException("微信配置错误，参数不能为空。Key:" + key, "AppId");
            if (string.IsNullOrWhiteSpace(weChatConfig.AppSecret))
                throw new MiniProgramArgumentException("微信配置错误，参数不能为空。Key:" + key, "AppSecret");
            MiniProgramConfigs.AddOrUpdate(key, weChatConfig, (tKey, existingVal) => weChatConfig);
            return weChatConfig;
        }

        /// <summary>
        ///     接口访问凭据
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken(object key = null)
        {
            //if (key == null)
            //    return WeChatApisContext.Current.TokenApi.SafeGet().AccessToken;
            //var api = new TokenApi();
            //api.SetKey(key);
            //return api.SafeGet().AccessToken;
            return null;
        }

        /// <summary>
        ///     刷新访问凭据
        /// </summary>
        public void RefreshAccessToken(object key = null)
        {
            //if (key == null)
            //{
            //    WeChatApisContext.Current.TokenApi.Update();
            //    return;
            //}
            //var api = new TokenApi();
            //api.SetKey(key);
            //api.Update();
        }

        /// <summary>
        ///     刷新配置
        /// </summary>
        /// <param name="key">存储配置key</param>
        /// <param name="config">微信配置</param>
        public void RefreshConfig(string key, IMiniProgramConfig config)
        {
            MiniProgramConfigs.AddOrUpdate(key, config, (tKey, existingVal) => { return config; });
        }

        
        /// <summary>
        ///     刷新配置以及访问凭据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="config"></param>
        public void RefreshConfigAndAccessToken(string key, IMiniProgramConfig config)
        {
            RefreshConfig(key, config);
            RefreshAccessToken(key);
        }
    }
}