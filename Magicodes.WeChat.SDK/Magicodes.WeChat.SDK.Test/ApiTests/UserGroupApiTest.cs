using System.Linq;
using Magicodes.WeChat.SDK.Apis.UserGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    /// <summary>
    /// 用户组API测试
    /// </summary>
    [TestClass]
    public class UserGroupApiTest : ApiTestBase
    {
        UserGroupApi api = new UserGroupApi();
        public UserGroupApiTest()
        {
        }

        [TestMethod]
        public void UserGroupApiTest_CURD()
        {
            if (TestOpenIdList.Count == 0)
            {
                Assert.Fail("测试失败，必须设置测试账户，见WeiChat_User中的AllowTest！");
            }
            #region 查询测试
            var getResult = api.Get();
            if (getResult.Groups.Count == 0)
            {
                Assert.Fail("创建组失败或查询失败，返回结果如下：" + getResult.DetailResult);
            }
            #endregion
            #region 测试创建
            var createResult = api.Create("Test");
            if (!createResult.IsSuccess())
            {
                Assert.Fail("测试失败，返回结果如下：" + createResult.DetailResult);
            }
            #endregion
            #region 查询测试（ById）
            var getByIdResult = api.GetById(TestOpenIdList.First());
            if (!getByIdResult.IsSuccess())
            {
                Assert.Fail("查询用户所在组失败，返回结果如下：" + getByIdResult.DetailResult);
            }
            #endregion
            System.Threading.Thread.Sleep(10000);
            #region 修改测试
            var updateResult = api.Update(createResult.Group.Id, "Rename Test");
            if (!updateResult.IsSuccess())
            {
                Assert.Fail("用户组信息修改失败，返回结果如下：" + updateResult.DetailResult);
            }
            #endregion
            //该接口不耐操，需要等待
            System.Threading.Thread.Sleep(20000);
            #region 移动用户分组测试
            var memeberUpdateResult = api.MemeberUpdate(TestOpenIdList.First(), createResult.Group.Id);
            if (!memeberUpdateResult.IsSuccess())
            {
                Assert.Fail("移动用户分组失败，返回结果如下：{0}，输入信息：{1}", memeberUpdateResult.DetailResult, createResult.Group.Id);
            }
            #endregion
            //该接口不耐操，需要等待
            System.Threading.Thread.Sleep(15000);
            #region 批量移动用户分组测试
            getResult = api.Get();
            var memeberUpdateResult_ = api.MemeberUpdate(TestOpenIdList.ToArray(), createResult.Group.Id);
            if (!memeberUpdateResult_.IsSuccess())
            {
                Assert.Fail("批量移动用户分组测试，返回结果如下：" + memeberUpdateResult_.DetailResult);
            }
            #endregion
            //该接口不耐操，需要等待
            System.Threading.Thread.Sleep(10000);
            #region 删除测试
            getResult = api.Get();
            foreach (var item in getResult.Groups)
            {
                if (item.Name == "Test" || item.Name == "Rename Test")
                {
                    TestContext.WriteLine("删除信息id：{0}，name：{1}", item.Id, item.Name);
                    var deleteResult = api.Delete(item.Id);
                    if (!deleteResult.IsSuccess() && deleteResult.DetailResult != "{}")
                    {
                        Assert.Fail("删除测试分组失败，返回结果如下：{0}，输入参数：{1}", deleteResult.DetailResult, item.Id);
                    }
                }
            }
            #endregion
        }
    }
}
