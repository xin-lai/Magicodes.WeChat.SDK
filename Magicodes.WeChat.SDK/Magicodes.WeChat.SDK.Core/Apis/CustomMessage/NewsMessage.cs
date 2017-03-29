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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    /// <summary>
    ///     多图文消息
    /// </summary>
    public class NewsMessage : CustomMessageSendApiResultBase
    {
        public NewsMessage()
        {
            Type = MessageTypes.news;
        }

        [JsonProperty("news")]
        public News NewsContent { get; set; }

        public class News
        {
            [JsonProperty("articles")]
            public List<Article> Articles { get; set; }

            public class Article
            {
                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("description")]
                public string Description { get; set; }

                [JsonProperty("url")]
                public string Url { get; set; }

                [JsonProperty("picurl")]
                public string PicUrl { get; set; }
            }
        }
    }
}