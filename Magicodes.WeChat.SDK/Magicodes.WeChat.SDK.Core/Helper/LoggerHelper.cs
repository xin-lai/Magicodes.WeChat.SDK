// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : LoggerHelper.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:17
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

using System;

namespace Magicodes.WeChat.SDK.Helper
{
    /// <summary>
    /// 定义日志辅助类 <see cref="LoggerHelper" />
    /// </summary>
    public class LoggerHelper
    {
        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message) => WeChatHelper.LoggerAction("Debug", message);

        /// <summary>
        /// 输出普通信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message) => WeChatHelper.LoggerAction("Info", message);

        /// <summary>
        /// 输出警告信息
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message) => WeChatHelper.LoggerAction("Info", message);

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception = null) => WeChatHelper.LoggerAction("Error", message + Environment.NewLine + exception?.ToString());

        /// <summary>
        /// 输出调试信息
        /// </summary>
        /// <param name="format"></param>
        /// <param name="objects"></param>
        public static void DebugFormat(string format, params object[] objects)
        {
            WeChatHelper.LoggerAction("Debug", string.Format(format, objects));
        }
    }
}
