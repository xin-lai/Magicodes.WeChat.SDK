// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MenuButtonBase.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
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

        [JsonProperty(PropertyName = "media_id")]
        public string MediaId { get; set; }

        [JsonProperty(PropertyName = "sub_button")]
        public List<MenuButtonBase> SubButton { get; set; }

        [JsonProperty(PropertyName = "news_info")]
        public List<NewsInfo> NewsInfo { get; set; }

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

        /// <summary>
        ///     小程序的appid（仅认证公众号可配置）（miniprogram类型必须）
        /// </summary>
        [JsonProperty(PropertyName = "appid")]
        public string AppId { get; set; }


        /// <summary>
        ///     小程序的页面路径
        /// </summary>
        [JsonProperty(PropertyName = "pagepath")]
        public string Pagepath { get; set; }
    }


    public class SelfMenuButtonBase
    {
        /// <summary>
        ///     菜单标题，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        [MaxLength(20)]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public virtual string Name { get; set; }

        [JsonProperty(PropertyName = "media_id")]
        public string MediaId { get; set; }

        [JsonProperty(PropertyName = "sub_button")]
        public SubButton SubButton { get; set; }

        [JsonProperty(PropertyName = "news_info")]
        public List<NewsInfo> NewsInfo { get; set; }

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
    }

    //二级菜单
    public class SubButton
    {
        /// <summary>
        ///     二级菜单列表
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        public List<MenuButtonBase> List { get; set; }
    }
}