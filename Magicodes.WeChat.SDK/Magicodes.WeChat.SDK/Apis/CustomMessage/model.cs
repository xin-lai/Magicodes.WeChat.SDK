// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : model.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    public class CustomMessageSendModelBase
    {
        /// <summary>
        ///     普通用户openid
        /// </summary>
        [JsonProperty("touser")]
        public string Touser { get; set; }

        /// <summary>
        ///     消息类型
        ///     文本为text，图片为image，语音为voice，视频消息为video，音乐消息为music，图文消息（点击跳转到外链）为news，图文消息（点击跳转到图文消息页面）为mpnews，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes Type { get; set; }

        /// <summary>
        ///     指定发送消息的客服账号
        /// </summary>
        [JsonProperty("customservice")]
        public Customservice Customservice { get; set; }
    }

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

    /// <summary>
    ///     文本消息
    /// </summary>
    public class TextMessage : CustomMessageSendModelBase
    {
        public TextMessage()
        {
            Type = MessageTypes.text;
        }

        [JsonProperty("text")]
        public Text TextContent { get; set; }

        public class Text
        {
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    /// <summary>
    ///     图片消息
    /// </summary>
    public class ImageMessage : CustomMessageSendModelBase
    {
        public ImageMessage()
        {
            Type = MessageTypes.image;
        }

        [JsonProperty("image")]
        public Image ImageContent { get; set; }

        public class Image
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    ///     语音消息
    /// </summary>
    public class VoiceMessage : CustomMessageSendModelBase
    {
        public VoiceMessage()
        {
            Type = MessageTypes.voice;
        }

        [JsonProperty("voice")]
        public Voice VoiceContent { get; set; }

        public class Voice
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    ///     视频消息
    /// </summary>
    public class VideoMessage : CustomMessageSendModelBase
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

    /// <summary>
    ///     视频消息
    /// </summary>
    public class MusicMessage : CustomMessageSendModelBase
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

    /// <summary>
    ///     多图文消息
    /// </summary>
    public class NewsMessage : CustomMessageSendModelBase
    {
        public NewsMessage()
        {
            Type = MessageTypes.news;
        }

        [JsonProperty("news")]
        public News NewsContent { get; set; }

        public class News
        {
            [JsonProperty("articles")]
            public List<Article> Articles { get; set; }

            public class Article
            {
                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("url")]
                public string Url { get; set; }

                [JsonProperty("picurl")]
                public string PicUrl { get; set; }
            }
        }
    }

    /// <summary>
    ///     多图文消息
    /// </summary>
    public class MpNewsMessage : CustomMessageSendModelBase
    {
        public MpNewsMessage()
        {
            Type = MessageTypes.mpnews;
        }

        [JsonProperty("mpnews")]
        public MpNews MpNewsContent { get; set; }

        public class MpNews
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class WxCardMessage : CustomMessageSendModelBase
    {
        public WxCardMessage()
        {
            Type = MessageTypes.wxcard;
        }

        [JsonProperty("wxcard")]
        public WxCard WxCardContent { get; set; }

        public class WxCard
        {
            [JsonProperty("card_id")]
            public string Id { get; set; }

            [JsonProperty("card_ext")]
            public CardExt CardExtInfo { get; set; }

            public class CardExt
            {
                [JsonProperty("code")]
                public string Code { get; set; }

                [JsonProperty("openid")]
                public string OpenId { get; set; }

                [JsonProperty("timestamp")]
                public string TimeStamp { get; set; }

                [JsonProperty("signature")]
                public string Signature { get; set; }
            }
        }
    }


    /// <summary>
    ///     指定发送消息的客服账号
    /// </summary>
    public class Customservice
    {
        /// <summary>
        ///     客服账号
        /// </summary>
        [JsonProperty("kf_account")]
        public string Account { get; set; }
    }
}