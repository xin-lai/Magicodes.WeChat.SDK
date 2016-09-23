// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateMessageGetAPIResult.cs
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
}