// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ConditionalMenuInfo.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
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
}