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
using Magicodes.WeChat.SDK.Apis.Shorturl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class ShorturlApiTest : ApiTestBase
    {
        private readonly ShorturlApi _weChatApi = WeChatApisContext.Current.ShorturlApi;

        [TestMethod]
        public void ShorturlApi_Test()
        {

            var result = _weChatApi.GetShortUrl("http://xin-lai.com/web/Product/WeiChat");
            if (!result.IsSuccess())
                Assert.Fail("调用长链接转短链接接口失败，返回结果如下：" + result.DetailResult);
        }
    }
}