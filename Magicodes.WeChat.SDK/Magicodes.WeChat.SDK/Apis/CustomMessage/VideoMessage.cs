// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : VideoMessage.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    /// <summary>
    ///     视频消息
    /// </summary>
    public class VideoMessage : CustomMessageSendApiResultBase
    {
        public VideoMessage()
        {
            Type = MessageTypes.video;
        }

        [JsonProperty("video")]
        public Video VideoContent { get; set; }

        public class Video
        {
            /// <summary>
            ///     语音
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }

            /// <summary>
            ///     缩略图
            /// </summary>
            [JsonProperty("thumb_media_id")]
            public string ThumbMediaId { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }
    }
}