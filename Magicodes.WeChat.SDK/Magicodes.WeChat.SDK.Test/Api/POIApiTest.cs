// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomerServiceApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.CustomerService;
using Magicodes.WeChat.SDK.Apis.POI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class POIApiTest : ApiTestBase
    {
        private readonly POIApi _weChatApi = WeChatApisContext.Current.POIApi;

        [TestMethod]
        public void POIApiTest_Get()
        {
            var poiResult = _weChatApi.Get();
            if (!poiResult.IsSuccess())
                Assert.Fail("查询门店失败，返回结果如下：" + poiResult.DetailResult + "；Msg:" + poiResult.GetFriendlyMessage());
            WeChatHelper.ApiLogger.Log(Logger.LoggerLevels.Debug, "门店数：" + poiResult.BusinessList.Count);
        }
        [TestMethod]
        public void POIApiTest_Add()
        {
            var model = new POIInfo()
            {
                Address = "湖南省长沙市岳麓区岳麓大道218号",
                AvgPrice = 1,
                BranchName = "岳麓店",
                Categorys = "美食,粤菜,潮汕菜".Split(';'),
                City = "长沙市",
                District = "岳麓区",
                Introduction = "Test",
                Latitude = 28.228209,
                Longitude = 112.938812,
                Name = "Test",
                OpenTime = "8:00~22:00",
                Province = "湖南省",
                Recommend = "Test",
                Special = "Test",
                SID = System.Guid.NewGuid().ToString("N"),
                Telephone = "13671974358",
                PhotoList = new List<POIPhotoInfo>()
            };
            using (var fs = GetInputFile("qrcode.jpg"))
            {
                var result = _weChatApi.UploadImage("qrcode.jpg", fs);
                if (!result.IsSuccess())
                    Assert.Fail("上传图片失败，返回结果如下：" + result.DetailResult + "；Msg:" + result.GetFriendlyMessage());
                model.PhotoList.Add(new POIPhotoInfo()
                {
                    PhotoUrl = result.Url
                });
                var poiResult = _weChatApi.Add(model);
                if (!poiResult.IsSuccess())
                    Assert.Fail("创建门店失败，返回结果如下：" + poiResult.DetailResult + "；Msg:" + poiResult.GetFriendlyMessage());
            }
        }

        [TestMethod]
        public void POIApiTest_GetCategoryList()
        {
            var result = _weChatApi.GetCategoryList();
            if (!result.IsSuccess())
                Assert.Fail("获取类目列表失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void POIApiTest_UploadImage()
        {
            using (var fs = GetInputFile("qrcode.jpg"))
            {
                var result = _weChatApi.UploadImage("qrcode.jpg", fs);
                if (!result.IsSuccess())
                    Assert.Fail("上传图片失败，返回结果如下：" + result.DetailResult + "；Msg:" + result.GetFriendlyMessage());
                WeChatHelper.ApiLogger.Log(Logger.LoggerLevels.Debug, result.DetailResult);
            }
        }
    }
}