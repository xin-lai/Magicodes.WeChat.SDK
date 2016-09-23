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

using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Pays.TenPayV3
{
    [XmlRoot("xml")]
    [Serializable]
    public class Result : PayResult
    {
        /// <summary>
        ///     微信分配的公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        ///     微信支付分配的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string Mch_Id { get; set; }

        /// <summary>
        ///     微信支付分配的终端设备号
        /// </summary>
        [XmlElement("device_info")]
        public string Device_Info { get; set; }

        /// <summary>
        ///     随机字符串，不长于32 位
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        ///     SUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }
    }
}