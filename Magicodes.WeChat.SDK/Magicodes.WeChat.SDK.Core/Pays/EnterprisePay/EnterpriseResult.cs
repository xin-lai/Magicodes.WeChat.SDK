// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : EnterpriseResult.cs
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
    public class EnterpriseResult : PayResult
    {
        public string result_code { get; set; }
        /// <summary>
        ///     商户订单号，需保持唯一性
        /// </summary>
        [XmlAttribute("partner_trade_no")]
        public string PartnerTradeNo { get; set; }

        /// <summary>
        ///     企业付款成功，返回的微信订单号
        /// </summary>
        [XmlAttribute("payment_no")]
        public string PaymentNo { get; set; }

        /// <summary>
        ///     企业付款成功时间
        /// </summary>
        [XmlAttribute("payment_time")]
        public string PaymentTime { get; set; }
    }
}