// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsMessage.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// 多图文消息
    /// </summary>
    public class NewsMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewsMessage"/> class.
        /// </summary>
        public NewsMessage()
        {
            Type = MessageTypes.news;
        }

        /// <summary>
        /// Gets or sets the NewsContent
        /// </summary>
        [JsonProperty("news")]
        public News NewsContent { get; set; }

        /// <summary>
        /// Defines the <see cref="News" />
        /// </summary>
        public class News
        {
            /// <summary>
            /// Gets or sets the Articles
            /// </summary>
            [JsonProperty("articles")]
            public List<Article> Articles { get; set; }

            /// <summary>
            /// Defines the <see cref="Article" />
            /// </summary>
            public class Article
            {
                /// <summary>
                /// Gets or sets the Title
                /// </summary>
                [JsonProperty("title")]
                public string Title { get; set; }

                /// <summary>
                /// Gets or sets the Description
                /// </summary>
                [JsonProperty("description")]
                public string Description { get; set; }

                /// <summary>
                /// Gets or sets the Url
                /// </summary>
                [JsonProperty("url")]
                public string Url { get; set; }

                /// <summary>
                /// Gets or sets the PicUrl
                /// </summary>
                [JsonProperty("picurl")]
                public string PicUrl { get; set; }
            }
        }
    }
}
