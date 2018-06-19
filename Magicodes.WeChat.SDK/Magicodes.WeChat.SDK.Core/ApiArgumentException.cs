// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ApiArgumentException.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK
{
    using System;

    /// <summary>
    /// 接口参数异常
    /// </summary>
    public class ApiArgumentException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiArgumentException"/> class.
        /// </summary>
        public ApiArgumentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        public ApiArgumentException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/></param>
        /// <param name="paramName">The paramName<see cref="string"/></param>
        public ApiArgumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}
