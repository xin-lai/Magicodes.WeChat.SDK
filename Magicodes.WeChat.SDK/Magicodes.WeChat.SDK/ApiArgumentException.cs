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

using System;

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     接口参数异常
    /// </summary>
    public class ApiArgumentException : ArgumentException
    {
        public ApiArgumentException()
        {
        }

        public ApiArgumentException(string message) : base(message)
        {
        }

        public ApiArgumentException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}