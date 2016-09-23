// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ReadUserSourceType.cs
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
    ///     图文阅读分时数据的用户渠道
    /// </summary>
    public enum ReadUserSourceType
    {
        会话 = 0,
        好友 = 1,
        朋友圈 = 2,
        腾讯微博 = 3,
        历史消息页 = 4,
        其他 = 5
    }
}