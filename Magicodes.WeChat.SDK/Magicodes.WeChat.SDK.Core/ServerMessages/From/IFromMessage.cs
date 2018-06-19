// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : IFromMessage.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:28
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    /// 获取消息
    /// </summary>
    public interface IFromMessage
    {
        /// <summary>
        /// Gets or sets the ToUserName
        /// </summary>
        string ToUserName { get; set; }

        /// <summary>
        /// Gets or sets the FromUserName
        /// </summary>
        string FromUserName { get; set; }
    }
}
