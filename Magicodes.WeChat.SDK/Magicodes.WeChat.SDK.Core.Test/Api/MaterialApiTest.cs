// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using Magicodes.WeChat.SDK.Apis.Material;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Magicodes.WeChat.SDK.Helper;
using System.IO;
using System.Reflection;
using System;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class MaterialApiTest : ApiTestBase
    {
        private readonly MaterialApi api = WeChatApisContext.Current.MaterialApi;

        public MaterialApiTest()
        {
        }

        [TestMethod]
        public void NewsApiTest_GetById()
        {
            //var testNews = db.Site_News.FirstOrDefault();
            //if (testNews == null)
            //{
            //    Assert.Fail("没有数据！");
            //}
            //var result = api.Get(testNews.MediaId);
            //if (!result.IsSuccess())
            //{
            //    Assert.Fail("获取多图文信息失败，返回结果如下：" + result.DetailResult);
            //}
        }

        //[TestMethod]
        //public void NewsApiTest_Get()
        //{
        //    var type = Apis.Material.Enums.MaterialType.video;
        //    //aa5fe50648fb489a8083cdd203370470.jpg
        //    var result = api.Get(type);
        //    var tempResult = (OtherMaterialResult)result;
        //    var videoresult = api.GetMaterialById<GetVideoMaterialResult>(tempResult.Items[0].MediaId);
        //    var bytes = RequestUtility.HttpUploadData(videoresult.DownUrl, tempResult.Items[0].MediaId);
        //    File.WriteAllBytes("E://Test.mp4", bytes);
        //    if (!result.IsSuccess())
        //        Assert.Fail("获取多图文信息失败，返回结果如下：" + result.DetailResult);

        //}

        [TestMethod]
        public void UploadForeverMaterial_Video()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resource", "test.mp4");
            var result = api.UploadForeverMaterial(file, "测试", "测试", Apis.Material.Enums.MaterialType.video);
            if (!result.IsSuccess())
            {
                Assert.Fail("上传视频素材失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void UploadForeverMaterial_Image()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resource", "test.jpg");
            var result = api.UploadForeverMaterial(file, "测试", "测试", Apis.Material.Enums.MaterialType.image);
            if (!result.IsSuccess())
            {
                Assert.Fail("上传图片素材失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void UploadImage()
        {
            string file = Path.Combine(Environment.CurrentDirectory, "Resource", "test.jpg");
            var result = api.UploadImage(file);
            if (!result.IsSuccess())
            {
                Assert.Fail("上传图片素材失败，返回结果如下：" + result.DetailResult);
            }
            System.Console.WriteLine(result.DetailResult);
        }

        [TestMethod]
        public void NewsGet()
        {
            string id = "8jBK8ujsrMrVlS1rn-SMikIjyhlnHczeS6SBbT8ledk";
            var bytes = api.GetOtherMaterialById(id);
            var file = Path.Combine(Environment.CurrentDirectory, "Resource", "Test.mp3");
            File.WriteAllBytes(file, bytes);

        }


        //[TestMethod]
        //public void NewsApiTest_Post()
        //{
        //    //不能使用第三方的图片
        //    var model = new NewsPostModel
        //    {
        //        Articles = new List<NewsPostModel.ArticleInfo>
        //        {
        //            new NewsPostModel.ArticleInfo
        //            {
        //                Author = "liwq",
        //                Content =
        //                    "<p><img data-s=\"300,640\" data-type=\"png\" data-src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" data-ratio=\"0.7733812949640287\" data-w=\"\"  /><br  /></p><p><span style=\"line-height: 25.6px;\">“Magicodes.WeiChat，是由Magicode.WeiChat团队打造的一个基于ASP.NET &nbsp; MVC5微信业务快速开发与定制的开发框架。目的让微信业务开发与定制更快速、简单。”</span></p>",
        //                ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
        //                Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
        //                ShowCoverPic = 0,
        //                ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
        //                Title = "版本历史"
        //            },
        //            new NewsPostModel.ArticleInfo
        //            {
        //                Author = "liwq",
        //                Content =
        //                    "<p><img data-s=\"300,640\" data-type=\"png\" data-src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" data-ratio=\"0.7733812949640287\" data-w=\"\"  /><br  /></p><p><span style=\"line-height: 25.6px;\">“Magicodes.WeiChat，是由Magicode.WeiChat团队打造的一个基于ASP.NET &nbsp; MVC5微信业务快速开发与定制的开发框架。目的让微信业务开发与定制更快速、简单。”</span></p>",
        //                ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
        //                Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
        //                ShowCoverPic = 0,
        //                ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
        //                Title = "版本历史"
        //            },
        //            new NewsPostModel.ArticleInfo
        //            {
        //                Author = "liwq",
        //                Content =
        //                    "<div><img src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" /></div>",
        //                ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
        //                Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
        //                ShowCoverPic = 0,
        //                ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
        //                Title = "版本历史"
        //            },
        //            new NewsPostModel.ArticleInfo
        //            {
        //                Author = "liwq",
        //                Content =
        //                    "<div><img src=\"http://mmbiz.qpic.cn/mmbiz/SLeRFiaVmNAS3kOq3icjbfpz1GicHibTN4P9jicick8xyiaia8TMEzafuB4dSBfba5IdshdYX2qXJqBP689NMhPHuo3PsQ/0?wx_fmt=png\" /></div>",
        //                ContentSourceUrl = "http://www.cnblogs.com/codelove/p/5306395.html",
        //                Digest = "每周一小更，每月一大更。我们要做最好的微信快速定制开发框架。",
        //                ShowCoverPic = 0,
        //                ThumbMediaId = "HXIy1CJD5Qt12D9XBuSx0pXEqWaCbkwdYwCQ50spLlE",
        //                Title = "版本历史"
        //            }
        //        }
        //    };
        //    var result = api.Post(model);
        //    if (!result.IsSuccess())
        //        Assert.Fail("添加多图文信息失败，返回结果如下：" + result.DetailResult);
        //}
    }
}