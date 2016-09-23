// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserCumulateAnalyisResult.cs
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
    ///     获取用户累计数 数据模型
    /// </summary>
    public class UserCumulateAnalyisResult : ApiResult
    {
        /// <summary>
        ///     累计用户数据集合
        /// </summary>
        [JsonProperty("list")]
        public List<UserCumulateInfo> CumulateList { get; set; }

        public override bool IsSuccess()
        {
            return Message == null;
        }

        /// 累计用户数据信息
        /// </summary>
        public class UserCumulateInfo
        {
            /// <summary>
            ///     数据的日期
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     总用户量
            /// </summary>
            [JsonProperty("cumulate_user")]
            public long CumulateUser { get; set; }
        }
    }
}