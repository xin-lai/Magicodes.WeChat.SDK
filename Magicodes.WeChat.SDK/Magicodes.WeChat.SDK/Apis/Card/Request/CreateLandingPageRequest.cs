using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card.Request
{
    /// <summary>
    /// 创建卡券投放货架
    /// </summary>
    public class CreateLandingPageRequest
    {
        /// <summary>
        /// 页面的banner图片链接，须调用，建议尺寸为640*300。
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("banner")]
        public string Banner { get; set; }

        /// <summary>
        /// 页面的title。
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("page_title")]
        public string PageTitle { get; set; }

        /// <summary>
        /// 页面是否可以分享,填入true/false
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("can_share")]
        public bool CanShare { get; set; }

        /// <summary>
        /// 投放页面的场景值
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("scene")]
        public SceneTypes SceneTypes { get; set; }

        /// <summary>
        /// 卡券列表
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("card_list")]
        public List<SceneCardInfo> CardList { get; set; }
    }
    /// <summary>
    ///  投放卡券实体
    /// </summary>
    public class SceneCardInfo
    {
        /// <summary>
        /// 所要在页面投放的card_id
        /// </summary>
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [Required]
        [JsonRequired]
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
    }
}
