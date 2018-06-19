// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UploadForeverMaterialApiResult.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:47:53
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Core.Apis.Material
{
    using Magicodes.WeChat.SDK.Apis;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="UploadForeverMaterialApiResult" />
    /// </summary>
    public class UploadForeverMaterialApiResult : ApiResult
    {
        /// <summary>
        /// 新增的永久素材的media_id
        /// </summary>
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        /// <summary>
        /// 新增的图片素材的图片URL（仅新增图片素材时会返回该字段）
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
