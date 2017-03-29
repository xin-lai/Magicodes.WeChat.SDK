// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NewsInfo.cs
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
}