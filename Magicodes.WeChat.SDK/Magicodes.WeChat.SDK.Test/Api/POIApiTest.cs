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
using System.IO;
using System.Reflection;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class POIApiTest : ApiTestBase
    {
        private readonly POIApi _weChatApi = WeChatApisContext.Current.POIApi;

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
            }
        }
    }
}