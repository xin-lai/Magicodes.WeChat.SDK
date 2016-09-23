using Magicodes.WeChat.SDK.Apis.CustomerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    [TestClass]
    public class CustomerServiceApiTest : ApiTestBase
    {
        readonly CustomerServiceApi _weChatApi = new CustomerServiceApi();

        [TestMethod]
        public void CustomerServiceApiTest_GetCustomerAccountList()
        {
            var result = _weChatApi.GetCustomerAccountList();
            if (!result.IsSuccess())
            {
                Assert.Fail("获取多客服账号列表失败，返回结果如下：" + result.DetailResult);
            }
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
                {
                    Assert.Fail("修改客服账号失败，返回结果如下：" + result.DetailResult);
                }
                result = _weChatApi.RemoveCustomerAccount(testAccountName);
                if (!result.IsSuccess())
                {
                    Assert.Fail("删除客服账号失败，返回结果如下：" + result.DetailResult);
                }
            }
        }
    }
}
