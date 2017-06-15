using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.To
{
    /// <summary>
    ///     ªÿ∏¥”Ô“Ùœ˚œ¢
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ToVoiceMessage : ToMessageBase
    {
        public ToVoiceMessage()
        {
            Type = ToMessageTypes.voice;
        }

        public VoiceInfo Voice { get; set; }

        [Serializable]
        public class VoiceInfo
        {
            public string MediaId { get; set; }
        }
    }
}