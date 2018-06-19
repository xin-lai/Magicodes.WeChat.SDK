// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WxCardMessage.cs
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
    /// Defines the <see cref="WxCardMessage" />
    /// </summary>
    public class WxCardMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WxCardMessage"/> class.
        /// </summary>
        public WxCardMessage()
        {
            Type = MessageTypes.wxcard;
        }

        /// <summary>
        /// Gets or sets the WxCardContent
        /// </summary>
        [JsonProperty("wxcard")]
        public WxCard WxCardContent { get; set; }

        /// <summary>
        /// Defines the <see cref="WxCard" />
        /// </summary>
        public class WxCard
        {
            /// <summary>
            /// Gets or sets the Id
            /// </summary>
            [JsonProperty("card_id")]
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets the CardExtInfo
            /// </summary>
            [JsonProperty("card_ext")]
            public CardExt CardExtInfo { get; set; }

            /// <summary>
            /// Defines the <see cref="CardExt" />
            /// </summary>
            public class CardExt
            {
                /// <summary>
                /// Gets or sets the Code
                /// </summary>
                [JsonProperty("code")]
                public string Code { get; set; }

                /// <summary>
                /// Gets or sets the OpenId
                /// </summary>
                [JsonProperty("openid")]
                public string OpenId { get; set; }

                /// <summary>
                /// Gets or sets the TimeStamp
                /// </summary>
                [JsonProperty("timestamp")]
                public string TimeStamp { get; set; }

                /// <summary>
                /// Gets or sets the Signature
                /// </summary>
                [JsonProperty("signature")]
                public string Signature { get; set; }
            }
        }
    }
}
