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

using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Pays
{
    [XmlRoot("xml")]
    [Serializable]
    public class PayResult
    {
        /// <summary>
        ///     返回状态码
        ///     SUCCESS/FAIL，此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        ///     返回信息，返回信息，如非空，为错误原因，签名失败，参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public string Message { get; set; }

        /// <summary>
        ///     详细内容
        /// </summary>
        [XmlIgnore]
        public string DetailResult { get; set; }

        public virtual bool IsSuccess()
        {
            return ReturnCode == "SUCCESS";
        }
    }
}