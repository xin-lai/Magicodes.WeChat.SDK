// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatScanEventData.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:55:22
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.Web.Core.Event
{
    using Magicodes.WeChat.SDK.Core.ServerMessages.From;

    /// <summary>
    /// 扫码事件
    /// </summary>
    public class WeChatScanEventData : WeChatServerMessageEventDataBase
    {
        /// <summary>
        /// Gets or sets the FromMessage
        /// </summary>
        public FromScanEvent FromMessage { get; set; }
    }
}
