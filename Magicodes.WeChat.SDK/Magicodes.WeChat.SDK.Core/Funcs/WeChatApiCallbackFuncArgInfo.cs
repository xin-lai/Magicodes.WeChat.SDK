// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatApiCallbackFuncArgInfo.cs
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
    using Magicodes.WeChat.SDK.Apis;

    /// <summary>
    /// Defines the <see cref="WeChatApiCallbackFuncArgInfo" />
    /// </summary>
    public class WeChatApiCallbackFuncArgInfo
    {
        /// <summary>
        /// Gets or sets the Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the Api
        /// </summary>
        public ApiBase Api { get; set; }
    }
}
