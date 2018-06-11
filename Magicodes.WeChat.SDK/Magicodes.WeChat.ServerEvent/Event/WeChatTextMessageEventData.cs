using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Events.Bus;
using Magicodes.WeChat.SDK.Core.ServerMessages.From;
using Magicodes.WeChat.SDK.Core.ServerMessages.To;

namespace Magicodes.WeChat.Web.Core.Event
{
    /// <summary>
    /// 文本消息事件
    /// </summary>
    public class WeChatTextMessageEventData : WeChatServerMessageEventDataBase
    {
        public FromTextMessage FromMessage { get; set; }
    }
}
