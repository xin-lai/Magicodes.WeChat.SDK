// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserSummaryAnalyisResult.cs
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
    ///     获取用户增减数据模型  对应的数据库表结构是什么样子?
    /// </summary>
    public class UserSummaryAnalyisResult : ApiResult
    {
        /// <summary>
        ///     用户增减数据集合
        /// </summary>
        [JsonProperty("list")]
        public List<UserSersummaryInfo> SersummaryList { get; set; }

        public override bool IsSuccess()
        {
            return Message == null;
        }

        /// <summary>
        ///     用户增减数信息
        /// </summary>
        public class UserSersummaryInfo
        {
            /// <summary>
            ///     取消关注的用户数量，new_user减去cancel_user即为净增用户数量
            /// </summary>
            [JsonProperty("cancel_user")] public long CancelUser;

            /// <summary>
            ///     数据的日期
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     用户的渠道
            ///     0代表其他合计;
            ///     1代表公众号搜索;
            ///     17代表名片分享;
            ///     30代表扫描二维码;
            ///     43代表图文页右上角菜单;
            ///     51代表支付后关注（在支付完成页）;
            ///     57代表图文页内公众号名称 ;
            ///     75代表公众号文章广告;
            ///     78代表朋友圈广告;
            /// </summary>
            [JsonProperty("user_source")]
            public SersummaryUserSourceType UserSource { get; set; }

            /// <summary>
            ///     新增的用户数量
            /// </summary>
            [JsonProperty("new_user")]
            public long NewUser { get; set; }
        }
    }
}