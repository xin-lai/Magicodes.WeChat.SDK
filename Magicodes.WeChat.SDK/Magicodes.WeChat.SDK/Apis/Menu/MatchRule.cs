// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MatchRule.cs
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
}