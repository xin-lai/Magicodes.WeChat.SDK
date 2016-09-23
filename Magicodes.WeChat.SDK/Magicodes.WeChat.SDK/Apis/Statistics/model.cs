// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : model.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     用户数据统计入参模型 Add by zp 2016-01-05
    /// </summary>
    public class UserAnalysisModel
    {
        /// <summary>
        ///     获取数据的开始日期入参 最大时间跨度为7天 即开始时间和结束时间只差只能小于7
        /// </summary>
        [JsonProperty("begin_date")]
        public string BeginDate { get; set; }

        /// <summary>
        ///     获取数据的结束时间
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }
    }

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

    /// <summary>
    ///     图文群发每日数结果统计
    ///     某天所有被阅读过的文章（仅包括群发的文章）在当天的阅读次数等数据。
    /// </summary>
    public class ArticlesummaryResult : ApiResult
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

    /// <summary>
    ///     图文群发总数据统计
    /// </summary>
    public class ArticletotalResult : ApiResult
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


    /// <summary>
    ///     消息发送概况数据 Add by zp 2016-01-12
    /// </summary>
    public class UpstreammsgResult : ApiResult
    {
        [JsonProperty("list")]
        public UpstreammsgInfo UpstreammsgList { get; set; }

        /// <summary>
        ///     消息发送信息 (微信出参)
        /// </summary>
        public class UpstreammsgInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

            /// <summary>
            ///     消息类型
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

    /// <summary>
    ///     获取消息发送周数据 集合 Add by zp 2016-01-12
    /// </summary>
    public class UpstreammsgweekResult : ApiResult
    {
        [JsonProperty("list")]
        private List<UpstreammsgweekInfo> UpstreammsgweekList { get; set; }

        public class UpstreammsgweekInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

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

    /// <summary>
    ///     获取消息发送月数据 集合 Add by zp 2016-01-12
    /// </summary>
    public class UpstreammsgmonthResult : ApiResult
    {
        [JsonProperty("list")]
        public List<UpstreammsgmonthInfo> UpstreammsgmonthList { get; set; }

        public class UpstreammsgmonthInfo
        {
            /// <summary>
            ///     数据的日期，需在begin_date和end_date之间
            /// </summary>
            [JsonProperty("ref_date")]
            public DateTime RefDate { get; set; }

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

    /// <summary>
    ///     获取消息发送分布数据 集合 Add by zp 2016-01-12
    /// </summary>
    public class UpstreammsgdistResult : ApiResult
    {
        [JsonProperty("list")]
        public List<UpstreammsgdistInfo> UpstreammsgdistList { get; set; }

        public class UpstreammsgdistInfo
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

    /// <summary>
    ///     获取消息发送分布周数据 集合 Add by zp 2016-01-12
    /// </summary>
    public class UpstreammsgdistweekResult : ApiResult
    {
        [JsonProperty("list")]
        public List<UpstreammsgdistweekInfo> UpstreammsgdistweekList { get; set; }

        public class UpstreammsgdistweekInfo
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

    /// <summary>
    ///     获取消息发送分布月数据
    /// </summary>
    public class UpstreammsgdistmonthResult : ApiResult
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


    /// <summary>
    ///     消息发送消息类型
    /// </summary>
    public enum UpstreammsgType
    {
        文字 = 1,
        图片 = 2,
        语音 = 3,
        视频 = 4,
        第三方应用消息 = 6
    }

    /// <summary>
    ///     用户新增数的用户渠道
    /// </summary>
    public enum SersummaryUserSourceType
    {
        其他合计 = 0,
        公众号搜索 = 1,
        名片分享 = 17,
        扫描二维码 = 30,
        图文页右上角菜单 = 43,
        支付后关注 = 51,
        图文页内公众号名称 = 57,
        公众号文章广告 = 75,
        朋友圈广告 = 78
    }

    /// <summary>
    ///     图文阅读分时数据的用户渠道
    /// </summary>
    public enum ReadUserSourceType
    {
        会话 = 0,
        好友 = 1,
        朋友圈 = 2,
        腾讯微博 = 3,
        历史消息页 = 4,
        其他 = 5
    }

    /// <summary>
    ///     获取图文分享转发 分享的场景
    /// </summary>
    public enum ShareScenType
    {
        好友转发 = 1,
        朋友圈 = 2,
        腾讯微博 = 3,
        其他 = 255
    }
}