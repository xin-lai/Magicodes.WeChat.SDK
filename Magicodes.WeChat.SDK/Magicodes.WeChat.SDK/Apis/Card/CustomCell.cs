using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 自定义会员信息类目，会员卡激活后显示。
    /// </summary>
    public class CustomCell
    {
        /// <summary>
        /// 使用入口名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 使用入口提示(激活后显示)
        /// </summary>
        [JsonProperty("tips")]
        public string Tips { get; set; }

        /// <summary>
        /// 使用入品URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
