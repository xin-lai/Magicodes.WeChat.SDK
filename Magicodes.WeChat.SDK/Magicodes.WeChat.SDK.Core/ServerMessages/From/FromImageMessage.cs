using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    ///     图片消息
    /// </summary>
    public class FromImageMessage : FromMessageBase
    {
        /// <summary>
        ///     图片链接
        /// </summary>
        [XmlElement("PicUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///     图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        [XmlElement("MediaId")]
        public string MediaId { get; set; }
    }
}