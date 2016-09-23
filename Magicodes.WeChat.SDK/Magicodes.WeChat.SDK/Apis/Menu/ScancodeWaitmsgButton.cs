// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ScancodeWaitmsgButton.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    ///     扫码推事件且弹出“消息接收中”提示框
    ///     用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。
    /// </summary>
    public class ScancodeWaitmsgButton : MenuButtonBase
    {
        public ScancodeWaitmsgButton()
        {
            Type = MenuButtonTypes.scancode_waitmsg;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }
}