using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    ///     回复图文消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToNewsMessage : ToMessageBase
    {
        public ToNewsMessage()
        {
            Type = ToMessageTypes.news;
            Articles = new List<ArticleInfo>();
        }

        /// <summary>
        ///     图文消息个数，限制为10条以内
        /// </summary>
        [XmlElement("ArticleCount")]
        public int ArticleCount { get; set; }

        /// <summary>
        ///     多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// </summary>
        [XmlArrayItem("Item")]
        public List<ArticleInfo> Articles { get; set; }

        [Serializable]
        public class ArticleInfo
        {
            /// <summary>
            ///     图文消息标题
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            ///     图文消息描述
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            ///     图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
            /// </summary>
            public string PicUrl { get; set; }

            /// <summary>
            ///     点击图文消息跳转链接
            /// </summary>
            public string Url { get; set; }
        }
    }
}