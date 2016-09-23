// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatFrameworkFuncsManager.cs
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

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     函数管理器
    /// </summary>
    public class WeChatFrameworkFuncsManager
    {
        private static readonly Lazy<WeChatFrameworkFuncsManager> Lazy =
            new Lazy<WeChatFrameworkFuncsManager>(() => new WeChatFrameworkFuncsManager());

        /// <summary>
        ///     函数集合
        /// </summary>
        internal ConcurrentDictionary<WeChatFrameworkFuncTypes, Func<object, object>> Funcs =
            new ConcurrentDictionary<WeChatFrameworkFuncTypes, Func<object, object>>();

        public static WeChatFrameworkFuncsManager Current => Lazy.Value;

        /// <summary>
        ///     注册函数
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="func"></param>
        public void Register(WeChatFrameworkFuncTypes eventType, Func<object, object> func)
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
        public Func<object, object> GetFunc(WeChatFrameworkFuncTypes eventType)
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
        public object InvokeFunc(WeChatFrameworkFuncTypes eventType, WeChatApiCallbackFuncArgInfo obj)
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
        public object InvokeFunc(WeChatFrameworkFuncTypes eventType, WeChatPayCallbackFuncArgInfo obj)
        {
            var func = GetFunc(eventType);
            if (func != null)
                return func.Invoke(obj);
            return null;
        }
    }
}