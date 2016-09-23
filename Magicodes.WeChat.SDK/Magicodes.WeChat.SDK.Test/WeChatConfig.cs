using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Test
{
    public class WeChatConfig : IWeChatConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string WeiXinAccount { get; set; }
        public string Token { get; set; }
    }
}
