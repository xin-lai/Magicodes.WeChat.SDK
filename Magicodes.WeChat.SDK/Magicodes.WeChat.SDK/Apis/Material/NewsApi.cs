// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsApi.cs
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
    /// <summary>
    ///     多图文接口
    /// </summary>
    public class NewsApi : ApiBase
    {
        private const string ApiName = "material";

        /// <summary>
        ///     获取多图文素材
        /// </summary>
        /// <param name="id">要获取的素材的media_id</param>
        /// <returns>图文消息结果</returns>
        public NewsGetApiResult Get(string id)
        {
            //获取api请求url
            var url = GetAccessApiUrl("get_material", ApiName);
            var data = new
            {
                media_id = id
            };
            return Post<NewsGetApiResult>(url, data);
        }

        public ApiResult Get(int offset = 0, int count = 20)
        {
            //获取api请求url
            var url = GetAccessApiUrl("batchget_material", ApiName);
            var data = new
            {
                type = "news",
                offset,
                count
            };
            return Post<ApiResult>(url, data);
        }


        public NewsPostApiResult Post(NewsPostModel news)
        {
            //获取api请求url
            var url = GetAccessApiUrl("add_news", ApiName);
            return Post<NewsPostApiResult>(url, news, inputStr => inputStr);
        }
    }
}