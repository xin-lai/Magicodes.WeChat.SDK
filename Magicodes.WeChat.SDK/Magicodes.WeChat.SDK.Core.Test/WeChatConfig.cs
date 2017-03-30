// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatConfig.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Test
{
    public class WeChatConfig : IWeChatConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string WeiXinAccount { get; set; }
        public string Token { get; set; }
    }
}