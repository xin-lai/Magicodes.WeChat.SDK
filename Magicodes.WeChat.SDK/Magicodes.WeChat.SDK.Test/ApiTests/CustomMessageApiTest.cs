using System;
using Magicodes.WeChat.SDK.Apis.CustomMessage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    [TestClass]
    public class CustomMessageApiTest : ApiTestBase
    {
        CustomMessageApi weChatApi = new CustomMessageApi();
        public CustomMessageApiTest()
        {
            weChatApi.SetKey(1);
        }

        [TestMethod]
        public void CustomMessageApiTest_SendTextMessage()
        {
            //发送文本客服消息
            var result = weChatApi.SendTextMessage(new TextMessage()
            {
                TextContent = new TextMessage.Text()
                {
                    Content = "Test_SendTextMessage",
                },
                Touser = TestOpenId
            });
            if (!result.IsSuccess())
            {
                Assert.Fail("发送文本客服消息失败，返回结果如下：" + result.DetailResult);
            }
        }

    }
}
