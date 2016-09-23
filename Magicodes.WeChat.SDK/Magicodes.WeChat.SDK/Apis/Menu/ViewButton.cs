// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ViewButton.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    ///     View按钮（跳转URL）
    ///     用户点击view类型按钮后，微信客户端将会打开开发者在按钮中填写的网页URL，可与网页授权获取用户基本信息接口结合，获得用户基本信息。
    /// </summary>
    public class ViewButton : MenuButtonBase
    {
        public ViewButton()
        {
            Type = MenuButtonTypes.view;
        }

        /// <summary>
        ///     网页链接，用户点击菜单可打开链接，不超过1024字节
        /// </summary>
        [MaxLength(500)]
        [JsonProperty(PropertyName = "url", Required = Required.Always)]
        public string Url { get; set; }
    }
}