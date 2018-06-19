// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : IWeChatConfig.cs
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
    /// <summary>
    /// 微信配置信息
    /// </summary>
    public interface IWeChatConfig
    {
        /// <summary>
        /// Gets or sets the AppId
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// Gets or sets the AppSecret
        /// </summary>
        string AppSecret { get; set; }

        /// <summary>
        /// Gets or sets the WeiXinAccount
        /// </summary>
        string WeiXinAccount { get; set; }

        /// <summary>
        /// Gets or sets the Token
        /// </summary>
        string Token { get; set; }
    }
}
