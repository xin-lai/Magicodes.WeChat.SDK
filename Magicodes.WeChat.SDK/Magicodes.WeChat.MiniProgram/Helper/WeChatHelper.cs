// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatHelper.cs
//          description :
//  
//          created by 李文强 at  2016/10/04 20:43
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub：https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================


using System;

namespace Magicodes.WeChat.MiniProgram
{
    public static class WeChatHelper
    {
        public static Action<string, string> LoggerAction = (tag, log) => { };
    }
}