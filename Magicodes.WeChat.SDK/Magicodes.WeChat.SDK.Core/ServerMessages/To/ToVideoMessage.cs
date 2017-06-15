using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    ///     回复视频消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToVideoMessage : ToMessageBase
    {
        public ToVideoMessage()
        {
            Type = ToMessageTypes.video;
        }

        public VideoInfo Voice { get; set; }

        [Serializable]
        public class VideoInfo
        {
            public string MediaId { get; set; }

            /// <summary>
            ///     视频消息的标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            ///     视频消息的描述
            /// </summary>
            public string Description { get; set; }
        }
    }
}