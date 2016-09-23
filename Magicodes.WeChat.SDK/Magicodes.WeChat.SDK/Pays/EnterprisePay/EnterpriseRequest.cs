// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : EnterpriseRequest.cs
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
    [XmlRoot("xml")]
    [Serializable]
    public class EnterpriseRequest
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
        ///     签名
        /// </summary>
        [XmlAttribute("sign")]
        public string Sign { get; set; }

        /// <summary>
        ///     商户订单号，需保持唯一性
        /// </summary>
        [XmlAttribute("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        ///     商户appid下，某用户的openid
        /// </summary>
        [XmlAttribute("openid")]
        public string OpenId { get; set; }

        /// <summary>
        ///     NO_CHECK：不校验真实姓名
        ///     FORCE_CHECK：强校验真实姓名（未实名认证的用户会校验失败，无法转账）
        ///     OPTION_CHECK：针对已实名认证的用户才校验真实姓名（未实名认证用户不校验，可以转账成功）
        /// </summary>
        [XmlAttribute("check_name")]
        public string CheckName { get; set; }

        /// <summary>
        ///     收款用户真实姓名。  如果check_name设置为FORCE_CHECK或OPTION_CHECK，则必填用户真实姓名
        /// </summary>
        [XmlAttribute("re_user_name")]
        public string ReUserName { get; set; }

        /// <summary>
        ///     企业付款金额，单位为分
        /// </summary>
        [XmlAttribute("amount")]
        public string Amount { get; set; }

        /// <summary>
        ///     企业付款操作说明信息。必填。
        /// </summary>
        [XmlAttribute("desc")]
        public string Desc { get; set; }

        /// <summary>
        ///     调用接口的机器Ip地址
        /// </summary>
        [XmlAttribute("spbill_create_ip")]
        public string SpbillCreateIp { get; set; }
    }
}