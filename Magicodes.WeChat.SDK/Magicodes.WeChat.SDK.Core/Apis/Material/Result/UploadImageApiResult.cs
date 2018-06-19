// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UploadImageApiResult.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:47:53
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Apis.Material
{
    using Newtonsoft.Json;

    /// <summary>
    /// 图片上传结果
    /// </summary>
    public class UploadImageApiResult : ApiResult
    {
        /// <summary>
        /// 上传图片的URL，可放置图文消息中、门店中使用
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
