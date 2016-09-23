// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeiChatFuncArgInfo.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis;
using Magicodes.WeChat.SDK.Pays;

namespace Magicodes.WeChat.SDK
{
    public class WeiChatApiCallbackFuncArgInfo
    {
        public object Data { get; set; }
        public ApiBase Api { get; set; }
    }

    public class WeiChatPayCallbackFuncArgInfo
    {
        public object Data { get; set; }
        public PayBase Api { get; set; }
    }
}