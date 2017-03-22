// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MessageApiTest.cs
//          description :
//  
//          created by 李文强 at  2017/03/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.CustomerService;
using Magicodes.WeChat.SDK.Apis.Message;
using Magicodes.WeChat.SDK.Apis.Message.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class MessageApiTest : ApiTestBase
    {
        private readonly MessageApi _weChatApi = WeChatApisContext.Current.MessageApi;

        [TestMethod]
        public void MessageApiTest_Preview()
        {
            var input = new PreviewTextInput()
            {
                Text = new PreviewTextInput.TextInfo()
                {
                    Content = "Test"
                },
                ToWXName = "mhpyxinxing"
            };
            var result = _weChatApi.Preview(input);
            if (!result.IsSuccess())
                Assert.Fail("调用群发预览接口（微信号）失败，返回结果如下：" + result.DetailResult);

            input.ToWXName = null;
            input.ToUser = "ol0uwwQx3L889et9cL_SyjDFPNXI";
            result = _weChatApi.Preview(input);
            if (!result.IsSuccess())
                Assert.Fail("调用群发预览接口（OpenId）失败，返回结果如下：" + result.DetailResult);

            
            //var img = new PreviewImageInput()
            //{
            //    Image = new PreviewImageInput.ImageInfo()
            //    {
            //        //MediaId=
            //    }
            //};

            //TODO:其他类型
        }

        //TODO:其他接口
    }
}