using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    public enum RichFieldTypes
    {

        /// <summary>
        /// 自定义单选
        /// </summary>
        [Display(Name = "自定义单选")]
        FORM_FIELD_RADIO,

        /// <summary>
        /// 自定义选择项
        /// </summary>
        [Display(Name = "自定义选择项")]
        FORM_FIELD_SELECT,

        /// <summary>
        /// 自定义多选
        /// </summary>
        [Display(Name = "自定义多选")]
        FORM_FIELD_CHECK_BOX
    }
}
