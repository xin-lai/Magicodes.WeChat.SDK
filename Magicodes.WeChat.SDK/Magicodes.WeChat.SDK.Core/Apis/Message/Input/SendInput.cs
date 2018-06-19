// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : SendInput.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:47:59
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Apis.Message.Input
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="SendAllInputBase" />
    /// </summary>
    public abstract class SendAllInputBase
    {
        /// <summary>
        /// Gets or sets the Filter
        /// 用于设定图文消息的接收者
        /// </summary>
        [JsonProperty("filter")]
        public FilterInfo Filter { get; set; }

        /// <summary>
        /// Gets or sets the MessageType
        /// 群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MessageType { get; internal set; }

        /// <summary>
        /// 用于设定消息的接收者
        /// </summary>
        public class FilterInfo
        {
            /// <summary>
            /// Gets or sets a value indicating whether IsToAll
            /// 用于设定是否向全部用户发送，值为true或false，选择true该消息群发给所有用户，选择false可根据group_id发送给指定群组的用户
            /// </summary>
            [JsonProperty("is_to_all")]
            public bool IsToAll { get; set; }

            /// <summary>
            /// Gets or sets the GroupId
            /// 群发到的分组的group_id，参加用户管理中用户分组接口，若is_to_all值为true，可不填写group_id
            /// </summary>
            [JsonProperty("group_id")]
            public int GroupId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendInputBase" />
    /// </summary>
    public abstract class SendInputBase
    {
        /// <summary>
        /// Gets or sets the ToUsers
        /// 填写图文消息的接收者，一串OpenID列表，OpenID最少2个，最多10000个
        /// </summary>
        [JsonProperty("touser")]
        public ICollection<string> ToUsers { get; set; }

        /// <summary>
        /// Gets or sets the MessageType
        /// 群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MessageType { get; internal set; }
    }

    /// <summary>
    /// Defines the <see cref="PreviewInputBase" />
    /// </summary>
    public abstract class PreviewInputBase
    {
        /// <summary>
        /// Gets or sets the ToUser
        /// 填写图文消息的接收者，一串OpenID列表，OpenID最少2个，最多10000个
        /// </summary>
        [JsonProperty("touser", NullValueHandling = NullValueHandling.Ignore)]
        public string ToUser { get; set; }

        /// <summary>
        /// Gets or sets the ToWXName
        /// 微信号（如果设置了此值，则ToUser设置无效）
        /// </summary>
        [JsonProperty("towxname", NullValueHandling = NullValueHandling.Ignore)]
        public string ToWXName { get; set; }

        /// <summary>
        /// Gets or sets the MessageType
        /// 群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MessageType { get; internal set; }
    }

    /// <summary>
    /// Defines the <see cref="SendAllTextInput" />
    /// </summary>
    public class SendAllTextInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllTextInput"/> class.
        /// </summary>
        public SendAllTextInput()
        {
            MessageType = MessageTypes.text;
        }

        /// <summary>
        /// Gets or sets the Text
        /// </summary>
        [JsonProperty("text")]
        public TextInfo Text { get; set; }

        /// <summary>
        /// Defines the <see cref="TextInfo" />
        /// </summary>
        public class TextInfo
        {
            /// <summary>
            /// Gets or sets the Content
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendAllNewsInput" />
    /// </summary>
    public class SendAllNewsInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllNewsInput"/> class.
        /// </summary>
        public SendAllNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }

        /// <summary>
        /// Gets or sets the News
        /// </summary>
        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        /// <summary>
        /// Defines the <see cref="NewsInfo" />
        /// </summary>
        public class NewsInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendAllVoiceInput" />
    /// </summary>
    public class SendAllVoiceInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllVoiceInput"/> class.
        /// </summary>
        public SendAllVoiceInput()
        {
            MessageType = MessageTypes.voice;
        }

        /// <summary>
        /// Gets or sets the Voice
        /// </summary>
        [JsonProperty("voice")]
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Defines the <see cref="VoiceInfo" />
        /// </summary>
        public class VoiceInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendAllImageInput" />
    /// </summary>
    public class SendAllImageInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllImageInput"/> class.
        /// </summary>
        public SendAllImageInput()
        {
            MessageType = MessageTypes.image;
        }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        /// <summary>
        /// Defines the <see cref="ImageInfo" />
        /// </summary>
        public class ImageInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendAllMPVideoInput" />
    /// </summary>
    public class SendAllMPVideoInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllMPVideoInput"/> class.
        /// </summary>
        public SendAllMPVideoInput()
        {
            MessageType = MessageTypes.mpvideo;
        }

        /// <summary>
        /// Gets or sets the MPVideo
        /// </summary>
        [JsonProperty("mpvideo")]
        public MPVideoInfo MPVideo { get; set; }

        /// <summary>
        /// Defines the <see cref="MPVideoInfo" />
        /// </summary>
        public class MPVideoInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendAllWXCardInput" />
    /// </summary>
    public class SendAllWXCardInput : SendAllInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendAllWXCardInput"/> class.
        /// </summary>
        public SendAllWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        /// <summary>
        /// Gets or sets the WXCard
        /// </summary>
        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        /// <summary>
        /// Defines the <see cref="WXCardInfo" />
        /// </summary>
        public class WXCardInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendTextInput" />
    /// </summary>
    public class SendTextInput : SendInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendTextInput"/> class.
        /// </summary>
        public SendTextInput()
        {
            MessageType = MessageTypes.text;
        }

        /// <summary>
        /// Gets or sets the Text
        /// </summary>
        [JsonProperty("text")]
        public TextInfo Text { get; set; }

        /// <summary>
        /// Defines the <see cref="TextInfo" />
        /// </summary>
        public class TextInfo
        {
            /// <summary>
            /// Gets or sets the Content
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendNewsInput" />
    /// </summary>
    public class SendNewsInput : SendInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendNewsInput"/> class.
        /// </summary>
        public SendNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }

        /// <summary>
        /// Gets or sets the News
        /// </summary>
        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        /// <summary>
        /// Defines the <see cref="NewsInfo" />
        /// </summary>
        public class NewsInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendVoiceInput" />
    /// </summary>
    public class SendVoiceInput : SendInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendVoiceInput"/> class.
        /// </summary>
        public SendVoiceInput()
        {
            MessageType = MessageTypes.voice;
        }

        /// <summary>
        /// Gets or sets the Voice
        /// </summary>
        [JsonProperty("voice")]
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Defines the <see cref="VoiceInfo" />
        /// </summary>
        public class VoiceInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendImageInput" />
    /// </summary>
    public class SendImageInput : SendInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendImageInput"/> class.
        /// </summary>
        public SendImageInput()
        {
            MessageType = MessageTypes.image;
        }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        /// <summary>
        /// Defines the <see cref="ImageInfo" />
        /// </summary>
        public class ImageInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendVideoInput" />
    /// </summary>
    public class SendVideoInput : SendInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendVideoInput"/> class.
        /// </summary>
        public SendVideoInput()
        {
            MessageType = MessageTypes.video;
        }

        /// <summary>
        /// Gets or sets the Video
        /// </summary>
        [JsonProperty("video")]
        public VideoInfo Video { get; set; }

        /// <summary>
        /// Defines the <see cref="VideoInfo" />
        /// </summary>
        public class VideoInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="SendWXCardInput" />
    /// </summary>
    public class SendWXCardInput : SendInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendWXCardInput"/> class.
        /// </summary>
        public SendWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        /// <summary>
        /// Gets or sets the WXCard
        /// </summary>
        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        /// <summary>
        /// Defines the <see cref="WXCardInfo" />
        /// </summary>
        public class WXCardInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="PreviewTextInput" />
    /// </summary>
    public class PreviewTextInput : PreviewInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewTextInput"/> class.
        /// </summary>
        public PreviewTextInput()
        {
            MessageType = MessageTypes.text;
        }

        /// <summary>
        /// Gets or sets the Text
        /// </summary>
        [JsonProperty("text")]
        public TextInfo Text { get; set; }

        /// <summary>
        /// Defines the <see cref="TextInfo" />
        /// </summary>
        public class TextInfo
        {
            /// <summary>
            /// Gets or sets the Content
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="PreviewNewsInput" />
    /// </summary>
    public class PreviewNewsInput : PreviewInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewNewsInput"/> class.
        /// </summary>
        public PreviewNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }

        /// <summary>
        /// Gets or sets the News
        /// </summary>
        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        /// <summary>
        /// Defines the <see cref="NewsInfo" />
        /// </summary>
        public class NewsInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="PreviewVoiceInput" />
    /// </summary>
    public class PreviewVoiceInput : PreviewInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewVoiceInput"/> class.
        /// </summary>
        public PreviewVoiceInput()
        {
            MessageType = MessageTypes.voice;
        }

        /// <summary>
        /// Gets or sets the Voice
        /// </summary>
        [JsonProperty("voice")]
        public VoiceInfo Voice { get; set; }

        /// <summary>
        /// Defines the <see cref="VoiceInfo" />
        /// </summary>
        public class VoiceInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="PreviewImageInput" />
    /// </summary>
    public class PreviewImageInput : PreviewInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewImageInput"/> class.
        /// </summary>
        public PreviewImageInput()
        {
            MessageType = MessageTypes.image;
        }

        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        /// <summary>
        /// Defines the <see cref="ImageInfo" />
        /// </summary>
        public class ImageInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="PreviewMPVideoInput" />
    /// </summary>
    public class PreviewMPVideoInput : PreviewInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewMPVideoInput"/> class.
        /// </summary>
        public PreviewMPVideoInput()
        {
            MessageType = MessageTypes.mpvideo;
        }

        /// <summary>
        /// Gets or sets the MPVideo
        /// </summary>
        [JsonProperty("mpvideo")]
        public MPVideoInfo MPVideo { get; set; }

        /// <summary>
        /// Defines the <see cref="MPVideoInfo" />
        /// </summary>
        public class MPVideoInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    /// <summary>
    /// Defines the <see cref="PreviewWXCardInput" />
    /// </summary>
    public class PreviewWXCardInput : PreviewInputBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreviewWXCardInput"/> class.
        /// </summary>
        public PreviewWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        /// <summary>
        /// Gets or sets the WXCard
        /// </summary>
        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        /// <summary>
        /// Defines the <see cref="WXCardInfo" />
        /// </summary>
        public class WXCardInfo
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}
