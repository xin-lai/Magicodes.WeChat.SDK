// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UsershareResult.cs
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
    ///     图文分享转发数据统计
    /// </summary>
    public class UsershareResult : ApiResult
    {
        /// <summary>
        ///     图文分享转发数据集合
        /// </summary>
        [JsonProperty("list")]
        public List<UsershareInfo> UsershareList { get; set; }

        public class UsershareInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     分享的场景
            /// </summary>
            [JsonProperty("share_scene")]
            public ShareScenType ShareScene { get; set; }

            /// <summary>
            ///     分享的次数
            /// </summary>
            [JsonProperty("share_count")]
            public long ShareCount { get; set; }

            /// <summary>
            ///     分享的人数
            /// </summary>
            [JsonProperty("share_user")]
            public long ShareUser { get; set; }
        }
    }
}