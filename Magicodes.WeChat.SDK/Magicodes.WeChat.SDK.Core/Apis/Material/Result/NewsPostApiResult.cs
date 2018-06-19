// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsPostApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.Material
{
    using Newtonsoft.Json;

    /// <summary>
    /// 新增的图文消息素材的media_id
    /// </summary>
    public class NewsPostApiResult : ApiResult
    {
        /// <summary>
        /// Gets or sets the MediaId
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// The IsSuccess
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public override bool IsSuccess()
        {
            return base.IsSuccess() && !string.IsNullOrWhiteSpace(MediaId);
        }
    }
}
