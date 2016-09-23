using System;
using Magicodes.WeChat.SDK.Apis.QRCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    [TestClass]
    public class QRCodeApiTest : ApiTestBase
    {
        QRCodeApi weChatApi = new QRCodeApi();
        public QRCodeApiTest()
        {
            weChatApi.SetKey(1);
        }

        [TestMethod]
        public void QRCodeApiTest_CreateByNumberValue()
        {
            var result = weChatApi.CreateByNumberValue(new Random().Next(1, 100000));
            if (!result.IsSuccess())
            {
                Assert.Fail("创建二维码失败，返回结果如下：" + result.DetailResult);
            }
        }
    }
}
