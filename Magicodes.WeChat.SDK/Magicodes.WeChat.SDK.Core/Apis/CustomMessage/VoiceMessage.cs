// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : VoiceMessage.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;

    /// <summary>
    /// 语音消息
    /// </summary>
    public class VoiceMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceMessage"/> class.
        /// </summary>
        public VoiceMessage()
        {
            Type = MessageTypes.voice;
        }

        /// <summary>
        /// Gets or sets the VoiceContent
        /// </summary>
        [JsonProperty("voice")]
        public Voice VoiceContent { get; set; }

        /// <summary>
        /// Defines the <see cref="Voice" />
        /// </summary>
        public class Voice
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}
