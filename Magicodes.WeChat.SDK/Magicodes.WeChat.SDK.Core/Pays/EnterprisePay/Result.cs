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

namespace Magicodes.WeChat.SDK.Pays.EnterprisePay
{
    /// <summary>
    ///     企业付款
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class Result : PayResult
    {
        /// <summary>
        ///     微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlAttribute("mch_appid")]
        public string MchAppId { get; set; }

        /// <summary>
        ///     微信支付分配的商户号
        /// </summary>
        [XmlAttribute("mchid")]
        public string MchId { get; set; }

        /// <summary>
        ///     微信支付分配的终端设备号
        /// </summary>
        [XmlAttribute("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        ///     随机字符串，不长于32位
        /// </summary>
        [XmlAttribute("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        ///     SUCCESS/FAIL
        /// </summary>
        [XmlAttribute("result_code")]
        public string ResultCode { get; set; }

        [XmlAttribute("err_code")]
        public string ErrCode { get; set; }

        [XmlAttribute("err_code_des")]
        public string ErrCodeDes { get; set; }

        public override bool IsSuccess()
        {
            return (ReturnCode == "SUCCESS") && (ResultCode == "SUCCESS");
        }
    }
}