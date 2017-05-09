using System;
using System.Xml.Serialization;
using Magicodes.WeChat.SDK.Helper;

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
        /// 接收方帐号（收到的OpenID）
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("CreateTime")]
        public long CreateTimestamp { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlIgnore]
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        [XmlElement("MsgType")]
        public ToMessageTypes Type { get; set; }
    }
}
