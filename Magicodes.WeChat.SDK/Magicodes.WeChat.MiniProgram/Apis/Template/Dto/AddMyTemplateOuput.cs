using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis.Template.Dto
{
    public class AddMyTemplateOuput: ApiOutput
    {
        /// <summary>
        /// 添加至帐号下的模板id，发送小程序模板消息时所需
        /// </summary>
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
    }
}
