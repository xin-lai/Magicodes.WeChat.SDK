using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Magicodes.WeChat.SDK.Core.ServerMessages;
using Magicodes.WeChat.SDK.Core.ServerMessages.From;
using Magicodes.WeChat.SDK.Core.ServerMessages.To;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Core.Test.Api
{
    [TestClass]
    public class ServerMessageHandlerTest
    {
        [TestMethod]
        public void ServerMessageHandlerTest_HandleMessageTest()
        {
            var serverMessageHandler = new ServerMessageHandler(1)
            {
                HandleFuncs = new Dictionary<Type, Func<IFromMessage, ToMessageBase>>()
                {
                    {
                        typeof(FromTextMessage),
                        message => new ToTextMessage()
                        {
                            Content = "Test",
                        }
                    }
                }
            };
            var result = serverMessageHandler.HandleMessage(
                 @"<xml>
                     <ToUserName><![CDATA[toUser]]></ToUserName>
                     <FromUserName><![CDATA[fromUser]]></FromUserName> 
                     <CreateTime>1348831860</CreateTime>
                     <MsgType><![CDATA[text]]></MsgType>
                     <Content><![CDATA[this is a test]]></Content>
                     <MsgId>1234567890123456</MsgId>
                </xml>").Result;
            if (result.CreateDateTime == default(DateTime))
            {
                Assert.Fail("时间格式错误");
            }
            if (result.ToUserName != "fromUser")
            {
                Assert.Fail("错误！");
            }
            var xml = result.ToXml();
            if (string.IsNullOrWhiteSpace(xml))
            {
                Assert.Fail("序列化XML格式错误！");
            }
            //Assert.AreEqual(
            //    "<xml><ToUserName>fromUser</ToUserName><FromUserName>toUser</FromUserName><CreateTime>1494409853</CreateTime><MsgType>text</MsgType><Content>Test</Content></xml",
            //    xml);
        }

        [TestMethod]
        public void ServerMessageHandlerTest_FromSubscribeEvent_HandleMessageTest()
        {
            var serverMessageHandler = new ServerMessageHandler(1)
            {
                HandleFuncs = new Dictionary<Type, Func<IFromMessage, ToMessageBase>>()
                {
                    {
                        typeof(FromSubscribeEvent),
                        message => new ToTextMessage()
                        {
                            Content = "Test",
                        }
                    }
                }
            };
            var result = serverMessageHandler.HandleMessage(
                 @"<xml><ToUserName><![CDATA[gh_44ab71bac0b5]]></ToUserName>
<FromUserName><![CDATA[owQ_nw9_ZA8uGdqWYp1ckdFQ6aeo]]></FromUserName>
<CreateTime>1504084003</CreateTime>
<MsgType><![CDATA[event]]></MsgType>
<Event><![CDATA[subscribe]]></Event>
<EventKey><![CDATA[]]></EventKey>
</xml>").Result;
            if (result.CreateDateTime == default(DateTime))
            {
                Assert.Fail("时间格式错误");
            }
            
            var xml = result.ToXml();
            if (string.IsNullOrWhiteSpace(xml))
            {
                Assert.Fail("序列化XML格式错误！");
            }
            //Assert.AreEqual(
            //    "<xml><ToUserName>fromUser</ToUserName><FromUserName>toUser</FromUserName><CreateTime>1494409853</CreateTime><MsgType>text</MsgType><Content>Test</Content></xml",
            //    xml);
        }

        [TestMethod]
        public void ServerMessageHandlerTest_ToMessageXmlTest()
        {
            var toMsg = new ToNewsMessage()
            {
                Articles = new List<ToNewsMessage.ArticleInfo>()
                {
                    new ToNewsMessage.ArticleInfo()
                    {
                        Description = "湖南心莱信息科技有限公司是由一群从北上广回归的精英携手创建的一家专注软件开发的公司，公司成员基本上都有从事软件开发5年以上的工作经验，并且均领导实施过中大型软件项目。公司以“踏实，直率相处，乐于助人；对技术满怀热情；致力于帮助客户带来价值”为核心价值，希望通过专业水平和不懈努力，为中小企业提供优质的软件服务，为中小软件公司提供优质的软件技术服务。为了帮助中小软件公司快速开发和定制微信公众号，公司精心打造了两款产品——Magicodes.WeiChat和Magicodes.Shop，分别为微信快速定制开发框架和微信商城框架。其中，Magicodes.WeiChat已经拥有了100+正式用户和10+合作伙伴，并且广受好评。 Magicodes.Shop是产品团队在Magicodes.WeiChat基础上，应广大合作伙伴要求，针对微商城这块业务进行封装和提炼，精心打造的微商城产品。公司不仅仅提供专业的软件开发服务,同时还建立了完善的售后服务体系,为企业发展中遇到的问题和困难提供指导帮助。我们相信,通过我们的不断努力和追求,一定能够实现与中小企业的互利共赢，帮助中小企业带来价值！",
                        PicUrl = "http://xin-lai.com/PlugIns/Magicodes.Home/wwwroot/unify/img/logo.png",
                        Title="心莱科技官方介绍",
                        Url = "http://xin-lai.com"
                    }
                },
                FromUserName = "Test",
                ToUserName = "Test"
            };
            var serverMessageHandler = new ServerMessageHandler(1)
            {
                HandleFuncs = new Dictionary<Type, Func<IFromMessage, ToMessageBase>>()
                {
                    {
                        typeof(FromTextMessage),
                        message => toMsg
                    }
                }
            };
            var result = serverMessageHandler.HandleMessage(
                @"<xml>
                     <ToUserName><![CDATA[toUser]]></ToUserName>
                     <FromUserName><![CDATA[fromUser]]></FromUserName> 
                     <CreateTime>1348831860</CreateTime>
                     <MsgType><![CDATA[text]]></MsgType>
                     <Content><![CDATA[this is a test]]></Content>
                     <MsgId>1234567890123456</MsgId>
                </xml>").Result;
            var xmlStr = result.ToXml();
            var xEle = XElement.Parse(xmlStr);
            if (xEle.Element("Articles") == null)
            {
                Assert.Fail("图文格式有误!");
            }

        }
    }
}
