// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatServerMessageEventDataBase.cs
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
    using Magicodes.WeChat.SDK.Core.ServerMessages.To;

    /// <summary>
    /// 定义微信事件基类 <see cref="WeChatServerMessageEventDataBase" />
    /// </summary>
    public class WeChatServerMessageEventDataBase
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        public int? TenantId { get; set; }

        /// <summary>
        /// 输出内容
        /// </summary>
        public ToMessageBase ToMessage { get; set; }
    }
}
