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

namespace Magicodes.WeChat.SDK.Pays.TenPayV3
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="UnifiedorderResult" />
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class UnifiedorderResult : Result
    {
        /// <summary>
        /// Gets or sets the TradeType
        /// 交易类型:JSAPI、NATIVE、APP
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        /// Gets or sets the PrepayId
        /// 微信生成的预支付ID，用于后续接口调用中使用
        /// </summary>
        [XmlElement("prepay_id")]
        public string PrepayId { get; set; }

        /// <summary>
        /// Gets or sets the CodeUrl
        /// trade_type为NATIVE时有返回，此参数可直接生成二维码展示出来进行扫码支付
        /// </summary>
        [XmlElement("code_url")]
        public string CodeUrl { get; set; }

        /// <summary>
        /// Gets or sets the MWebUrl
        /// mweb_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付,mweb_url的有效期为5分钟。
        /// </summary>
        [XmlElement("mweb_url")]
        public string MWebUrl { get; set; }
    }
}
