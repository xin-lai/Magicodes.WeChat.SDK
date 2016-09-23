// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : Injection.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Magicodes.Logger;
using Magicodes.Storage;

namespace Magicodes.WeChat.SDK
{
    public class Injection
    {
        private static readonly Lazy<Injection> Lazy = new Lazy<Injection>(() => new Injection());
        public static Injection Current => Lazy.Value;

        /// <summary>
        ///     API日志记录器
        /// </summary>
        public LoggerBase ApiLogger { get; set; }

        /// <summary>
        ///     微信支付相关记录器
        /// </summary>
        public LoggerBase PayLogger { get; set; }

        /// <summary>
        ///     存储提供程序
        /// </summary>
        public IStorageProvider StorageProvider { get; set; }
    }
}