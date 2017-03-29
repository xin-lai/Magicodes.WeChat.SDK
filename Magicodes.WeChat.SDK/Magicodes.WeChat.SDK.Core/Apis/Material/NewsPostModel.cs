// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsPostModel.cs
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

namespace Magicodes.WeChat.SDK.Apis.Material
{
    public class NewsPostModel
    {
        /// <summary>
        ///     文章列表
        /// </summary>
        [JsonProperty("articles")]
        public List<ArticleInfo> Articles { get; set; }

        /// <summary>
        ///     文章信息
        /// </summary>
        public class ArticleInfo
        {
            /// <summary>
            ///     图文消息的标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            ///     图文消息的封面图片素材id（必须是永久mediaID）
            /// </summary>
            [JsonProperty("thumb_media_id")]
            public string ThumbMediaId { get; set; }

            /// <summary>
            ///     是否显示封面，0为false，即不显示，1为true，即显示
            /// </summary>
            [JsonProperty("show_cover_pic")]
            public int ShowCoverPic { get; set; }

            /// <summary>
            ///     作者
            /// </summary>
            [JsonProperty("author")]
            public string Author { get; set; }

            /// <summary>
            ///     图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空
            /// </summary>
            [JsonProperty("digest")]
            public string Digest { get; set; }

            /// <summary>
            ///     图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }

            /// <summary>
            ///     图文消息的原文地址，即点击“阅读原文”后的URL
            /// </summary>
            [JsonProperty("content_source_url")]
            public string ContentSourceUrl { get; set; }
        }
    }
}