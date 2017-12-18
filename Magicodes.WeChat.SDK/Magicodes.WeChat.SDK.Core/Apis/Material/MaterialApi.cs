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

using System.Collections.Generic;
using System.IO;
using System.Text;
using Magicodes.WeChat.SDK.Apis.Material.Enums;
using Magicodes.WeChat.SDK.Core.Apis.Material;
using Magicodes.WeChat.SDK.Helper;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Material
{
    /// <summary>
    ///     永久素材接口
    /// </summary>
    public class MaterialApi : ApiBase
    {
        private const string ApiName = "material";

        /// <summary>
        ///     根据ID获取素材
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
        ///     获取非图文、视频素材
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
        ///     获取永久素材列表
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
                return Post<NewsGetApiResult>(url, data);
            return Post<OtherMaterialResult>(url, data);
        }


        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public NewsPostApiResult AddNews(NewsPostInput news)
        {
            //获取api请求url
            var url = GetAccessApiUrl("add_news", ApiName);
            return Post<NewsPostApiResult>(url, news, inputStr => inputStr);
        }

        /// <summary>
        /// 上传永久素材（图片（image）、语音（voice）、视频（video）和缩略图（thumb））
        /// </summary>
        /// <param name="file"></param>
        /// <param name="title"></param>
        /// <param name="introduction"></param>
        /// <param name="materialType"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public UploadForeverMaterialApiResult UploadForeverMaterial(string file, string title, string introduction, MaterialType materialType, int timeOut = 40000)
        {
            var url = GetAccessApiUrl("add_material", ApiName, urlParams: new Dictionary<string, string>() {
                {"type",materialType.ToString() }
            });
            var resultStr = RequestUtility.HttpPost(
                url,
                null,
                null,
                new Dictionary<string, string>
                {
                    ["media"] = file,
                }, encoding: Encoding.UTF8);
            var result = JsonConvert.DeserializeObject<UploadForeverMaterialApiResult>(resultStr);
            if (result != null)
                result.DetailResult = resultStr;
            RefreshAccessTokenWhenTimeOut(result);
            return result;
        }

        /// <summary>
        /// 上传图文消息内的图片获取URL
        /// 本接口所上传的图片不占用公众号的素材库中图片数量的5000个的限制。图片仅支持jpg/png格式，大小必须在1MB以下。
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public UploadImageApiResult UploadImage(string fileName)
        {
            //获取api请求url
            var url = GetAccessApiUrl("uploadimg", "media");
            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return Post<UploadImageApiResult>(url, fileName, fileStream);
            }

        }
    }
}