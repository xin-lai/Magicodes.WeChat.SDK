using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.ServerMessages
{
    [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ServerMessageBase
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 	发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MsgTypes MsgType { get; set; }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
    }
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MsgTypes
    {
        text=0,
        image=1,
        voice=2,
        video=3,
        shortvideo=4,
        location=5,
        link=6
    }

    [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class TextMessage
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        /// <remarks/>
        public DateTime CreateTime { get;set; }

        /// <remarks/>
        public string MsgType { get; set; }

        /// <remarks/>
        public string Content { get; set; }

        /// <remarks/>
        public long MsgId { get; set; }
    }


}
