// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.TemplateMessage
{
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
}