// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TokenApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Token
{
    public class TokenApiResult : ApiResult
    {
        /// <summary>
        ///     获取到的凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     凭证有效时间，单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        internal int Expires { get; set; }

        /// <summary>
        ///     凭证过期时间
        /// </summary>
        public DateTime ExpiresTime { get; set; }
    }
}