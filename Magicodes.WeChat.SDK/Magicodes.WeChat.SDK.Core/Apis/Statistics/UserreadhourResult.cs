// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserreadhourResult.cs
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
    ///     图文分时数据统计
    /// </summary>
    public class UserreadhourResult : ApiResult
    {
        /// <summary>
        ///     图文分时数据统计集合
        /// </summary>
        [JsonProperty("list")]
        public List<UserreadhourInfo> UserreadhourList { get; set; }

        public class UserreadhourInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     数据的小时，包括从000到2300，分别代表的是[000,100)到[2300,2400)，即每日的第1小时和最后1小时
            /// </summary>
            [JsonProperty("ref_hour")]
            public long RefHour { get; set; }

            /// <summary>
            ///     在获取图文阅读分时数据时才有该字段，代表用户从哪里进入来阅读该图文。
            ///     0:会话;1.好友;2.朋友圈;3.腾讯微博;4.历史消息页;5.其他
            /// </summary>
            [JsonProperty("user_source")]
            public ReadUserSourceType ReadUserSource { get; set; }

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
            ///     ori_page_read_count
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