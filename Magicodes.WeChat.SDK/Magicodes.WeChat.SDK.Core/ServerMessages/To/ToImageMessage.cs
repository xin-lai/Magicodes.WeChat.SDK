using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    /// 回复图片消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToImageMessage : ToMessageBase
    {
        public ToImageMessage()
        {
            Type = ToMessageTypes.image;
        }

        [Serializable]
        public class ImageInfo
        {
            public string MediaId { get; set; }
        }

        public ImageInfo Image { get; set; }
    }
}