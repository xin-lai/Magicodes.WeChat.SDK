// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatApisContext.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Magicodes.WeChat.SDK.Apis.CustomerService;
using Magicodes.WeChat.SDK.Apis.CustomMessage;
using Magicodes.WeChat.SDK.Apis.Material;
using Magicodes.WeChat.SDK.Apis.Menu;
using Magicodes.WeChat.SDK.Apis.QRCode;
using Magicodes.WeChat.SDK.Apis.Statistics;
using Magicodes.WeChat.SDK.Apis.TemplateMessage;
using Magicodes.WeChat.SDK.Apis.Ticket;
using Magicodes.WeChat.SDK.Apis.Token;
using Magicodes.WeChat.SDK.Apis.User;
using Magicodes.WeChat.SDK.Apis.UserGroup;
using Magicodes.WeChat.SDK.Pays.EnterprisePay;
using Magicodes.WeChat.SDK.Pays.RedPackApi;
using Magicodes.WeChat.SDK.Pays.TenPayV3;
using Magicodes.WeChat.SDK.Apis.POI;
using Magicodes.WeChat.SDK.Apis.Card;

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     接口上下文对象
    /// </summary>
    public class WeChatApisContext
    {
        private static readonly Lazy<WeChatApisContext> Lazy =
            new Lazy<WeChatApisContext>(() => new WeChatApisContext());
        public static WeChatApisContext Current => Lazy.Value;

        /// <summary>
        ///     多客服接口
        /// </summary>
        public CustomerServiceApi CustomerServiceApi = new CustomerServiceApi();

        /// <summary>
        ///     客服消息接口
        /// </summary>
        public CustomMessageApi CustomMessageApi = new CustomMessageApi();

        /// <summary>
        ///     微信企业付款
        /// </summary>
        public EnterprisePayApi EnterprisePayApi = new EnterprisePayApi();

        /// <summary>
        ///     自定义菜单接口
        /// </summary>
        public MenuApi MenuApi = new MenuApi();

        /// <summary>
        ///     多图文接口
        /// </summary>
        public NewsApi NewsApi = new NewsApi();

        /// <summary>
        ///     微信二维码
        /// </summary>
        public QRCodeApi QrCodeApi = new QRCodeApi();

        /// <summary>
        ///     微信红包
        /// </summary>
        public RedPackApi RedPackApi = new RedPackApi();

        /// <summary>
        ///     数据统计API
        /// </summary>
        public StatisticsApi StatisticsApi = new StatisticsApi();

        /// <summary>
        ///     模板消息
        /// </summary>
        public TemplateMessageApi TemplateMessageApi = new TemplateMessageApi();

        /// <summary>
        ///     微信支付接口
        /// </summary>
        public TenPayV3 TenPayV3Api = new TenPayV3();

        /// <summary>
        ///     票证管理接口
        /// </summary>
        public TicketApi TicketApi = new TicketApi();

        /// <summary>
        ///     凭据管理接口
        /// </summary>
        public TokenApi TokenApi = new TokenApi();

        /// <summary>
        ///     用户相关操作
        /// </summary>
        public UserApi UserApi = new UserApi();

        /// <summary>
        ///     用户组相关操作API
        /// </summary>
        public UserGroupApi UserGroupApi = new UserGroupApi();

        /// <summary>
        ///     OAUTH验证接口
        /// </summary>
        public OAuthApi OAuthApi = new OAuthApi();

        /// <summary>
        ///     门店相关接口
        /// </summary>
        public POIApi POIApi = new POIApi();

        /// <summary>
        ///     卡券相关接口
        /// </summary>
        public CardApi CardApi = new CardApi();
    }
}