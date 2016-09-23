// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UnifiedorderResult.cs
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
    public class UnifiedorderResult : Result
    {
        /// <summary>
        ///     交易类型:JSAPI、NATIVE、APP
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        ///     微信生成的预支付ID，用于后续接口调用中使用
        /// </summary>
        [XmlElement("prepay_id")]
        public string PrepayId { get; set; }

        /// <summary>
        ///     trade_type为NATIVE时有返回，此参数可直接生成二维码展示出来进行扫码支付
        /// </summary>
        [XmlElement("code_url")]
        public string CodeUrl { get; set; }
    }
}