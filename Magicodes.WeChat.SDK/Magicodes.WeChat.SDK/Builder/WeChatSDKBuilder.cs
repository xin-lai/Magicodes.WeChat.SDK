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

using Magicodes.Logger;
using Magicodes.Storage;

namespace Magicodes.WeChat.SDK.Builder
{
    public class WeChatSDKBuilder
    {
        internal IStorageProvider StorageProvider { get; set; }
        internal LoggerBase PayLogger { get; set; }
        internal LoggerBase ApiLogger { get; set; }

        /// <summary>
        ///     创建实例
        /// </summary>
        /// <returns></returns>
        public static WeChatSDKBuilder Create()
        {
            return new WeChatSDKBuilder();
        }

        /// <summary>
        ///     设置API日志记录器
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public WeChatSDKBuilder WithApiLogger(LoggerBase logger)
        {
            ApiLogger = logger;
            return this;
        }

        /// <summary>
        ///     设置微信支付相关记录器
        /// </summary>
        /// <param name="logger"></param>
        /// <returns></returns>
        public WeChatSDKBuilder WithPayLogger(LoggerBase logger)
        {
            PayLogger = logger;
            return this;
        }

        /// <summary>
        ///     设置存储提供程序
        /// </summary>
        /// <param name="storageProvider"></param>
        /// <returns></returns>
        public WeChatSDKBuilder WithStorageProvider(IStorageProvider storageProvider)
        {
            StorageProvider = storageProvider;
            return this;
        }

        /// <summary>
        ///     确定设置
        /// </summary>
        public void Build()
        {
            WeChatHelper.StorageProvider = StorageProvider;
            WeChatHelper.ApiLogger = ApiLogger;
            WeChatHelper.PayLogger = PayLogger;
        }
    }
}