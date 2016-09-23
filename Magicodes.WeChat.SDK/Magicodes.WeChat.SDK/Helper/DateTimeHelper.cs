// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : DateTimeHelper.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;

namespace Magicodes.WeChat.SDK.Helper
{
    /// <summary>
    ///     微信时间戳转换
    /// </summary>
    public static class DateTimeHelper
    {
        private const long STANDARD_TIME_STAMP = 621355968000000000;

        /// <summary>
        ///     转换为时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertToTimeStamp(this DateTime time)
        {
            return (time.ToUniversalTime().Ticks - STANDARD_TIME_STAMP)/10000000;
        }

        /// <summary>
        ///     转换为时间
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(this long timestamp)
        {
            return new DateTime(timestamp*10000000 + STANDARD_TIME_STAMP).ToLocalTime();
        }
    }
}