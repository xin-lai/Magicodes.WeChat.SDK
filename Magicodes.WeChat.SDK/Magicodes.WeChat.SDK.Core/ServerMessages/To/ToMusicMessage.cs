using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    ///     回复视频消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToMusicMessage : ToMessageBase
    {
        public ToMusicMessage()
        {
            Type = ToMessageTypes.music;
        }

        public MusicInfo Music { get; set; }

        [Serializable]
        public class MusicInfo
        {
            /// <summary>
            ///     音乐链接
            /// </summary>
            public string MusicUrl { get; set; }

            /// <summary>
            ///     高质量音乐链接，WIFI环境优先使用该链接播放音乐
            /// </summary>
            public string HQMusicUrl { get; set; }

            /// <summary>
            ///     缩略图的媒体id，通过素材管理接口上传多媒体文件，得到的id
            /// </summary>
            public string ThumbMediaId { get; set; }

            /// <summary>
            ///     音乐标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            ///     音乐描述
            /// </summary>
            public string Description { get; set; }
        }
    }
}