// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MessageTypes.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    /// <summary>
    ///     消息类型
    /// </summary>
    public enum MessageTypes
    {
        /// <summary>
        ///     文本为text
        /// </summary>
        text,

        /// <summary>
        ///     图片为image
        /// </summary>
        image,

        /// <summary>
        ///     语音为voice
        /// </summary>
        voice,

        /// <summary>
        ///     视频消息为video
        /// </summary>
        video,

        /// <summary>
        ///     音乐消息为music
        /// </summary>
        music,

        /// <summary>
        ///     图文消息（点击跳转到外链）为news
        /// </summary>
        news,

        /// <summary>
        ///     图文消息（点击跳转到图文消息页面）为mpnews
        /// </summary>
        mpnews,

        /// <summary>
        ///     卡券为wxcard
        /// </summary>
        wxcard
    }
}