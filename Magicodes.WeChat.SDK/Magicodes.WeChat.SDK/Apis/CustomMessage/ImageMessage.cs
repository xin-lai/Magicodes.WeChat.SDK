// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ImageMessage.cs
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
    ///     图片消息
    /// </summary>
    public class ImageMessage : CustomMessageSendApiResultBase
    {
        public ImageMessage()
        {
            Type = MessageTypes.image;
        }

        [JsonProperty("image")]
        public Image ImageContent { get; set; }

        public class Image
        {
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}