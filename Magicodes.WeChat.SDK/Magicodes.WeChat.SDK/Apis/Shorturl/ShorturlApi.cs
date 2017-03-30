// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ShorturlApi.cs
//          description :
//  
//          created by 李文强 at  2017/03/30 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.Shorturl.Result;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Shorturl
{
    /// <summary>
    ///     长链接转短链接接口
    ///     https://api.weixin.qq.com/cgi-bin/shorturl?access_token=ACCESS_TOKEN
    /// </summary>
    public class ShorturlApi : ApiBase
    {
        private const string ApiName = "shorturl";

        /// <summary>
        ///     长链接转短链接接口
        ///     https://api.weixin.qq.com/cgi-bin/shorturl?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="menuJson">菜单请求json格式</param>
        /// <returns>返回操作结果</returns>
        public ShortUrlApiResult GetShortUrl(string url)
        {
            var apiUrl = GetAccessApiUrl(null, ApiName);
            return Post<ShortUrlApiResult>(apiUrl, new { action = "long2short", long_url = url });
        }


    }
}