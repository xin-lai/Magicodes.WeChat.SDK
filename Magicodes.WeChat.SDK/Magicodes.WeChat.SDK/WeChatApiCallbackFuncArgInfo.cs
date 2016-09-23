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

using Magicodes.WeChat.SDK.Apis;

namespace Magicodes.WeChat.SDK
{
    public class WeChatApiCallbackFuncArgInfo
    {
        public object Data { get; set; }
        public ApiBase Api { get; set; }
    }
}