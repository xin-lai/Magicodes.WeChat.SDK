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

namespace Magicodes.WeChat.SDK.Pays.EnterprisePay
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 企业付款
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class Result : PayResult
    {
        /// <summary>
        /// Gets or sets the MchAppId
        /// 微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlAttribute("mch_appid")]
        public string MchAppId { get; set; }

        /// <summary>
        /// Gets or sets the MchId
        /// 微信支付分配的商户号
        /// </summary>
        [XmlAttribute("mchid")]
        public string MchId { get; set; }

        /// <summary>
        /// Gets or sets the DeviceInfo
        /// 微信支付分配的终端设备号
        /// </summary>
        [XmlAttribute("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// Gets or sets the NonceStr
        /// 随机字符串，不长于32位
        /// </summary>
        [XmlAttribute("nonce_str")]
        public string NonceStr { get; set; }

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

        /// <summary>
        /// The IsSuccess
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public override bool IsSuccess()
        {
            return ReturnCode == "SUCCESS" && ResultCode == "SUCCESS";
        }
    }
}
