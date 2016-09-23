// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : SelfMenuGetApiResultModel.cs
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
    ///     自定义菜单配置
    /// </summary>
    public class SelfMenuGetApiResultModel : ApiResult
    {
        [JsonProperty("is_menu_open")]
        public int IsMenuOpen { get; set; }

        [JsonProperty("selfmenu_info")]
        public SelfMenuInfo SelfMenuInfo { get; set; }
    }
}