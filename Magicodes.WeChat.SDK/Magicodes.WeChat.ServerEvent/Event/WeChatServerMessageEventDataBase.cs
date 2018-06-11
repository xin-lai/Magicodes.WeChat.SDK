using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.WeChat.SDK.Core.ServerMessages.From;
using Magicodes.WeChat.SDK.Core.ServerMessages.To;

namespace Magicodes.WeChat.Web.Core.Event
{
    public class WeChatServerMessageEventDataBase : EventData
    {
        public int? TenantId { get; set; }

        public ToMessageBase ToMessage { get; set; }
    }
}
