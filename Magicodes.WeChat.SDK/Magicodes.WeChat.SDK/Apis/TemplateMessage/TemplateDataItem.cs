// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateDataItem.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.TemplateMessage
{
    /// <summary>
    ///     模板消息的数据项类型
    /// </summary>
    public class TemplateDataItem
    {
        /// <summary>
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="color">color</param>
        public TemplateDataItem(string value, string color = "#173177")
        {
            Value = value;
            Color = color;
        }

        /// <summary>
        ///     项目值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     16进制颜色代码，如：#FF0000
        /// </summary>
        public string Color { get; set; }
    }
}