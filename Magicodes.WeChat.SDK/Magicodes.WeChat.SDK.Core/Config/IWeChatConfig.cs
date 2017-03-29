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
    ///     微信配置信息
    /// </summary>
    public interface IWeChatConfig
    {
        string AppId { get; set; }
        string AppSecret { get; set; }
        string WeiXinAccount { get; set; }
        string Token { get; set; }
    }
}