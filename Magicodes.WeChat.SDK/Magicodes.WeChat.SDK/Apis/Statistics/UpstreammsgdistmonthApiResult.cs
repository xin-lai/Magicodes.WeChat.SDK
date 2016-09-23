// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UpstreammsgdistmonthApiResult.cs
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
    ///     获取消息发送分布月数据
    /// </summary>
    public class UpstreammsgdistmonthApiResult : ApiResult
    {
        [JsonProperty("list")]
        public List<UpstreammsgdistmonthInfo> UpstreammsgdistmonthList { get; set; }

        public class UpstreammsgdistmonthInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     当日发送消息量分布的区间，0代表 “0”，1代表“1-5”，2代表“6-10”，3代表“10次以上”
            /// </summary>
            [JsonProperty("count_interval")]
            public int CountInterval { get; set; }

            /// <summary>
            ///     上行发送了（向公众号发送了）消息的用户数
            /// </summary>
            [JsonProperty("msg_user")]
            public long MsgUser { get; set; }
        }
    }
}