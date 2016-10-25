// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MenusApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class MenusApiTest : ApiTestBase
    {
        private readonly MenuApi weChatApi = WeChatApisContext.Current.MenuApi;

        public MenusApiTest()
        {
        }

        [TestMethod]
        public void MenusApiTest_Get()
        {
            var result = weChatApi.Get();
            if (!result.IsSuccess())
                Assert.Fail("获取菜单数据失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void MenusApiTest_Create()
        {
            var menuJson =
                "{\"button\":[{\"type\":\"click\",\"name\":\"今日歌曲\",\"key\":\"V1001_TODAY_MUSIC\"},{\"name\":\"菜单\",\"sub_button\":[{\"type\":\"view\",\"name\":\"搜索\",\"url\":\"http://www.soso.com/\"},{\"type\":\"view\",\"name\":\"视频\",\"url\":\"http://v.qq.com/\"},{\"type\":\"click\",\"name\":\"赞一下我们\",\"key\":\"V1001_GOOD\"},{\"type\":\"media_id\",\"name\":\"Test\",\"media_id\":\"UBHDLvv3QW_IVxTqWq7EcIZOEuSlRxRgnKWIQJG_Q_U\"}]}]}";

            var model = JsonConvert.DeserializeObject<MenuInfo>(menuJson);
            var result = weChatApi.Create(model);
            if (!result.IsSuccess())
                Assert.Fail("创建菜单数据失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void MenuApiTest_Delete()
        {
            var result = weChatApi.Delete();
            if (!result.IsSuccess())
                Assert.Fail("删除菜单数据失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void MenuApiTest_GetCurrentSelfmenuInfo()
        {
            var result = weChatApi.GetCurrentSelfmenuInfo();
            if (!result.IsSuccess())
                Assert.Fail("获取自定义菜单配置数据失败，返回结果如下：" + result.DetailResult);
        }

        #region 个性化菜单接口单元测试

        [TestMethod]
        public void MenuApiTest_AddConditional()
        {
            var menuJson =
                "{\"button\":[{\"type\":\"click\",\"name\":\"今日歌曲\",\"key\":\"V1001_TODAY_MUSIC\"},{\"name\":\"菜单\",\"sub_button\":[{\"type\":\"view\",\"name\":\"搜索\",\"url\":\"http://www.soso.com/\"},{\"type\":\"view\",\"name\":\"视频\",\"url\":\"http://v.qq.com/\"},{\"type\":\"click\",\"name\":\"赞一下我们\",\"key\":\"V1001_GOOD\"}]}],\"matchrule\":{\"group_id\":\"2\",\"sex\":\"1\",\"country\":\"中国\",\"province\":\"广东\",\"city\":\"广州\",\"client_platform_type\":\"2\",\"language\":\"zh_CN\"}}";
            var conditionalMenuInfo = JsonConvert.DeserializeObject<ConditionalMenuInfo>(menuJson);
            var result = weChatApi.AddConditional(conditionalMenuInfo);
            if (!result.IsSuccess())
                Assert.Fail("创建个性化菜单数据失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void MenuApiTest_DelConditional()
        {
            var menuId = "404977661";
            var result = weChatApi.DelConditional(menuId);
            if (!result.IsSuccess())
                Assert.Fail("删除个性化菜单失败，返回结果如下：" + result.DetailResult);
        }

        [TestMethod]
        public void MenuApiTest_TryMatch()
        {
            var userId = "oG8X_sxvG2X_ZJmAxr6WDHT36qeA";
            var result = weChatApi.TryMatch(userId);
            if (!result.IsSuccess())
                Assert.Fail("测试个性化菜单匹配结果失败，返回结果如下：" + result.DetailResult);
        }

        #endregion
    }
}