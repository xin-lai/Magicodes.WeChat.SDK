// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : SubMenuButton.cs
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

namespace Magicodes.WeChat.SDK.Apis.Menu
{
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
}