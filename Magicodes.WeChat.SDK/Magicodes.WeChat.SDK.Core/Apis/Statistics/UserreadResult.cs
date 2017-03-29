// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserreadResult.cs
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
    ///     图文统计数据统计
    /// </summary>
    public class UserreadResult : ApiResult
    {
        /// <summary>
        ///     图文统计数据统计集合
        /// </summary>
        [JsonProperty("list")]
        public List<UserreadInfo> UserreadList { get; set; }

        public class UserreadInfo
        {
            /// <summary>
            ///     数据的日期
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     图文页的阅读人数
            /// </summary>
            [JsonProperty("int_page_read_user")]
            public long IntPageReadUser { get; set; }

            /// <summary>
            ///     图文页的阅读次数
            /// </summary>
            [JsonProperty("int_page_read_count")]
            public long IntPageReadCount { get; set; }

            /// <summary>
            ///     原文页的阅读人数
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