// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatConfigManager.cs
//          description :
//  
//          created by 李文强 at  2018/04/10 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Concurrent;
using Magicodes.WeChat.MiniProgram;
using Magicodes.WeChat.MiniProgram.Apis.Token;
using Magicodes.WeChat.MiniProgram.Apis.Token.Dto;
using Magicodes.WeChat.MiniProgram.Helper;

namespace Magicodes.WeChat.MiniProgram
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
        internal Func<string, IMiniProgramConfig> GetConfigByKeyFunc { get; set; }

        /// <summary>
        /// 获取配置Key
        /// </summary>
        internal Func<string> GetKeyFunc { get; set; }


        /// <summary>
        /// 获取AccessToken，比如从其他框架、接口、中控
        /// </summary>
        internal Func<IMiniProgramConfig, IAccesstokenInfo> GetAccessTokenFunc { get; set; }

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
        ///     访问凭据存储
        /// </summary>
        internal ConcurrentDictionary<string, IAccesstokenInfo> AccessTokenConcurrentDictionary =
            new ConcurrentDictionary<string, IAccesstokenInfo>();

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
            if (string.IsNullOrWhiteSpace(weChatConfig.MiniProgramAppId))
                throw new MiniProgramArgumentException("微信配置错误，参数不能为空。Key:" + key, "AppId");
            if (string.IsNullOrWhiteSpace(weChatConfig.MiniProgramAppSecret))
                throw new MiniProgramArgumentException("微信配置错误，参数不能为空。Key:" + key, "AppSecret");
            MiniProgramConfigs.AddOrUpdate(key, weChatConfig, (tKey, existingVal) => weChatConfig);
            return weChatConfig;
        }

        /// <summary>
        ///     接口访问凭据
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken(string key = null)
        {
            var api = key == null ? MiniProgramApisContext.Current.TokenApi : new TokenApi();
            if (key != null)
                api.Key = key;
            return api.SafeGet().AccessToken;
        }

        /// <summary>
        ///     刷新访问凭据
        /// </summary>
        public void RefreshAccessToken(string key = null)
        {
            var api = key == null ? MiniProgramApisContext.Current.TokenApi : new TokenApi();
            if (key != null)
                api.Key = key;
            api.Get();
        }

        /// <summary>
        ///     刷新配置
        /// </summary>
        /// <param name="key">存储配置key</param>
        /// <param name="config">微信配置</param>
        public void RefreshConfig(string key, IMiniProgramConfig config) => MiniProgramConfigs.AddOrUpdate(key, config, (tKey, existingVal) => { return config; });


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