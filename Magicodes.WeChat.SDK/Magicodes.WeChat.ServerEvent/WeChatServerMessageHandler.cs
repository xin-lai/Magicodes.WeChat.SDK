// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatServerMessageHandler.cs
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 微信服务器事件处理器 <see cref="WeChatServerMessageHandler" />
    /// </summary>
    public class WeChatServerMessageHandler : ServerMessageHandler
    {
        protected object key;
        /// <summary>
        /// Initializes a new instance of the <see cref="WeChatServerMessageHandler"/> class.
        /// </summary>
        /// <param name="key">The key<see cref="object"/></param>
        public WeChatServerMessageHandler(object key) : base(key)
        {
            this.key = key;
            if (HandleFuncs == null)
            {
                SetDefaultHandlers();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void WeChatSubscribeEventHandler(WeChatSubscribeEventData e);

        /// <summary>
        /// 微信关注事件(包含扫码关注)
        /// </summary>
        public event WeChatSubscribeEventHandler WeChatSubscribeEvent;


        public delegate void WeChatTextMessageEventHandler(WeChatTextMessageEventData e);
        /// <summary>
        /// 微信文本请求事件
        /// </summary>
        public event WeChatTextMessageEventHandler WeChatTextMessageEvent;

        public delegate void WeChatScanEventHandler(WeChatScanEventData e);
        /// <summary>
        /// 微信扫码事件
        /// </summary>
        public event WeChatScanEventHandler WeChatScanEvent;

        public void SetDefaultHandlers()
        {
            HandleFuncs = new Dictionary<Type, Func<IFromMessage, ToMessageBase>>
            {
                {
                    typeof(FromSubscribeEvent),
                    message =>
                    {
                        //由于这里是基于微信服务器事件，故不能使用WeChatApisContext.Current.UserApi方式获取到UserApi接口，请new一个然后过SetKey进行赋值
                        var userApi = new UserApi();
                        userApi.SetKey(key);

                        var weChatEventData = message as FromSubscribeEvent;
                        if (!string.IsNullOrWhiteSpace(weChatEventData.EventKey) && weChatEventData.EventKey.StartsWith("qrscene_"))
                        {
                            weChatEventData.EventKey=weChatEventData.EventKey.Substring("qrscene_".Length);
                            LoggerHelper.Debug("已触发扫码关注事件,EventKey:"+weChatEventData.EventKey);
                        }

                        if (this.WeChatSubscribeEvent!=null)
                        {
                            var eventData = new WeChatSubscribeEventData()
                            {
                                FromMessage = weChatEventData ,
                                TenantId = (int?)key,
                            };
                            this.WeChatSubscribeEvent(eventData);
                             return eventData.ToMessage;
                        }
                        return null;
                    }
                },
                {
                    typeof(FromTextMessage),
                    message =>
                    {
                        var weChatEventData=message as FromTextMessage;
                        LoggerHelper.Debug("已触发文本消息事件:"+weChatEventData.Content);
                        if (this.WeChatTextMessageEvent!=null)
                        {
                            var eventData = new WeChatTextMessageEventData()
                            {
                                FromMessage = message as FromTextMessage ,
                                TenantId = (int?)key,
                            };
                            this.WeChatTextMessageEvent(eventData);
                             return eventData.ToMessage;
                        }
                        return null;
                    }
                },
                {
                    typeof(FromScanEvent),
                    message =>
                    {
                        var weChatEventData=message as FromScanEvent;
                        LoggerHelper.Debug("已触发扫码事件:"+weChatEventData.EventKey);

                        if (!string.IsNullOrWhiteSpace(weChatEventData.EventKey) && weChatEventData.EventKey.StartsWith("qrscene_"))
                        {
                            weChatEventData.EventKey=weChatEventData.EventKey.Substring("qrscene_".Length);
                        }

                        if (this.WeChatScanEvent!=null)
                        {
                            var eventData = new WeChatScanEventData()
                            {
                                FromMessage = weChatEventData ,
                                TenantId = (int?)key,
                            };
                            this.WeChatScanEvent(eventData);
                             return eventData.ToMessage;
                        }
                        return null;
                    }
                }
            };
        }
    }
}
