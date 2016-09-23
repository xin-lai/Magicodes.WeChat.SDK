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

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    /// <summary>
    ///     视频消息
    /// </summary>
    public class MusicMessage : CustomMessageSendApiResultBase
    {
        public MusicMessage()
        {
            Type = MessageTypes.music;
        }

        [JsonProperty("music")]
        public Music MusicContent { get; set; }

        public class Music
        {
            [JsonProperty("musicurl")]
            public string MusicUrl { get; set; }

            [JsonProperty("hqmusicurl")]
            public string HqMusicUrl { get; set; }

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