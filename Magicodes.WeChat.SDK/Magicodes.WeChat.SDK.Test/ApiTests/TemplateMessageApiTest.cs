// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateMessageApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.TemplateMessage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    [TestClass]
    public class TemplateMessageApiTest : ApiTestBase
    {
        private readonly TemplateMessageApi api = new TemplateMessageApi();

        [TestMethod]
        public void TemplateMessageApiTest_AddTemplate()
        {
            var result = api.AddTemplate("TM00003");
            Assert.IsTrue(result.IsSuccess());
            Assert.IsNotNull(result.TemplateId);
        }

        [TestMethod]
        public void TemplateMessageApiTest_Get()
        {
            var result = api.Get();
            Assert.IsTrue(result.IsSuccess());
            Assert.IsNotNull(result.Templates);
        }

        [TestMethod]
        public void TemplateMessageApiTest_Create()
        {
            ////获取测试用户
            //var testUsersOpenIds = TestOpenIdList;
            //if (testUsersOpenIds.Count == 0)
            //{
            //    Assert.Fail("测试失败，必须设置测试账户，见WeiChat_User中的AllowTest！");
            //}
            //var receiverIds = string.Join(";", testUsersOpenIds);

            //var testMessageTemplates = db.WeiChat_MessagesTemplates.Where(p => p.AllowTest).ToList();
            //if (testMessageTemplates.Count == 0)
            //{
            //    Assert.Fail("测试失败，必须设置测试模板，见WeiChat_MessagesTemplates中的AllowTest！");
            //}

            //var count = 0;
            //var successCount = 0;
            //foreach (var template in testMessageTemplates)
            //{
            //    count += testUsersOpenIds.Count;
            //    //模板消息模型
            //    var tmm = new TemplateMessageCreateModel()
            //    {
            //        MessagesTemplateNo = template.TemplateNo,
            //        Data = new Dictionary<string, TemplateDataItem>(),
            //        ReceiverIds = receiverIds,
            //        Url = "www.magicodes.net"
            //    };
            //    var rm = Regex.Matches(template.Content, @"\{\{(.+?)\}\}");
            //    if (rm.Count > 0)
            //    {
            //        foreach (Match item in rm)
            //        {
            //            tmm.Data.Add(Regex.Split(item.Value.Trim('{').Trim('}'), ".DATA")[0], new TemplateDataItem("测试"));
            //        }
            //    }
            //    var batchNumber = api.Create(tmm);
            //    successCount +=
            //        db.WeiChat_MessagesTemplateSendLogs.Count(p => p.IsSuccess && p.BatchNumber == batchNumber);
            //}
            //Assert.AreEqual<int>(count, successCount, "部分消息发送未成功，请检查！{0}/{1}", successCount, count);
        }
    }
}