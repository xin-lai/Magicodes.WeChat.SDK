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
using System.IO;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    /// <summary>
    ///     卡券接口
    /// </summary>
    public class POIApi : ApiBase
    {
        private const string ApiName = "poi";

        /// <summary>
        /// 添加门店
        /// </summary>
        /// <param name="model">门店信息</param>
        /// <returns></returns>
        public ApiResult Add(POIInfo model)
        {
            //获取api请求url
            var url = GetAccessApiUrl("addpoi", ApiName);
            var data = new
            {
                business = new
                {
                    base_info = model
                }
            };
            return Post<ApiResult>(url, data);
        }
        /// <summary>
        /// 删除POI
        /// </summary>
        /// <param name="poiId">门店ID，审核事件返回</param>
        /// <returns></returns>
        public ApiResult Remove(string poiId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("delpoi", ApiName);
            var data = new
            {
                poi_id = poiId
            };
            return Post<ApiResult>(url, data);
        }

        /// <summary>
        /// 获取门店详细信息
        /// </summary>
        /// <param name="poiId">门店ID，审核事件返回</param>
        /// <returns></returns>
        public GetPOIDetailInfoAPIResult GetPOIDetailInfo(string poiId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("getpoi", ApiName);
            var data = new
            {
                poi_id = poiId
            };
            return Post<GetPOIDetailInfoAPIResult>(url, data);
        }

        /// <summary>
        /// 获取门店列表信息
        /// </summary>
        /// <param name="poiId">门店ID，审核事件返回</param>
        /// <returns></returns>
        public GetApiResult Get(int begin = 0, int limit = 10)
        {
            //获取api请求url
            var url = GetAccessApiUrl("getpoilist", ApiName);
            var data = new
            {
                begin = begin,
                limit = limit
            };
            return Post<GetApiResult>(url, data);
        }

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

        /// <summary>
        /// 上传门店图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileStream">文件流</param>
        /// <returns></returns>
        public UploadImageApiResult UploadImage(string fileName, Stream fileStream)
        {
            //获取api请求url
            var url = GetAccessApiUrl("uploadimg", "media");
            return Post<UploadImageApiResult>(url, fileName, fileStream);
        }
    }
}