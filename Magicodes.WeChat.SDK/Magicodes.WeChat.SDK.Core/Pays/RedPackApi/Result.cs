// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : Result.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

/*******************************************************************************************
 *                                                                                         *
 * 接口文档地址：https://pay.weixin.qq.com/wiki/doc/api/tools/cash_coupon.php?chapter=13_5 *
 *                                                                                         *
 * *****************************************************************************************/
namespace Magicodes.WeChat.SDK.Pays.RedPackApi
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 获取普通现金红包(裂变红包)发送接口的结果
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class Result : PayResult
    {
        /// <summary>
        /// Gets or sets the Sign
        /// 签名
        /// </summary>
        [XmlAttribute("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// Gets or sets the ResultCode
        /// SUCCESS/FAIL
        /// </summary>
        [XmlAttribute("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// Gets or sets the ErrCode
        /// </summary>
        [XmlAttribute("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// Gets or sets the ErrCodeDes
        /// </summary>
        [XmlAttribute("err_code_des")]
        public string ErrCodeDes { get; set; }
    }
}
