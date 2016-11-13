// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : QRCodeApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Magicodes.WeChat.SDK.Apis.QRCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class QRCodeApiTest : ApiTestBase
    {
        private readonly QRCodeApi weChatApi = WeChatApisContext.Current.QrCodeApi;

        public QRCodeApiTest()
        {
        }

        [TestMethod]
        public void QRCodeApiTest_CreateByNumberValue()
        {
            var result = weChatApi.CreateByNumberValue(new Random().Next(1, 100000));
            if (!result.IsSuccess())
                Assert.Fail("创建二维码失败！错误消息：" + result.GetFriendlyMessage() + "\n返回结果如下：" + result.DetailResult);
        }
    }
}