// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : OpenIdListGetApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.User
{
    /// <summary>
    ///     关注者账号列表
    /// </summary>
    public class OpenIdListGetApiResult : ApiResult
    {
        /// <summary>
        ///     关注该公众账号的总用户数
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        ///     拉取的OPENID个数，最大值为10000
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        ///     拉取列表的最后一个用户的OPENID
        /// </summary>
        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }

        /// <summary>
        ///     OpenId列表
        /// </summary>
        [JsonProperty("data")]
        public OpenIdListGetData Data { get; set; }

        public override bool IsSuccess()
        {
            return string.IsNullOrEmpty(Message);
        }

        public class OpenIdListGetData
        {
            /// <summary>
            ///     OPENID列表
            /// </summary>
            [JsonProperty("openid")]
            public string[] OpenIds { get; set; }
        }
    }
}