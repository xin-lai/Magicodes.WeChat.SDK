// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatFrameworkFuncTypes.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK
{
    /// <summary>
    ///     方法类型
    /// </summary>
    public enum WeChatFrameworkFuncTypes
    {
        /// <summary>
        ///     根据Key获取公众号配置
        /// </summary>
        Config_GetWeChatConfigByKey = 0,

        /// <summary>
        ///     模板消息发送
        /// </summary>
        APIFunc_TemplateMessageApi_Create = 1,

        /// <summary>
        ///     获取微信支付信息
        /// </summary>
        Config_GetWeChatPayConfigByKey = 3,

        /// <summary>
        ///     获取AccessToken。用于中控服务器模式，即从中控服务器获取Accesstoken
        /// </summary>
        APIFunc_GetAccessToken = 4,

        /// <summary>
        ///     获取Key
        /// </summary>
        GetKey = 5,
    }
}