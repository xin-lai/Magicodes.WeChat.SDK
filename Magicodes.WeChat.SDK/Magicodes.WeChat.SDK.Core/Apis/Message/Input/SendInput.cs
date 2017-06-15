using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Magicodes.WeChat.SDK.Apis.Message.Input
{
    public abstract class SendAllInputBase
    {
        /// <summary>
        ///     用于设定图文消息的接收者
        /// </summary>
        [JsonProperty("filter")]
        public FilterInfo Filter { get; set; }

        /// <summary>
        ///     群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MessageType { get; internal set; }

        /// <summary>
        ///     用于设定消息的接收者
        /// </summary>
        public class FilterInfo
        {
            /// <summary>
            ///     用于设定是否向全部用户发送，值为true或false，选择true该消息群发给所有用户，选择false可根据group_id发送给指定群组的用户
            /// </summary>
            [JsonProperty("is_to_all")]
            public bool IsToAll { get; set; }

            /// <summary>
            ///     群发到的分组的group_id，参加用户管理中用户分组接口，若is_to_all值为true，可不填写group_id
            /// </summary>
            [JsonProperty("group_id")]
            public int GroupId { get; set; }
        }
    }

    public abstract class SendInputBase
    {
        /// <summary>
        ///     填写图文消息的接收者，一串OpenID列表，OpenID最少2个，最多10000个
        /// </summary>
        [JsonProperty("touser")]
        public ICollection<string> ToUsers { get; set; }

        /// <summary>
        ///     群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MessageType { get; internal set; }
    }

    public abstract class PreviewInputBase
    {
        /// <summary>
        ///     填写图文消息的接收者，一串OpenID列表，OpenID最少2个，最多10000个
        /// </summary>
        [JsonProperty("touser", NullValueHandling = NullValueHandling.Ignore)]
        public string ToUser { get; set; }

        /// <summary>
        ///     微信号（如果设置了此值，则ToUser设置无效）
        /// </summary>
        [JsonProperty("towxname", NullValueHandling = NullValueHandling.Ignore)]
        public string ToWXName { get; set; }

        /// <summary>
        ///     群发的消息类型，图文消息为mpnews，文本消息为text，语音为voice，音乐为music，图片为image，视频为video，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes MessageType { get; internal set; }
    }


    public class SendAllTextInput : SendAllInputBase
    {
        public SendAllTextInput()
        {
            MessageType = MessageTypes.text;
        }

        [JsonProperty("text")]
        public TextInfo Text { get; set; }

        public class TextInfo
        {
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    public class SendAllNewsInput : SendAllInputBase
    {
        public SendAllNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }

        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        public class NewsInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendAllVoiceInput : SendAllInputBase
    {
        public SendAllVoiceInput()
        {
            MessageType = MessageTypes.voice;
        }

        [JsonProperty("voice")]
        public VoiceInfo Voice { get; set; }

        public class VoiceInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendAllImageInput : SendAllInputBase
    {
        public SendAllImageInput()
        {
            MessageType = MessageTypes.image;
        }

        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        public class ImageInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendAllMPVideoInput : SendAllInputBase
    {
        public SendAllMPVideoInput()
        {
            MessageType = MessageTypes.mpvideo;
        }

        [JsonProperty("mpvideo")]
        public MPVideoInfo MPVideo { get; set; }

        public class MPVideoInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendAllWXCardInput : SendAllInputBase
    {
        public SendAllWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        public class WXCardInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }


    public class SendTextInput : SendInputBase
    {
        public SendTextInput()
        {
            MessageType = MessageTypes.text;
        }

        [JsonProperty("text")]
        public TextInfo Text { get; set; }

        public class TextInfo
        {
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    public class SendNewsInput : SendInputBase
    {
        public SendNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }

        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        public class NewsInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendVoiceInput : SendInputBase
    {
        public SendVoiceInput()
        {
            MessageType = MessageTypes.voice;
        }

        [JsonProperty("voice")]
        public VoiceInfo Voice { get; set; }

        public class VoiceInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendImageInput : SendInputBase
    {
        public SendImageInput()
        {
            MessageType = MessageTypes.image;
        }

        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        public class ImageInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendVideoInput : SendInputBase
    {
        public SendVideoInput()
        {
            MessageType = MessageTypes.video;
        }

        [JsonProperty("video")]
        public VideoInfo Video { get; set; }

        public class VideoInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class SendWXCardInput : SendInputBase
    {
        public SendWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        public class WXCardInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }


    public class PreviewTextInput : PreviewInputBase
    {
        public PreviewTextInput()
        {
            MessageType = MessageTypes.text;
        }

        [JsonProperty("text")]
        public TextInfo Text { get; set; }

        public class TextInfo
        {
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }

    public class PreviewNewsInput : PreviewInputBase
    {
        public PreviewNewsInput()
        {
            MessageType = MessageTypes.mpnews;
        }

        [JsonProperty("mpnews")]
        public NewsInfo News { get; set; }

        public class NewsInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class PreviewVoiceInput : PreviewInputBase
    {
        public PreviewVoiceInput()
        {
            MessageType = MessageTypes.voice;
        }

        [JsonProperty("voice")]
        public VoiceInfo Voice { get; set; }

        public class VoiceInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class PreviewImageInput : PreviewInputBase
    {
        public PreviewImageInput()
        {
            MessageType = MessageTypes.image;
        }

        [JsonProperty("image")]
        public ImageInfo Image { get; set; }

        public class ImageInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class PreviewMPVideoInput : PreviewInputBase
    {
        public PreviewMPVideoInput()
        {
            MessageType = MessageTypes.mpvideo;
        }

        [JsonProperty("mpvideo")]
        public MPVideoInfo MPVideo { get; set; }

        public class MPVideoInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }

    public class PreviewWXCardInput : PreviewInputBase
    {
        public PreviewWXCardInput()
        {
            MessageType = MessageTypes.wxcard;
        }

        [JsonProperty("wxcard")]
        public WXCardInfo WXCard { get; set; }

        public class WXCardInfo
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}