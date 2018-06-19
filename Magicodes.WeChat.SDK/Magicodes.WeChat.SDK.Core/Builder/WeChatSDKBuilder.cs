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

namespace Magicodes.WeChat.SDK.Builder
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// WeChatSDK构造函数类
    /// </summary>
    public class WeChatSDKBuilder
    {
        /// <summary>
        /// Defines the FuncDics
        /// </summary>
        private readonly Dictionary<WeChatFrameworkFuncTypes, Func<object, object>> FuncDics =
            new Dictionary<WeChatFrameworkFuncTypes, Func<object, object>>();

        /// <summary>
        /// Gets or sets the LoggerAction
        /// </summary>
        private Action<string, string> LoggerAction { get; set; }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        public static WeChatSDKBuilder Create()
        {
            return new WeChatSDKBuilder();
        }

        /// <summary>
        /// 设置日志记录处理
        /// </summary>
        /// <param name="loggerAction">The loggerAction<see cref="Action{string, string}"/></param>
        /// <returns></returns>
        public WeChatSDKBuilder WithLoggerAction(Action<string, string> loggerAction)
        {
            LoggerAction = loggerAction;
            return this;
        }

        /// <summary>
        /// The Register
        /// </summary>
        /// <param name="type">The type<see cref="WeChatFrameworkFuncTypes"/></param>
        /// <param name="func">The func<see cref="Func{object, object}"/></param>
        /// <returns>The <see cref="WeChatSDKBuilder"/></returns>
        public WeChatSDKBuilder Register(WeChatFrameworkFuncTypes type, Func<object, object> func)
        {
            FuncDics.Add(type, func);
            return this;
        }

        /// <summary>
        /// 确定设置
        /// </summary>
        public void Build()
        {
            if (LoggerAction != null)
                WeChatHelper.LoggerAction = LoggerAction;
            foreach (var item in FuncDics)
                WeChatFrameworkFuncsManager.Current.Register(item.Key, item.Value);
        }
    }
}
