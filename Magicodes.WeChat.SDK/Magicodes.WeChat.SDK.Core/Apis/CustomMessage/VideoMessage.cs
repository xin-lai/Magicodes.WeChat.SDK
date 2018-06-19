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

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;

    /// <summary>
    /// 视频消息
    /// </summary>
    public class VideoMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VideoMessage"/> class.
        /// </summary>
        public VideoMessage()
        {
            Type = MessageTypes.video;
        }

        /// <summary>
        /// Gets or sets the VideoContent
        /// </summary>
        [JsonProperty("video")]
        public Video VideoContent { get; set; }

        /// <summary>
        /// Defines the <see cref="Video" />
        /// </summary>
        public class Video
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// 语音
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }

            /// <summary>
            /// Gets or sets the ThumbMediaId
            /// 缩略图
            /// </summary>
            [JsonProperty("thumb_media_id")]
            public string ThumbMediaId { get; set; }

            /// <summary>
            /// Gets or sets the Title
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the Description
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }
        }
    }
}
