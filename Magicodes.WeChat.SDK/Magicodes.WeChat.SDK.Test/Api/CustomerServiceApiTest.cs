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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class CustomerServiceApiTest : ApiTestBase
    {
        private readonly CustomerServiceApi _weChatApi = new CustomerServiceApi();

        [TestMethod]
        public void CustomerServiceApiTest_GetCustomerAccountList()
        {
            var result = _weChatApi.GetCustomerAccountList();
            if (!result.IsSuccess())
                Assert.Fail("获取多客服账号列表失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void CustomerServiceApiTest_CRUDCustomerAccount()
        {
            var testAccountName = "Test";
            _weChatApi.RemoveCustomerAccount(testAccountName);
            var result = _weChatApi.AddCustomerAccount(testAccountName, "Test", "111111");
            if (!result.IsSuccess())
            {
                Assert.Fail("创建客服账号失败，返回结果如下：" + result.DetailResult);
            }
            else
            {
                result = _weChatApi.UpdateCustomerAccount(testAccountName, "TestUpdate", "222222");
                if (!result.IsSuccess())
                    Assert.Fail("修改客服账号失败，返回结果如下：" + result.DetailResult);
                result = _weChatApi.RemoveCustomerAccount(testAccountName);
                if (!result.IsSuccess())
                    Assert.Fail("删除客服账号失败，返回结果如下：" + result.DetailResult);
            }
        }
    }
}