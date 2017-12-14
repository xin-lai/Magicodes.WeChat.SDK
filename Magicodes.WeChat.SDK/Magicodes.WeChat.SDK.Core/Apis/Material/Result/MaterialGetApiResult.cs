// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsGetApiResult.cs
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
    #region 获取素材列表

    /// <summary>
    ///     素材通用实体
    /// </summary>
    public class MaterialBaseResult : ApiResult
    {
        /// <summary>
        ///     该类型的素材的总数
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        /// <summary>
        ///     本次调用获取的素材的数量
        /// </summary>
        [JsonProperty("item_count")]
        public int ItemCount { get; set; }
    }

    #region 多图文消息

    /// <summary>
    ///     多图文素材获取结果
    /// </summary>
    public class NewsGetApiResult : MaterialBaseResult
    {
        /// <summary>
        ///     图文消息列表
        /// </summary>
        [JsonProperty("item")]
        public List<ArticleNews> Item { get; set; }
    }


    public class ArticleNews
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("content")]
        public ArticlContent Content { get; set; }

        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }
    }

    public class ArticlContent
    {
        /// <summary>
        ///     文章列表
        /// </summary>
        [JsonProperty("news_item")]
        public List<ArticleInfo> Items { get; set; }
    }

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
        ///     图文页的URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        ///     图文消息的原文地址，即点击“阅读原文”后的URL
        /// </summary>
        [JsonProperty("content_source_url")]
        public string ContentSourceUrl { get; set; }

        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
    }

    #endregion

    #region 其他类型素材

    /// <summary>
    ///     其他类型（图片、语音、视频）
    /// </summary>
    public class OtherMaterialResult : MaterialBaseResult
    {
        /// <summary>
        ///     其他素材列表
        /// </summary>
        [JsonProperty("item")]
        public List<OtherItem> Items { get; set; }
    }

    public class OtherItem
    {
        /// <summary>
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        ///     素材名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     更新日期
        /// </summary>
        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }

        /// <summary>
        ///     素材链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    #endregion

    #endregion

    /// <summary>
    ///     根据Id获取多图文返回实体
    /// </summary>
    public class GetNewsByMaterialResult : ApiResult
    {
        [JsonProperty("news_item")]
        public List<ArticleInfo> List { get; set; }

        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }
    }

    /// <summary>
    ///     根据ID获取视频素材返回实体
    /// </summary>
    public class GetVideoMaterialResult : ApiResult
    {
        /// <summary>
        ///     标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     下载链接
        /// </summary>
        [JsonProperty("down_url")]
        public string DownUrl { get; set; }
    }
}