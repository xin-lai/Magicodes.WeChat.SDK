using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Material.Enums
{
    public enum MaterialType
    {
        /// <summary>
        /// 图片
        /// </summary>
        [Display(Name = "图片")]
        image = 1,
        /// <summary>
        /// 视频
        /// </summary>
        [Display(Name = "视频")]
        video = 2,
        /// <summary>
        /// 语音
        /// </summary>
        [Display(Name = "语音")]
        voice = 3,
        /// <summary>
        /// 图文
        /// </summary>
        [Display(Name = "图文")]
        news = 4,
    }
}
