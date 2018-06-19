// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatEventController.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:55:23
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.Web.Core
{
    using Magicodes.WeChat.SDK;
    using Magicodes.WeChat.SDK.Apis.User;
    using Magicodes.WeChat.SDK.Core.ServerMessages;
    using Magicodes.WeChat.SDK.Core.ServerMessages.From;
    using Magicodes.WeChat.SDK.Core.ServerMessages.To;
    using Magicodes.WeChat.SDK.Helper;
    using Magicodes.WeChat.Web.Core.Event;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// 服务器事件处理控制器
    /// </summary>
    [AllowAnonymous]
    [Route("WeChat/Events")]
    public class WeChatEventController : Controller
    {
        /// <summary>
        /// 默认的服务器处理Handler
        /// </summary>
        public static ServerMessageHandler ServerMessageHandler { get; set; }
        /// <summary>
        /// 检查签名
        /// </summary>
        /// <param name="tenantId">The tenantId<see cref="int"/></param>
        /// <param name="signature">The signature<see cref="string"/></param>
        /// <param name="timestamp">The timestamp<see cref="string"/></param>
        /// <param name="nonce">The nonce<see cref="string"/></param>
        /// <param name="echostr">The echostr<see cref="string"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet("{tenantId}")]
        public ActionResult CheckSignature(int tenantId, string signature, string timestamp, string nonce,
            string echostr)
        {
            var msgHandler = new WeChatServerMessageHandler(tenantId);
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
            LoggerHelper.Debug("正在处理微信服务器消息...");

            using (var reader = new StreamReader(Request.Body))
            {
                var xmlStr = reader.ReadToEnd();
                var msgHandler = GetServerMessageHandler(tenantId);
                //检查签名
                if (!msgHandler.CheckSignature(signature, timestamp, nonce))
                {
                    LoggerHelper.Warn(string.Format(
                        "签名验证出错:\n tenantId:{0}\t signature:{1}\t timestamp:{2}\t nonce:{3}\t echostr:{4}", tenantId,
                        signature, timestamp, nonce, echostr));
                    return Ok();
                }
                //处理事件消息
                var result = await msgHandler.HandleMessage(xmlStr);
                if (result == null)
                    return Ok();
                var toXml = result.ToXml();
                LoggerHelper.Debug("微信服务器事件处理成功，返回格式为:" + Environment.NewLine + toXml);
                return Content(toXml);
            }
        }

        /// <summary>
        /// 获取服务器事件消息处理Handler
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        private static ServerMessageHandler GetServerMessageHandler(int tenantId)
        {
            if (ServerMessageHandler == null)
            {
                ServerMessageHandler = new WeChatServerMessageHandler(tenantId)
                {

                };
            }
            return ServerMessageHandler;
        }
    }
}
