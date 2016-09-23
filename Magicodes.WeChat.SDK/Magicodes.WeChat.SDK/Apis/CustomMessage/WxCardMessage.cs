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

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    public class WxCardMessage : CustomMessageSendApiResultBase
    {
        public WxCardMessage()
        {
            Type = MessageTypes.wxcard;
        }

        [JsonProperty("wxcard")]
        public WxCard WxCardContent { get; set; }

        public class WxCard
        {
            [JsonProperty("card_id")]
            public string Id { get; set; }

            [JsonProperty("card_ext")]
            public CardExt CardExtInfo { get; set; }

            public class CardExt
            {
                [JsonProperty("code")]
                public string Code { get; set; }

                [JsonProperty("openid")]
                public string OpenId { get; set; }

                [JsonProperty("timestamp")]
                public string TimeStamp { get; set; }

                [JsonProperty("signature")]
                public string Signature { get; set; }
            }
        }
    }
}