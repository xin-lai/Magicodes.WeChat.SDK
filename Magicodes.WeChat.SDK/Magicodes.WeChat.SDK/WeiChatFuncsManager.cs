// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeiChatFuncsManager.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Concurrent;

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     方法类型
    /// </summary>
    public enum WeiChatFrameworkFuncTypes
    {
        /// <summary>
        ///     根据Key获取微信配置
        /// </summary>
        Config_GetWeiChatConfigByKey = 0,

        /// <summary>
        ///     模板消息发送
        /// </summary>
        APIFunc_TemplateMessageApi_Create = 1,

        /// <summary>
        ///     创建二维码
        /// </summary>
        APIFunc_QRCodeApi_Create = 2,

        /// <summary>
        ///     获取微信支付信息
        /// </summary>
        Config_GetWeiChatPayConfigByKey = 3
    }

    /// <summary>
    ///     函数管理器
    /// </summary>
    public class WeiChatFrameworkFuncsManager
    {
        private static readonly Lazy<WeiChatFrameworkFuncsManager> Lazy = new Lazy<WeiChatFrameworkFuncsManager>(() => new WeiChatFrameworkFuncsManager());
        public static WeiChatFrameworkFuncsManager Current => Lazy.Value;
        /// <summary>
        ///     函数集合
        /// </summary>
        internal ConcurrentDictionary<WeiChatFrameworkFuncTypes, Func<object, object>> Funcs =
            new ConcurrentDictionary<WeiChatFrameworkFuncTypes, Func<object, object>>();

        /// <summary>
        ///     注册函数
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="func"></param>
        public void Register(WeiChatFrameworkFuncTypes eventType, Func<object, object> func)
        {
            if (Funcs.ContainsKey(eventType))
                throw new Exception(string.Format("{0}已经注册，不能重复注册！", eventType));
            Funcs.AddOrUpdate(eventType, func, (tKey, existingVal) => { return func; });
        }

        /// <summary>
        ///     获取函数
        /// </summary>
        /// <param name="eventType"></param>
        /// <returns></returns>
        public Func<object, object> GetFunc(WeiChatFrameworkFuncTypes eventType)
        {
            if (Funcs.ContainsKey(eventType))
                return Funcs[eventType];
            return null;
        }

        /// <summary>
        ///     执行函数
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="obj"></param>
        public object InvokeFunc(WeiChatFrameworkFuncTypes eventType, WeiChatApiCallbackFuncArgInfo obj)
        {
            var func = GetFunc(eventType);
            if (func != null)
                return func.Invoke(obj);
            return null;
        }

        /// <summary>
        ///     执行函数 支付
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="obj"></param>
        public object InvokeFunc(WeiChatFrameworkFuncTypes eventType, WeiChatPayCallbackFuncArgInfo obj)
        {
            var func = GetFunc(eventType);
            if (func != null)
                return func.Invoke(obj);
            return null;
        }
    }
}