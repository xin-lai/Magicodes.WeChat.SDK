// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : model.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    ///     菜单返回结果
    /// </summary>
    public class MenuGetApiResultModel : ApiResult
    {
        [JsonProperty("menu")]
        public MenuInfo Menu { get; set; }
    }

    /// <summary>
    ///     自定义菜单配置
    /// </summary>
    public class SelfMenuGetApiResultModel : ApiResult
    {
        [JsonProperty("is_menu_open")]
        public int IsMenuOpen { get; set; }

        [JsonProperty("selfmenu_info")]
        public SelfMenuInfo SelfMenuInfo { get; set; }
    }

    /// <summary>
    ///     菜单信息
    /// </summary>
    public class MenuInfo
    {
        [JsonProperty("button")]
        public List<MenuButtonBase> Button { get; set; }
    }

    /// <summary>
    ///     个性化菜单
    /// </summary>
    public class ConditionalMenuInfo
    {
        [JsonProperty("button")]
        public List<MenuButtonBase> Button { get; set; }

        [JsonProperty("matchrule")]
        public MatchRule MatchRule { get; set; }
    }

    /// <summary>
    ///     菜单匹配规则
    /// </summary>
    public class MatchRule
    {
        [JsonProperty(PropertyName = "group_id")]
        public string GroupId { get; set; }

        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "province")]
        public string Province { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "client_platform_type")]
        public string ClientPlatformType { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
    }

    /// <summary>
    ///     自定义菜单信息
    /// </summary>
    public class SelfMenuInfo
    {
        [JsonProperty(PropertyName = "name")]
        public virtual string Name { get; set; }

        [JsonProperty("sub_button")]
        public List<MenuButtonBase> SubButton { get; set; }
    }

    /// <summary>
    ///     菜单类型
    /// </summary>
    public enum MenuButtonTypes
    {
        /// <summary>
        ///     点击推事件
        /// </summary>
        click = 1,

        /// <summary>
        ///     跳转URL
        /// </summary>
        view = 2,

        /// <summary>
        ///     扫码推事件
        /// </summary>
        scancode_push = 3,

        /// <summary>
        ///     扫码推事件且弹出“消息接收中”提示框
        /// </summary>
        scancode_waitmsg = 4,

        /// <summary>
        ///     弹出系统拍照发图
        /// </summary>
        pic_sysphoto = 5,

        /// <summary>
        ///     弹出拍照或者相册发图
        /// </summary>
        pic_photo_or_album = 6,

        /// <summary>
        ///     弹出微信相册发图器
        /// </summary>
        pic_weixin = 7,

        /// <summary>
        ///     弹出地理位置选择器
        /// </summary>
        location_select = 8,

        /// <summary>
        ///     下发消息（除文本消息）
        /// </summary>
        media_id = 9,

        /// <summary>
        ///     跳转图文消息URL
        /// </summary>
        view_limited = 10
    }

    /// <summary>
    ///     菜单按钮基类
    /// </summary>
    public class MenuButtonBase
    {
        /// <summary>
        ///     菜单标题，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        [MaxLength(20)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public virtual string Name { get; set; }

        /// <summary>
        ///     菜单类型（菜单的响应动作类型）
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "type")]
        public MenuButtonTypes Type { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "media_id")]
        public string MediaId { get; set; }

        [JsonProperty(PropertyName = "sub_button")]
        public List<MenuButtonBase> SubButton { get; set; }

        [JsonProperty(PropertyName = "news_info")]
        public List<NewsInfo> NewsInfo { get; set; }
    }

    public class NewsInfo
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }

        [JsonProperty(PropertyName = "digest")]
        public string Digest { get; set; }

        [JsonProperty(PropertyName = "show_cover")]
        public int ShowCover { get; set; }

        [JsonProperty(PropertyName = "cover_url")]
        public string CoverUrl { get; set; }

        [JsonProperty(PropertyName = "content_url")]
        public string ContentUrl { get; set; }

        [JsonProperty(PropertyName = "source_url")]
        public string SourceUrl { get; set; }
    }

    /// <summary>
    ///     子菜单按钮
    /// </summary>
    public class SubMenuButton : MenuButtonBase
    {
        /// <summary>
        ///     菜单标题，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        [MaxLength(8)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public override string Name { get; set; }

        /// <summary>
        ///     子菜单（二级菜单数组，个数应为1~5个）
        /// </summary>
        [JsonProperty(PropertyName = "sub_button")]
        public List<MenuButtonBase> SubButtons { get; set; }
    }

    /// <summary>
    ///     Click按钮（点击推事件）
    ///     用户点击click类型按钮后，微信服务器会通过消息接口推送消息类型为event的结构给开发者（参考消息接口指南），并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互；
    /// </summary>
    public class ClickButton : MenuButtonBase
    {
        public ClickButton()
        {
            Type = MenuButtonTypes.click;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }

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

    /// <summary>
    ///     扫码推事件
    ///     用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。
    /// </summary>
    public class ScancodePushButton : MenuButtonBase
    {
        public ScancodePushButton()
        {
            Type = MenuButtonTypes.scancode_push;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }

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

    /// <summary>
    ///     弹出系统拍照发图
    ///     用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
    /// </summary>
    public class PicSysphotoButton : MenuButtonBase
    {
        public PicSysphotoButton()
        {
            Type = MenuButtonTypes.pic_sysphoto;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }

    /// <summary>
    ///     弹出拍照或者相册发图
    ///     用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。
    /// </summary>
    public class PicPhotoOrAlbumButton : MenuButtonBase
    {
        public PicPhotoOrAlbumButton()
        {
            Type = MenuButtonTypes.pic_photo_or_album;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }

    /// <summary>
    ///     弹出微信相册发图器
    ///     用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。
    /// </summary>
    public class PicWeixinButton : MenuButtonBase
    {
        public PicWeixinButton()
        {
            Type = MenuButtonTypes.pic_weixin;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }

    /// <summary>
    ///     弹出地理位置选择器
    ///     用户点击按钮后，微信客户端将调起地理位置选择工具，完成选择操作后，将选择的地理位置发送给开发者的服务器，同时收起位置选择工具，随后可能会收到开发者下发的消息。
    /// </summary>
    public class LocationSelectButton : MenuButtonBase
    {
        public LocationSelectButton()
        {
            Type = MenuButtonTypes.location_select;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }

    /// <summary>
    ///     下发消息（除文本消息）
    ///     用户点击media_id类型按钮后，微信服务器会将开发者填写的永久素材id对应的素材下发给用户，永久素材类型可以是图片、音频、视频、图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
    /// </summary>
    public class MediaIdButton : MenuButtonBase
    {
        public MediaIdButton()
        {
            Type = MenuButtonTypes.media_id;
        }

        /// <summary>
        ///     调用新增永久素材接口返回的合法media_id
        /// </summary>
        [JsonProperty(PropertyName = "media_id", Required = Required.Always)]
        public string MediaId { get; set; }
    }

    /// <summary>
    ///     跳转图文消息URL
    ///     用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
    /// </summary>
    public class ViewLimitedButton : MenuButtonBase
    {
        public ViewLimitedButton()
        {
            Type = MenuButtonTypes.view_limited;
        }

        /// <summary>
        ///     调用新增永久素材接口返回的合法media_id
        /// </summary>
        [JsonProperty(PropertyName = "media_id", Required = Required.Always)]
        public string MediaId { get; set; }
    }
}