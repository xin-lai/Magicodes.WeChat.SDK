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

namespace Magicodes.WeChat.SDK.Builder
{
    /// <summary>
    ///     WeChatSDK构造函数类
    /// </summary>
    public class MiniProgramSDKBuilder
    {
        private Action<string, string> LoggerAction { get; set; }
        private Func<string, IMiniProgramConfig> getConfigByKey { get; set; }

        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static MiniProgramSDKBuilder Create()
        {
            return new MiniProgramSDKBuilder();
        }

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
            getConfigByKey = func;
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