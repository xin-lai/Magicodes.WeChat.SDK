// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MessageApiResult.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:47:59
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Apis.Message.Result
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="MessageApiResult" />
    /// </summary>
    public class MessageApiResult : ApiResult
    {
        /// <summary>
        /// Gets or sets the MessageId
        /// </summary>
        [JsonProperty("msg_id")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the MessageDataId
        /// </summary>
        [JsonProperty("msg_data_id")]
        public string MessageDataId { get; set; }
    }
}
