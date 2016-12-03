using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public enum SceneTypes
    {
        /// <summary>
        /// 附近
        /// </summary>
        [Display(Name = "附近")]
        SCENE_NEAR_BY = 0,
        /// <summary>
        /// 自定义菜单
        /// </summary>
        [Display(Name = "自定义菜单")]
        SCENE_MENU = 1,
        /// <summary>
        /// 二维码
        /// </summary>
        [Display(Name = "二维码")]
        SCENE_QRCODE = 2,

        /// <summary>
        /// 公众号文章
        /// </summary>
        [Display(Name = "公众号文章")]
        SCENE_ARTICLE = 3,

        [Display(Name = "h5页面")]
        SCENE_H5 = 4,
        /// <summary>
        /// 自动回复
        /// </summary>
        [Display(Name = "自动回复")]
        SCENE_IVR = 5,
        /// <summary>
        /// 卡券自定义cell
        /// </summary>
        [Display(Name = "卡券自定义cell")]
        SCENE_CARD_CUSTOM_CELL = 6,
    }
}
