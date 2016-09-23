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

namespace Magicodes.WeChat.SDK.Apis.TemplateMessage
{
    public class TemplateMessageAddTemplateAPIResult : ApiResult
    {
        /// <summary>
        ///     模板消息编号
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
    }

    public class TemplateMessageGetAPIResult : ApiResult
    {
        [JsonProperty("template_list")]
        public TemplateList[] Templates { get; set; }

        public class TemplateList
        {
            /// <summary>
            ///     模板ID
            /// </summary>
            [JsonProperty("template_id")]
            public string TemplateId { get; set; }

            /// <summary>
            ///     模板标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            ///     模板所属行业的一级行业
            /// </summary>
            [JsonProperty("primary_industry")]
            public string PrimaryIndustry { get; set; }

            /// <summary>
            ///     模板所属行业的二级行业
            /// </summary>
            [JsonProperty("deputy_industry")]
            public string DeputyIndustry { get; set; }

            /// <summary>
            ///     模板内容
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }

            /// <summary>
            ///     模板示例
            /// </summary>
            [JsonProperty("example")]
            public string Example { get; set; }
        }
    }

    /// <summary>
    ///     模板消息
    /// </summary>
    public class TemplateMessageCreateModel
    {
        /// <summary>
        ///     接收人openId，多个请以分号分隔
        /// </summary>
        public string ReceiverIds { get; set; }

        /// <summary>
        ///     模板消息编号
        /// </summary>
        public string MessagesTemplateNo { get; set; }

        /// <summary>
        ///     顶部颜色
        /// </summary>
        public string TopColor { get; set; }

        /// <summary>
        ///     链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     模板消息数据,如：
        ///     serviceInfo : new TemplateDataItem("您好，您的服务单123456789有新的客服回复。")
        ///     remark : new TemplateDataItem("详细处理结果请点击“详情”查看。", "#173177"),
        /// </summary>
        public Dictionary<string, TemplateDataItem> Data { get; set; }
    }

    /// <summary>
    ///     模板消息的数据项类型
    /// </summary>
    public class TemplateDataItem
    {
        /// <summary>
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="color">color</param>
        public TemplateDataItem(string value, string color = "#173177")
        {
            Value = value;
            Color = color;
        }

        /// <summary>
        ///     项目值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     16进制颜色代码，如：#FF0000
        /// </summary>
        public string Color { get; set; }
    }

    /// <summary>
    ///     模板消息API请求结果
    /// </summary>
    public class TemplateApiResult : ApiResult
    {
        /// <summary>
        ///     消息Id
        /// </summary>
        [JsonProperty("msgid")]
        public string MessageId { get; set; }
    }

    public class MessagesTemplateLogFuncModel
    {
        /// <summary>
        ///     批次号
        /// </summary>
        public Guid BatchNumber { get; set; }

        /// <summary>
        ///     模板消息编号
        /// </summary>
        public string MessagesTemplateNo { get; set; }

        /// <summary>
        ///     消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        ///     创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        ///     接收人
        /// </summary>
        public string ReceiverId { get; set; }

        /// <summary>
        ///     顶部颜色
        /// </summary>
        public string TopColor { get; set; }

        /// <summary>
        ///     链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     发送结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        ///     是否发送成功
        /// </summary>
        public bool IsSuccess { get; set; }
    }
}