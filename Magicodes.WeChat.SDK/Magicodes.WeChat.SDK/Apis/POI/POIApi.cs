// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : POIApi.cs
//          description :
//  
//          created by 李文强 at  2016/10/19 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub：https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    /// <summary>
    ///     卡券接口
    /// </summary>
    public class POIApi : ApiBase
    {
        private const string ApiName = "poi";

        /// <summary>
        ///     获取AccessToken
        /// </summary>
        /// <returns></returns>
        public GetCategoryListApiResult GetCategoryList()
        {
            //获取api请求url
            var url = GetAccessApiUrl("getwxcategory", ApiName);
            return Get<GetCategoryListApiResult>(url);
        }
    }
}