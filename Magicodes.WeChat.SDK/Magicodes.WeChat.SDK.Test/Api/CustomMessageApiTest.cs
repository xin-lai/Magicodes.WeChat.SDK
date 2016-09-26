// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomMessageApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.CustomMessage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class CustomMessageApiTest : ApiTestBase
    {
        private readonly CustomMessageApi weChatApi = WeChatApisContext.Current.CustomMessageApi;

        public CustomMessageApiTest()
        {
        }

        [TestMethod]
        public void CustomMessageApiTest_SendTextMessage()
        {
            //发送文本客服消息
            var result = weChatApi.SendTextMessage(new TextMessage
            {
                TextContent = new TextMessage.Text
                {
                    Content = "Test_SendTextMessage"
                },
                Touser = TestOpenId
            });
            if (!result.IsSuccess())
                Assert.Fail("发送文本客服消息失败，返回结果如下：" + result.DetailResult);
        }
    }
}