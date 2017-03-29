// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UpstreammsgType.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     消息发送消息类型
    /// </summary>
    public enum UpstreammsgType
    {
        文字 = 1,
        图片 = 2,
        语音 = 3,
        视频 = 4,
        第三方应用消息 = 6
    }
}