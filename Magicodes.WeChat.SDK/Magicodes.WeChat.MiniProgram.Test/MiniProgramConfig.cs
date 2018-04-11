using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.Pay.WeChat;
using Magicodes.Pay.WeChat.Config;

namespace Magicodes.WeChat.MiniProgram.Test
{
    public class MiniProgramConfig : IMiniProgramConfig, IWeChatPayConfig
    {
        public string MiniProgramAppId { get; set; }
        public string MiniProgramAppSecret { get; set; }
        public string MchId { get; set; }
        public string TenPayKey { get; set; }
        public string NotifyUrl { get; set; }
    }
}
