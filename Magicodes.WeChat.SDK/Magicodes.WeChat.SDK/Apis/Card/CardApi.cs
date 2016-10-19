// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CardApi.cs
//          description :
//  
//          created by 李文强 at  2016/10/13 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub：https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    ///     卡券接口
    /// </summary>
    public class CardApi : ApiBase
    {
        private const string ApiName = "card";

        /// <summary>
        ///     获取AccessToken
        /// </summary>
        /// <returns></returns>
        public ApiResult Add(CardInfo cardInfo)
        {
            //获取api请求url
            var url = GetAccessApiUrl("create", ApiName);
            var result = Post<ApiResult>(url, cardInfo);
            return result;
        }


    }
}