using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    [XmlRoot("xml")]
    [Serializable]
    public abstract class ToMessageBase
    {
        protected ToMessageBase()
        {
            CreateDateTime = DateTime.Now;
        }

        /// <summary>
        ///     接收方帐号（收到的OpenID）
        ///     无需设置
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }

        /// <summary>
        ///     开发者微信号
        ///     无需设置
        /// </summary>
        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("CreateTime")]
        public long CreateTimestamp { get; set; }

        /// <summary>
        ///     创建时间
        ///     无需设置,默认设置为当前时间
        /// </summary>
        [XmlIgnore]
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        ///     消息类型
        ///     无需设置,根据消息类型自动设置
        /// </summary>
        [XmlElement("MsgType")]
        public ToMessageTypes Type { get; set; }
    }
}