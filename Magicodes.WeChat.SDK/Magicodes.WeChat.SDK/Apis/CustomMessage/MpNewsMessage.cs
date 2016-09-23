// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MpNewsMessage.cs
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
    ///     多图文消息
    /// </summary>
    public class MpNewsMessage : CustomMessageSendApiResultBase
    {
        public MpNewsMessage()
        {
            Type = MessageTypes.mpnews;
        }

        [JsonProperty("mpnews")]
        public MpNews MpNewsContent { get; set; }

        public class MpNews
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}