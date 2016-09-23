// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UpstreammsghourResult.cs
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
    ///     获取消息分送分时数据集合 Add by zp 2016-01-12
    /// </summary>
    public class UpstreammsghourResult : ApiResult
    {
        [JsonProperty("list")]
        public List<UpstreammsghourInfo> UpstreammsghourList { get; set; }

        /// <summary>
        ///     获取消息分送分时数据出参
        /// </summary>
        public class UpstreammsghourInfo
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
            ///     消息类型，代表含义如下：
            ///     1代表文字 2代表图片 3代表语音 4代表视频 6代表第三方应用消息（链接消息）
            /// </summary>
            [JsonProperty("msg_type")]
            public UpstreammsgType MsgType { get; set; }

            /// <summary>
            ///     上行发送了（向公众号发送了）消息的用户数
            /// </summary>
            [JsonProperty("msg_user")]
            public long MsgUser { get; set; }

            /// <summary>
            ///     上行发送了消息的消息总数
            /// </summary>
            [JsonProperty("msg_count")]
            public long MsgCount { get; set; }
        }
    }
}