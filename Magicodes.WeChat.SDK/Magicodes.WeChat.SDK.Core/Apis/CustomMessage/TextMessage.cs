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

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;

    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextMessage"/> class.
        /// </summary>
        public TextMessage()
        {
            Type = MessageTypes.text;
        }

        /// <summary>
        /// Gets or sets the TextContent
        /// </summary>
        [JsonProperty("text")]
        public Text TextContent { get; set; }

        /// <summary>
        /// Defines the <see cref="Text" />
        /// </summary>
        public class Text
        {
            /// <summary>
            /// Gets or sets the Content
            /// </summary>
            [JsonProperty("content")]
            public string Content { get; set; }
        }
    }
}
