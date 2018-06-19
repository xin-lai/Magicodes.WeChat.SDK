// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : PayResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Pays
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="PayResult" />
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class PayResult
    {
        /// <summary>
        /// Gets or sets the ReturnCode
        /// 返回状态码
        ///     SUCCESS/FAIL，此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// 返回信息，返回信息，如非空，为错误原因，签名失败，参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the DetailResult
        /// 详细内容
        /// </summary>
        [XmlIgnore]
        public string DetailResult { get; set; }

        /// <summary>
        /// The IsSuccess
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public virtual bool IsSuccess()
        {
            return ReturnCode == "SUCCESS";
        }
    }
}
