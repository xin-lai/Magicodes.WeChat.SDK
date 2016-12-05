using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    /// 自定义选项名称
    /// </summary>
    public enum CommonFieldTypes
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        USER_FORM_INFO_FLAG_MOBILE,

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        USER_FORM_INFO_FLAG_SEX,

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "自领取后固定天数")]
        USER_FORM_INFO_FLAG_NAME,

        /// <summary>
        /// 生日
        /// </summary>
        [Display(Name = "生日")]
        USER_FORM_INFO_FLAG_BIRTHDAY,

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        USER_FORM_INFO_FLAG_IDCARD,

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        USER_FORM_INFO_FLAG_EMAIL,

        /// <summary>
        /// 详细地址
        /// </summary>
        [Display(Name = "详细地址")]
        USER_FORM_INFO_FLAG_LOCATION,

        /// <summary>
        /// 教育背景
        /// </summary>
        [Display(Name = "教育背景")]
        USER_FORM_INFO_FLAG_EDUCATION_BACKGRO,

        /// <summary>
        /// 职业
        /// </summary>
        [Display(Name = "职业")]
        USER_FORM_INFO_FLAG_CAREER,

        /// <summary>
        /// 行业
        /// </summary>
        [Display(Name = "行业")]
        USER_FORM_INFO_FLAG_INDUSTRY,

        /// <summary>
        /// 收入
        /// </summary>
        [Display(Name = "收入")]
        USER_FORM_INFO_FLAG_INCOME,

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        [Display(Name = "兴趣爱好")]
        USER_FORM_INFO_FLAG_HABIT
    }
}
