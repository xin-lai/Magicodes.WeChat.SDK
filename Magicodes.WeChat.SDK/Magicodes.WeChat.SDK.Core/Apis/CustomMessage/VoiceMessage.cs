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

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    /// <summary>
    ///     语音消息
    /// </summary>
    public class VoiceMessage : CustomMessageSendApiResultBase
    {
        public VoiceMessage()
        {
            Type = MessageTypes.voice;
        }

        [JsonProperty("voice")]
        public Voice VoiceContent { get; set; }

        public class Voice
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}