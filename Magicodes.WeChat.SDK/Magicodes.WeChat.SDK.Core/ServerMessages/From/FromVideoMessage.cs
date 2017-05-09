using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    ///     视频消息
    /// </summary>
    public class FromVideoMessage : FromMessageBase
    {
        /// <summary>
        ///     视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }

        /// <summary>
        ///     语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}