using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    /// ªÿ∏¥”Ô“Ùœ˚œ¢
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToVoiceMessage : ToMessageBase
    {
        public ToVoiceMessage()
        {
            Type = ToMessageTypes.voice;
        }

        [Serializable]
        public class VoiceInfo
        {
            public string MediaId { get; set; }
        }

        public VoiceInfo Voice { get; set; }
    }
}