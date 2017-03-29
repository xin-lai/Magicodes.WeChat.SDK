// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UsersharehourResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     图文分享转发每日数据
    /// </summary>
    public class UsersharehourResult : ApiResult
    {
        public class UsersharehourInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     数据的小时，包括从000到2300，分别代表的是[000,100)到[2300,2400)，
            ///     即每日的第1小时和最后1小时
            /// </summary>
            [JsonProperty("ref_hour")]
            public long RefHour { get; set; }

            /// <summary>
            ///     分享的场景
            /// </summary>
            [JsonProperty("share_scene")]
            public ShareScenType ShareScen { get; set; }

            /// <summary>
            ///     分享的次数
            /// </summary>
            [JsonProperty("share_count")]
            public long ShareCount { get; set; }

            /// <summary>
            ///     分享的人数
            /// </summary>
            [JsonProperty("share_user")]
            public long SharaUser { get; set; }
        }
    }
}