using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.WeChat.MiniProgram.Test
{
    public class MiniProgramConfig : IMiniProgramConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string MchId { get; set; }
        public string PayNotify { get; set; }
        public string TenPayKey { get; set; }
    }
}
