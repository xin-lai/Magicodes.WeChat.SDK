using System;
using System.Xml.Serialization;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    [XmlRoot("xml")]
    [Serializable]
    public abstract class FromEventBase: IFromMessage
    {
        protected FromEventBase()
        {
            Type = "event";
        }
        /// <summary>
        /// 开发者微信号
        /// </summary>
        [XmlElement("ToUserName")]
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        [XmlElement("FromUserName")]
        public string FromUserName { get; set; }

        [XmlElement("CreateTime")]
        internal long CreateTimestamp { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [XmlIgnore]
        public DateTime CreateDateTime => CreateTimestamp > 0 ? CreateTimestamp.ConvertToDateTime() : default(DateTime);
        /// <summary>
        /// 消息类型
        /// </summary>
        [XmlElement("MsgType")]
        public string Type { get; set; }

        /// <summary>
        /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)
        /// </summary>
        public FromEventTypes Event { get; set; }
    }
}
