// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ArticlesummaryApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     图文群发每日数结果统计
    ///     某天所有被阅读过的文章（仅包括群发的文章）在当天的阅读次数等数据。
    /// </summary>
    public class ArticlesummaryApiResult : ApiResult
    {
        /// <summary>
        ///     图文群发每日数据集合
        /// </summary>
        [JsonProperty("list")]
        private List<ArticlesummaryInfo> ArtiList { get; set; }

        /// <summary>
        ///     图文群发每日数据信息
        /// </summary>
        public class ArticlesummaryInfo
        {
            /// <summary>
            ///     数据的日期
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     这里的msgid实际上是由msgid（图文消息id，这也就是群发接口调用后返回的msg_data_id）
            ///     和index（消息次序索引）组成，
            ///     例如12003_3， 其中12003是msgid，即一次群发的消息的id； 3为index，
            ///     假设该次群发的图文消息共5个文章（因为可能为多图文），3表示5个中的第3个
            /// </summary>
            [JsonProperty("msgid")]
            public string MsgId { get; set; }

            /// <summary>
            ///     图文消息标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            ///     图文页（点击群发图文卡片进入的页面）的阅读人数
            /// </summary>
            [JsonProperty("int_page_read_user")]
            public long IntPageReadUser { get; set; }

            /// <summary>
            ///     图文页的阅读次数
            /// </summary>
            [JsonProperty("int_page_read_count")]
            public long IntPageReadCount { get; set; }

            /// <summary>
            ///     原文页（点击图文页“阅读原文”进入的页面）的阅读人数，无原文页时此处数据为0
            /// </summary>
            [JsonProperty("ori_page_read_user")]
            public long OriPageReadUser { get; set; }

            /// <summary>
            ///     原文页的阅读次数
            /// </summary>
            [JsonProperty("ori_page_read_count")]
            public long OriPageReadCount { get; set; }

            /// <summary>
            ///     分享的人数
            /// </summary>
            [JsonProperty("share_user")]
            public long ShareUser { get; set; }

            /// <summary>
            ///     分享的次数
            /// </summary>
            [JsonProperty("share_count")]
            public long ShareCount { get; set; }

            /// <summary>
            ///     收藏的人数
            /// </summary>
            [JsonProperty("add_to_fav_user")]
            public long AddToFavUser { get; set; }

            /// <summary>
            ///     收藏的次数
            /// </summary>
            [JsonProperty("add_to_fav_count")]
            public long AddToFavCount { get; set; }
        }
    }
}