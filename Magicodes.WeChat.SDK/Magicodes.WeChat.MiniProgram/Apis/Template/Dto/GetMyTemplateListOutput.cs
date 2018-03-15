using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Template.Dto
{
    public class GetMyTemplateListOutput : ApiOutput
    {
        /// <summary>
        /// 帐号下的模板列表
        /// </summary>
        [JsonProperty("list")]
        public List<MyTemplateListDto> List { get; set; }
    }

    public class MyTemplateListDto
    {
        /// <summary>
        /// 添加至帐号下的模板id，发送小程序模板消息时所需
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 模板内容示例
        /// </summary>
        [JsonProperty("example")]
        public string Example { get; set; }
    }
}
