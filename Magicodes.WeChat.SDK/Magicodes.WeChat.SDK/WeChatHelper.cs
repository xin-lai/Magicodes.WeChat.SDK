// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatHelper.cs
//          description :
//  
//          created by 李文强 at  2016/10/04 20:43
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub：https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.Logger;
using Magicodes.Storage;

namespace Magicodes.WeChat.SDK
{
    public static class WeChatHelper
    {
        private static LoggerBase _apiLogger = new NullLogger("Api");
        private static LoggerBase _payLogger = new NullLogger("Pay");
        private static IStorageProvider _storageProvider = new NullStorageProvider();

        /// <summary>
        ///     API日志记录器
        /// </summary>
        public static LoggerBase ApiLogger
        {
            get { return _apiLogger; }
            set { _apiLogger = value; }
        }

        /// <summary>
        ///     微信支付相关记录器
        /// </summary>
        public static LoggerBase PayLogger
        {
            get { return _payLogger; }
            set { _payLogger = value; }
        }

        /// <summary>
        ///     存储提供程序
        /// </summary>
        public static IStorageProvider StorageProvider
        {
            get { return _storageProvider; }
            set { _storageProvider = value; }
        }
    }
}