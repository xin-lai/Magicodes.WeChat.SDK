// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateMessageCreateModel.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.TemplateMessage
{
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
}