using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Template.Dto
{
    public class GetTemplateListOutput : ApiOutput
    {
        [JsonProperty("list")]
        public List<LibraryListDto> List { get; set; }


        /// <summary>
        /// 模板库标题总数
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }

    public class LibraryListDto
    {
        /// <summary>
        /// 模板标题id（获取模板标题下的关键词库时需要）
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 模板标题内容
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
