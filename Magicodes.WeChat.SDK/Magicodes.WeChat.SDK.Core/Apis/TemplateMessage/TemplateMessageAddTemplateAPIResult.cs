// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateMessageAddTemplateAPIResult.cs
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
    public class TemplateMessageAddTemplateAPIResult : ApiResult
    {
        /// <summary>
        ///     模板消息编号
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
    }
}