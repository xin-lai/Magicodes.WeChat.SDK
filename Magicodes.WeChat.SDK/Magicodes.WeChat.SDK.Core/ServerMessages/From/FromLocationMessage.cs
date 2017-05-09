using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    ///     地理位置消息
    /// </summary>
    public class FromLocationMessage : FromMessageBase
    {
        /// <summary>
        ///     地理位置维度
        /// </summary>
        [XmlElement("Location_X")]
        public double X { get; set; }

        /// <summary>
        ///     地理位置经度
        /// </summary>
        [XmlElement("Location_Y")]
        public double Y { get; set; }

        /// <summary>
        ///     地图缩放大小
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        ///     地理位置信息
        /// </summary>
        public string Label { get; set; }
    }
}