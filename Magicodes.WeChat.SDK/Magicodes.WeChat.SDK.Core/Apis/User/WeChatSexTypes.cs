// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WeChatSexTypes.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.ComponentModel.DataAnnotations;

namespace Magicodes.WeChat.SDK.Apis.User
{
    /// <summary>
    ///     性别类型
    /// </summary>
    public enum WeChatSexTypes
    {
        /// <summary>
        ///     未知
        /// </summary>
        [Display(Name = "未知")] UnKnown = 0,

        /// <summary>
        ///     男人
        /// </summary>
        [Display(Name = "男")] Man = 1,

        /// <summary>
        ///     女人
        /// </summary>
        [Display(Name = "女")] Woman = 2
    }
}