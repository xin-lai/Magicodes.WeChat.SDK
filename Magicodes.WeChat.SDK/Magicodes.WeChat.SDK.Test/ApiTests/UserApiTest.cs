using System;
using Magicodes.WeChat.SDK.Apis.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    /// <summary>
    /// 用户组API测试
    /// </summary>
    [TestClass]
    public class UserApiTest : ApiTestBase
    {
        UserApi api = new UserApi();
        public UserApiTest()
        {
        }

        [TestMethod]
        public void UserApiTest_ALL()
        {
            //获取测试用户
            var testUsersOpenIds = TestOpenIdList;
            if (testUsersOpenIds.Count == 0)
            {
                Assert.Fail("测试失败，必须设置测试账户，见WeiChat_User中的AllowTest！");
            }
            #region 添加备注
            foreach (var item in testUsersOpenIds)
            {
                var result = api.SetRemark(item, "Test");
                if (!result.IsSuccess())
                {
                    Assert.Fail("更新备注信息失败，返回结果如下：" + result.DetailResult);
                }
            }
            #endregion
            #region 获取用户信息
            foreach (var item in testUsersOpenIds)
            {
                var result = api.Get(item);
                if (!result.IsSuccess())
                {
                    Assert.Fail("获取用户信息失败，返回结果如下：" + result.DetailResult);
                }
                if (result.SubscribeTime == default(DateTime))
                {
                    Assert.Fail("获取用户关注时间失败，返回结果如下：" + result.DetailResult);
                }
            }
            #endregion
            #region 批量获取
            var batchResult = api.Get(testUsersOpenIds.ToArray());
            if (!batchResult.IsSuccess())
            {
                Assert.Fail("批量获取用户失败，返回结果如下：" + batchResult.DetailResult);
            }
            foreach (var item in batchResult.UserInfoList)
            {
                if (item.SubscribeTime == default(DateTime))
                {
                    Assert.Fail("获取用户关注时间失败，返回结果如下：" + batchResult.DetailResult);
                }
            }
            #endregion;
            #region 获取帐号的关注者列表
            var openIdsResult = api.GetOpenIdList();
            if (!openIdsResult.IsSuccess())
            {
                Assert.Fail("获取帐号的关注者列表失败，返回结果如下：" + openIdsResult.DetailResult);
            } 
            #endregion
        }
    }
}
