using Magicodes.WeChat.SDK.Apis.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    [TestClass]
    public class MenusApiTest : ApiTestBase
    {
        MenuApi weChatApi = new MenuApi();
        public MenusApiTest()
        {
            weChatApi.SetKey(1);
        }

        [TestMethod]
        public void MenusApiTest_Get()
        {
            var result = weChatApi.Get();
            if (!result.IsSuccess())
            {
                Assert.Fail("获取菜单数据失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void MenusApiTest_Create()
        {        
            string menuJson = "{\"button\":[{\"type\":\"click\",\"name\":\"今日歌曲\",\"key\":\"V1001_TODAY_MUSIC\"},{\"name\":\"菜单\",\"sub_button\":[{\"type\":\"view\",\"name\":\"搜索\",\"url\":\"http://www.soso.com/\"},{\"type\":\"view\",\"name\":\"视频\",\"url\":\"http://v.qq.com/\"},{\"type\":\"click\",\"name\":\"赞一下我们\",\"key\":\"V1001_GOOD\"}]}]}";

            MenuInfo model = JsonConvert.DeserializeObject<MenuInfo>(menuJson);
            var result = weChatApi.Create(model);
            if (!result.IsSuccess())
            {
                Assert.Fail("创建菜单数据失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void MenuApiTest_Delete()
        {
            var result = weChatApi.Delete();
            if (!result.IsSuccess())
            {
                Assert.Fail("删除菜单数据失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void MenuApiTest_GetCurrentSelfmenuInfo()
        {
            var result = weChatApi.GetCurrentSelfmenuInfo();
            if (!result.IsSuccess())
            {
                Assert.Fail("获取自定义菜单配置数据失败，返回结果如下：" + result.DetailResult);
            }
        }

        #region 个性化菜单接口单元测试
        [TestMethod]
        public void MenuApiTest_AddConditional()
        {
            string menuJson = "{\"button\":[{\"type\":\"click\",\"name\":\"今日歌曲\",\"key\":\"V1001_TODAY_MUSIC\"},{\"name\":\"菜单\",\"sub_button\":[{\"type\":\"view\",\"name\":\"搜索\",\"url\":\"http://www.soso.com/\"},{\"type\":\"view\",\"name\":\"视频\",\"url\":\"http://v.qq.com/\"},{\"type\":\"click\",\"name\":\"赞一下我们\",\"key\":\"V1001_GOOD\"}]}],\"matchrule\":{\"group_id\":\"2\",\"sex\":\"1\",\"country\":\"中国\",\"province\":\"广东\",\"city\":\"广州\",\"client_platform_type\":\"2\",\"language\":\"zh_CN\"}}";
            ConditionalMenuInfo conditionalMenuInfo = JsonConvert.DeserializeObject<ConditionalMenuInfo>(menuJson);
            var result = weChatApi.AddConditional(conditionalMenuInfo);
            if (!result.IsSuccess())
            {
                Assert.Fail("创建个性化菜单数据失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void MenuApiTest_DelConditional()
        {
            string menuId = "404977661";
            var result = weChatApi.DelConditional(menuId);
            if (!result.IsSuccess())
            {
                Assert.Fail("删除个性化菜单失败，返回结果如下：" + result.DetailResult);
            }
        }

        [TestMethod]
        public void MenuApiTest_TryMatch()
        {
            string userId = "oG8X_sxvG2X_ZJmAxr6WDHT36qeA";
            var result = weChatApi.TryMatch(userId);
            if (!result.IsSuccess())
            {
                Assert.Fail("测试个性化菜单匹配结果失败，返回结果如下：" + result.DetailResult);
            }
        }
        #endregion
    }
}
