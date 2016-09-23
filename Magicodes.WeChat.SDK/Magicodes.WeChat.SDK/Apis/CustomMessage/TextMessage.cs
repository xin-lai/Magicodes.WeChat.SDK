// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TextMessage.cs
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
    ///     文本消息
    /// </summary>
    public class TextMessage : CustomMessageSendApiResultBase
    {
        public TextMessage()
        {
            Type = MessageTypes.text;
        }

        [JsonProperty("text")]
        public Text TextContent { get; set; }

        public class Text
        {
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }
}