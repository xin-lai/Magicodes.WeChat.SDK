// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatSDKBuilder.cs
//          description :
//  
//          created by 李文强 at  2016/10/04 20:16
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub：https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================


using System;
using System.Collections.Generic;
using Magicodes.WeChat.MiniProgram.Apis.Token.Dto;

namespace Magicodes.WeChat.SDK.Builder
{
    /// <summary>
    ///     WeChatSDK构造函数类
    /// </summary>
    public class MiniProgramSDKBuilder
    {
        private Action<string, string> LoggerAction { get; set; }
        private Func<string, IMiniProgramConfig> GetConfigByKeyFunc { get; set; }

        private Func<string> GetKeyFunc { get; set; }

        private Func<IMiniProgramConfig, IAccesstokenInfo> GetAccessTokenFunc { get; set; }



        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static MiniProgramSDKBuilder Create() => new MiniProgramSDKBuilder();

        /// <summary>
        ///     设置日志记录处理
        /// </summary>
        /// <param name="loggerAction"></param>
        /// <returns></returns>
        public MiniProgramSDKBuilder WithLoggerAction(Action<string, string> loggerAction)
        {
            LoggerAction = loggerAction;
            return this;
        }

        /// <summary>
        /// 注册配置获取逻辑
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public MiniProgramSDKBuilder RegisterGetConfigByKeyFunc(Func<string, IMiniProgramConfig> func)
        {
            GetConfigByKeyFunc = func;
            return this;
        }

        /// <summary>
        /// 注册获取配置Key逻辑
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public MiniProgramSDKBuilder RegisterGetKeyFunc(Func<string> func)
        {
            GetKeyFunc = func;
            return this;
        }

        /// <summary>
        /// 注册获取AccessToken逻辑，比如从其他框架、接口、中控
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public MiniProgramSDKBuilder RegisterGetAccessTokenFunc(Func<IMiniProgramConfig, IAccesstokenInfo> func)
        {
            GetAccessTokenFunc = func;
            return this;
        }

        /// <summary>
        ///     确定设置
        /// </summary>
        public void Build()
        {
            if (LoggerAction != null)
                WeChatHelper.LoggerAction = LoggerAction;
            //foreach (var item in FuncDics)
            //    WeChatFrameworkFuncsManager.Current.Register(item.Key, item.Value);
        }
    }
}