using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public class NameUrls
    {
        /// <summary>
        ///  名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// 自定义url请填写http://或者https://开头的链接     
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
