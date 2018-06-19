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

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;

    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage : CustomMessageSendApiResultBase
    {
        /// <summary>
        /// 初始化图片消息 the <see cref="ImageMessage"/> class.
        /// </summary>
        public ImageMessage()
        {
            Type = MessageTypes.image;
        }

        /// <summary>
        /// 图片
        /// </summary>
        [JsonProperty("image")]
        public Image ImageContent { get; set; }

        /// <summary>
        /// 图片定义 <see cref="Image" />
        /// </summary>
        public class Image
        {
            /// <summary>
            /// Gets or sets the MediaId
            /// </summary>
            [JsonProperty("media_id")]
            public string MediaId { get; set; }
        }
    }
}
