// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ArticletotalApiResult.cs
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
    ///     图文群发总数据统计
    /// </summary>
    public class ArticletotalApiResult : ApiResult
    {
        /// <summary>
        ///     图文群发总数据集合
        /// </summary>
        [JsonProperty("list")]
        public List<ArticletotalInfo> ArtiList { get; set; }

        public class ArticletotalInfo
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
            ///     图文群发总数据明细集合
            /// </summary>
            [JsonProperty("details")]
            public List<ArticletotalDetail> ArtiDetails { get; set; }

            public struct ArticletotalDetail
            {
                /// <summary>
                ///     统计日期
                /// </summary>
                [JsonProperty("stat_date")]
                public DateTime Statdate { get; set; }

                /// <summary>
                ///     送达人数，一般约等于总粉丝数（需排除黑名单或其他异常情况下无法收到消息的粉丝）
                /// </summary>
                [JsonProperty("target_user")]
                public long TargetUser { get; set; }

                /// <summary>
                ///     图文页（点击群发图文卡片进入的页面）的阅读人数
                /// </summary>
                [JsonProperty("int_page_read_user")]
                public long IntPargeReadUser { get; set; }

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
}