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

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;

    /// <summary>
    /// 多图文消息
    /// </summary>
    public class MpNewsMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// 多图文 <see cref="MpNewsMessage"/> class.
        /// </summary>
        public MpNewsMessage()
        {
            Type = MessageTypes.mpnews;
        }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("mpnews")]
        public MpNews MpNewsContent { get; set; }

        /// <summary>
        /// Defines the <see cref="MpNews" />
        /// </summary>
        public class MpNews
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}
