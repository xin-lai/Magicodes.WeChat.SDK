// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MessagesTemplateLogFuncModel.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;

namespace Magicodes.WeChat.SDK.Apis.TemplateMessage
{
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