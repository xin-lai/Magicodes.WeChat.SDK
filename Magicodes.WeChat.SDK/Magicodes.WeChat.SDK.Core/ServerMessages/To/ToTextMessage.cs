using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    /// 回复文本消息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToTextMessage : ToMessageBase
    {
        public ToTextMessage()
        {
            Type = ToMessageTypes.text;
        }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
