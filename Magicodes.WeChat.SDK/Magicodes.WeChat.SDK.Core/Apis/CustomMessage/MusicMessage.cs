// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MusicMessage.cs
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
    public class MusicMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicMessage"/> class.
        /// </summary>
        public MusicMessage()
        {
            Type = MessageTypes.music;
        }

        /// <summary>
        /// Gets or sets the MusicContent
        /// </summary>
        [JsonProperty("music")]
        public Music MusicContent { get; set; }

        /// <summary>
        /// Defines the <see cref="Music" />
        /// </summary>
        public class Music
        {
            /// <summary>
            /// Gets or sets the MusicUrl
            /// </summary>
            [JsonProperty("musicurl")]
            public string MusicUrl { get; set; }

            /// <summary>
            /// Gets or sets the HqMusicUrl
            /// </summary>
            [JsonProperty("hqmusicurl")]
            public string HqMusicUrl { get; set; }

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
