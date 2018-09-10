using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    /// 小程序菜单
    /// </summary>
    public class MiniprogramButton : MenuButtonBase
    {
        public MiniprogramButton()
        {
            Type = MenuButtonTypes.miniprogram;
        }

        /// <summary>
        ///     小程序的appid（仅认证公众号可配置）（miniprogram类型必须）
        /// </summary>
        [JsonProperty(PropertyName = "appid")]
        public new string AppId { get; set; }

        /// <summary>
        ///     小程序的页面路径
        /// </summary>
        [JsonProperty(PropertyName = "pagepath")]
        public string Pagepath { get; set; }
    }
}
