using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 用户会员卡状态
    /// </summary>
    public enum UserCardStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常")]
        NORMAL,

        /// <summary>
        /// 已过期
        /// </summary>
        [Display(Name = "已过期")]
        EXPIRE,

        /// <summary>
        /// 转赠中
        /// </summary>
        [Display(Name = "转赠中")]
        GIFTING,

        /// <summary>
        /// 转赠成功
        /// </summary>
        [Display(Name = "转赠成功")]
        GIFT_SUCC,

        /// <summary>
        /// 转赠超时
        /// </summary>
        [Display(Name = "转赠超时")]
        GIFT_TIMEOUT,

        /// <summary>
        /// 已删除
        /// </summary>
        [Display(Name = "已删除")]
        DELETE,

        /// <summary>
        /// 已失效
        /// </summary>
        [Display(Name = "已失效")]
        UNAVAILABLE
    }
}
