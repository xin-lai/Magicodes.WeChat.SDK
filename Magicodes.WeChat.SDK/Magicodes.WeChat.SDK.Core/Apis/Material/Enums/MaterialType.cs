// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MaterialType.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:47:52
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Apis.Material.Enums
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 素材类型
    /// </summary>
    public enum MaterialType
    {
        /// <summary>
        ///     图片
        /// </summary>
        [Display(Name = "图片")] image = 1,
        /// <summary>
        ///     视频
        /// </summary>
        [Display(Name = "视频")] video = 2,
        /// <summary>
        ///     语音
        /// </summary>
        [Display(Name = "语音")] voice = 3,
        /// <summary>
        ///     图文
        /// </summary>
        [Display(Name = "图文")] news = 4,
        /// <summary>
        ///     缩略图
        /// </summary>
        [Display(Name = "缩略图")] thumb = 4
    }
}
