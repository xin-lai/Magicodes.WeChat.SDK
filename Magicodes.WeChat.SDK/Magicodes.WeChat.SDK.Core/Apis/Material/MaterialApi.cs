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

using Magicodes.WeChat.SDK.Apis.Material.Enums;
using Magicodes.WeChat.SDK.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.Material
{
    /// <summary>
    ///  永久素材接口
    /// </summary>
    public class MaterialApi : ApiBase
    {
        private const string ApiName = "material";

        /// <summary>
        ///   根据ID获取素材
        /// </summary>
        /// <param name="id">要获取的素材的media_id</param>
        /// <returns>素材结果</returns>
        public T GetMaterialById<T>(string id) where T : ApiResult
        {
            //获取api请求url
            var url = GetAccessApiUrl("get_material", ApiName);
            var data = new
            {
                media_id = id
            };
            return Post<T>(url, data);
        }

        /// <summary>
        /// 获取非图文、视频素材
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public byte[] GetOtherMaterialById(string id)
        {
            var url = GetAccessApiUrl("get_material", ApiName);
            var data = new
            {
                media_id = id
            };
            return RequestUtility.HttpUploadData(url, JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// 获取永久素材列表
        /// </summary>
        /// <param name="materialType">素材类型</param>
        /// <param name="offset">从全部素材的该偏移位置开始返回，0表示从第一个素材 返回</param>
        /// <param name="count">返回素材的数量，取值在1到20之间</param>
        /// <returns></returns>
        public ApiResult Get(MaterialType materialType, int offset = 0, int count = 20)
        {
            //获取api请求url
            var url = GetAccessApiUrl("batchget_material", ApiName);
            var data = new
            {
                type = materialType.ToString(),
                offset,
                count
            };
            if (materialType == MaterialType.news)
            {
                return Post<NewsGetApiResult>(url, data);
            }
            else
            {
                return Post<OtherMaterialResult>(url, data);
            }
        }


        public NewsPostApiResult Post(NewsPostModel news)
        {
            //获取api请求url
            var url = GetAccessApiUrl("add_news", ApiName);
            return Post<NewsPostApiResult>(url, news, inputStr => inputStr);
        }

        public string UploadForeverVideo(string file, string title,string introduction, int timeOut = 40000)
        {
            var url = GetAccessApiUrl("add_material", ApiName);
            var fileDictionary = new Dictionary<string, string>
            {
                ["media"] = file,
                ["description"] = string.Format("{{\"title\":\"{0}\", \"introduction\":\"{1}\"}}", title, introduction)
            };
            var result = RequestUtility.HttpPost(url, null, fileDictionary, null, timeOut);
            return result;
        }
    }
}