using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.Dependency;
using Magicodes.WeChat.SDK.Apis.User;
using Magicodes.WeChat.SDK.Core.ServerMessages;
using Magicodes.WeChat.SDK.Core.ServerMessages.From;
using Magicodes.WeChat.SDK.Core.ServerMessages.To;
using Magicodes.WeChat.User;
using Magicodes.WeChat.User.Dto;
using Magicodes.WeChat.Web.Core.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Abp.Threading;
using Abp.Domain.Uow;

namespace Magicodes.WeChat.Web.Core
{
    /// <summary>
    /// 服务器事件处理控制器
    /// </summary>
    [AllowAnonymous]
    [Route("WeChatEvent")]
    public class WeChatEventController : Controller
    {
        protected WeChatEventController()
        {
        }

        [HttpGet("{tenantId}")]
        public ActionResult CheckSignature(int tenantId, string signature, string timestamp, string nonce,
            string echostr)
        {
            var msgHandler = new WeChatServerMessageHandler(tenantId);
            //Logger.DebugFormat("正在检查签名:\n tenantId:{0}\t signature:{1}\t timestamp:{2}\t nonce:{3}\t echostr:{4}",
            //    tenantId, signature, timestamp, nonce, echostr);
            return Content(msgHandler.CheckSignature(signature, timestamp, nonce) ? echostr : "验证签名出错！");
        }

        /// <summary>
        /// 处理服务器事件消息
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <param name="echostr"></param>
        /// <returns></returns>
        [HttpPost("{tenantId}")]
        public async Task<ActionResult> HandleMessage(int tenantId, string signature, string timestamp, string nonce,
            string echostr)
        {
            //Logger.Debug("正在处理微信服务器消息...");
            using (var reader = new StreamReader(Request.Body))
            {
                var xmlStr = reader.ReadToEnd();
                var msgHandler = new WeChatServerMessageHandler(tenantId)
                {
                    HandleFuncs = new Dictionary<Type, Func<IFromMessage, ToMessageBase>>
                    {
                        {
                            typeof(FromSubscribeEvent),
                            message =>
                            {
                                //由于这里是基于微信服务器事件，故不能使用WeChatApisContext.Current.UserApi方式获取到UserApi接口，请new一个然后通过SetKey进行赋值
                                var userApi = new UserApi();
                                userApi.SetKey(tenantId);

                                var weChatEventData = message as FromSubscribeEvent;
                                if (!string.IsNullOrWhiteSpace(weChatEventData.EventKey) && weChatEventData.EventKey.StartsWith("qrscene_"))
                                {
                                    weChatEventData.EventKey=weChatEventData.EventKey.Substring("qrscene_".Length);
                                    Logger.Info("[FromSubscribeEvent]EventKey:"+weChatEventData.EventKey);
                                }

                                //获取新关注用户的用户信息
                                var userInfoResult = userApi.Get(message.FromUserName);
                                if (userInfoResult.IsSuccess())
                                {
                                    //Logger.Debug("正在存储粉丝信息："+message.FromUserName);
                                    //AsyncHelper.RunSync(() =>
                                    //    WeChatUserAppService.CreateOrUpdateWeChatUser(
                                    //        new CreateOrUpdateWeChatUserDto
                                    //        {
                                    //            WeChatUser = new WeChatUserEditDto
                                    //            {
                                    //                AppId = userApi.AppConfig.AppId,
                                    //                City = userInfoResult.City,
                                    //                Country = userInfoResult.Country,
                                    //                GroupId = userInfoResult.GroupId,
                                    //                HeadImgUrl = userInfoResult.Headimgurl,
                                    //                Language = userInfoResult.Language,
                                    //                NickName = userInfoResult.NickName,
                                    //                Id = userInfoResult.OpenId,
                                    //                Province = userInfoResult.Province,
                                    //                Remark = userInfoResult.Remark,
                                    //                Sex = (int) userInfoResult.Sex,
                                    //                Subscribe = true,
                                    //                SubscribeTime = userInfoResult.SubscribeTime,
                                    //                UnionId = userInfoResult.Unionid,
                                    //                TenantId = tenantId,
                                    //                EventKey = weChatEventData.EventKey
                                    //            }
                                    //        })
                                    //);

                                }
                                else
                                {
                                    Logger.Error("获取粉丝信息失败：" + userInfoResult.GetFriendlyMessage() + "\n\r详细错误：" +
                                                 userInfoResult.DetailResult);
                                }


                                var eventData = new WeChatSubscribeEventData()
                                {
                                    FromMessage = weChatEventData ,
                                    TenantId = tenantId,
                                };
                                EventBus.Trigger(eventData);
                                return eventData.ToMessage;
                            }
                        },
                        {
                            typeof(FromTextMessage),
                            message =>
                            {
                                var eventData = new WeChatTextMessageEventData()
                                {
                                    FromMessage = message as FromTextMessage,
                                    TenantId = tenantId,
                                };
                                EventBus.Trigger(eventData);
                                return eventData.ToMessage;
                            }
                        },
                        {
                            typeof(FromScanEvent),
                            message =>
                            {
                                var weChatEventData=message as FromScanEvent;
                                Logger.Debug("已触发扫描关注事件！"+weChatEventData.EventKey);
                                if (!string.IsNullOrWhiteSpace(weChatEventData.EventKey) && weChatEventData.EventKey.StartsWith("qrscene_"))
                                {
                                    weChatEventData.EventKey=weChatEventData.EventKey.Substring("qrscene_".Length);
                                }
                                var eventData = new WeChatScanEventData()
                                {
                                    FromMessage = weChatEventData,
                                    TenantId = tenantId
                                };
                                EventBus.Trigger(eventData);
                                return eventData.ToMessage;
                            }
                        }
                    }
                };
                if (!msgHandler.CheckSignature(signature, timestamp, nonce))
                {
                    Logger.WarnFormat(
                        "签名验证出错:\n tenantId:{0}\t signature:{1}\t timestamp:{2}\t nonce:{3}\t echostr:{4}", tenantId,
                        signature, timestamp, nonce, echostr);
                    return Ok();
                }
                var result = await msgHandler.HandleMessage(xmlStr);
                if (result == null)
                    return Ok();
                var toXml = result.ToXml();
                Logger.Debug("成功返回:" + toXml);
                return Content(toXml);
            }
        }
    }
}