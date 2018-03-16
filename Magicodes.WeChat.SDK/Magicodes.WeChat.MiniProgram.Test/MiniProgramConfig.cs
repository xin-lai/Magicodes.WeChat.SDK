using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.WeChat.SDK;

namespace Magicodes.WeChat.MiniProgram.Test
{
    public class MiniProgramConfig : IMiniProgramConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}
