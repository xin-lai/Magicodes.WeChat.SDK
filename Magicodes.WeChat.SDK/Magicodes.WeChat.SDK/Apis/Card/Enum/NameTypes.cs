using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public enum NameTypes
    {
        /// <summary>
        /// 等级
        /// </summary>
        [Display(Name = "等级")]
        FIELD_NAME_TYPE_LEVEL,

        /// <summary>
        /// 优惠券
        /// </summary>
        [Display(Name = "优惠券")]
        FIELD_NAME_TYPE_COUPON,

        /// <summary>
        /// 印花
        /// </summary>
        [Display(Name = "印花")]
        FIELD_NAME_TYPE_STAMP,

        /// <summary>
        /// 折扣
        /// </summary>
        [Display(Name = "折扣")]
        FIELD_NAME_TYPE_DISCOUNT,

        /// <summary>
        /// 成就
        /// </summary>
        [Display(Name = "成就")]
        FIELD_NAME_TYPE_ACHIEVEMEN,

        /// <summary>
        /// 里程
        /// </summary>
        [Display(Name = "里程")]
        FIELD_NAME_TYPE_MILEAGE,

        /// <summary>
        /// 集点
        /// </summary>
        [Display(Name = "集点")]
        FIELD_NAME_TYPE_SET_POINTS,

        /// <summary>
        /// 次数
        /// </summary>
        [Display(Name = "次数")]
        FIELD_NAME_TYPE_TIMS,
    }
}
