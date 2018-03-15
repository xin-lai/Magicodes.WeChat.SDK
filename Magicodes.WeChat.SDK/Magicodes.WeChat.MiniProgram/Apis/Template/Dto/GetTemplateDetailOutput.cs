using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Template.Dto
{
    public class GetTemplateDetailOutput : ApiOutput
    {
        /// <summary>
        /// 模板标题id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 模板标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 模板关键字列表
        /// </summary>
        [JsonProperty("keyword_list")]
        public List<KeywordListDto> KeywordList { get; set; }
    }

    public class KeywordListDto
    {
        /// <summary>
        /// 关键词id，添加模板时需要
        /// </summary>
        [JsonProperty("keyword_id")]
        public int Id { get; set; }

        /// <summary>
        /// 关键词内容
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 关键词内容对应的示例
        /// </summary>
        [JsonProperty("example")]
        public string Example { get; set; }
    }
}
