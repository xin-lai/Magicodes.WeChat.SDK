// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MicropayResult.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:20
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Pays.MicroPay
{
    using Magicodes.WeChat.SDK.Pays.TenPayV3;
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="MicropayResult" />
    /// </summary>
    [XmlRoot("xml")]
    [Serializable]
    public class MicropayResult : Result
    {
        /// <summary>
        /// Defines the m_attach
        /// </summary>
        private string m_attach;//商家数据包	否	String(128)	123456	商家数据包，原样返回

        /// <summary>
        /// Defines the m_bank_type
        /// </summary>
        private string m_bank_type;//付款银行	是	String(16)	CMC	银行类型，采用字符串类型的银行标识，值列表详见银行类型

        /// <summary>
        /// Defines the m_cash_fee
        /// </summary>
        private string m_cash_fee;//现金支付金额	是	Int	100	订单现金支付金额，详见支付金额

        /// <summary>
        /// Defines the m_cash_fee_type
        /// </summary>
        private string m_cash_fee_type;//现金支付货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型

        /// <summary>
        /// Defines the m_coupon_fee
        /// </summary>
        private string m_coupon_fee;//代金券金额	否	Int	100	“代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额

        /// <summary>
        /// Defines the m_detail
        /// </summary>
        private string m_detail;//商品详情	否	String(6000)	与提交数据一致	实际提交的返回

        /// <summary>
        /// Defines the m_fee_type
        /// </summary>
        private string m_fee_type;//货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型

        /// <summary>
        /// Defines the m_is_subscribe
        /// </summary>
        private string m_is_subscribe;//是否关注公众账号	是	String(1)	Y	用户是否关注公众账号，仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注

        /// <summary>
        /// Defines the m_openid
        /// </summary>
        private string m_openid;//用户标识	是	String(128)	Y	用户在商户appid 下的唯一标识

        /// <summary>
        /// Defines the m_out_trade_no
        /// </summary>
        private string m_out_trade_no;//商户订单号	是	String(32)	1.21775E+27	商户系统的订单号，与请求一致。

        /// <summary>
        /// Defines the m_settlement_total_fee
        /// </summary>
        private string m_settlement_total_fee;//应结订单金额	否	Int	100	应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。

        /// <summary>
        /// Defines the m_time_end
        /// </summary>
        private string m_time_end
            ;//支付完成时间	是	String(14)	2.0141E+13	订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。详见时间规则

        /// <summary>
        /// Defines the m_total_fee
        /// </summary>
        private string m_total_fee;//订单金额	是	Int	888	订单总金额，单位为分，只能为整数，详见支付金额

        /// <summary>
        /// Defines the m_trade_type
        /// </summary>
        private string m_trade_type;//交易类型	是	String(16)	MICROPAY	支付类型为MICROPAY(即扫码支付)

        /// <summary>
        /// Defines the m_transaction_id
        /// </summary>
        private string m_transaction_id;//微信支付订单号	是	String(32)	1.21775E+27	微信支付订单号

        /// <summary>
        /// Gets or sets the Openid
        /// 用户标识	是	String(128)	Y	用户在商户appid 下的唯一标识
        /// </summary>
        [XmlElement("openid")]
        public string Openid { get => m_openid; set => m_openid = value; }

        /// <summary>
        /// Gets or sets the Is_subscribe
        /// 是否关注公众账号	是	String(1)	Y	用户是否关注公众账号，仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        /// </summary>
        [XmlElement("is_subscribe")]
        public string Is_subscribe { get => m_is_subscribe; set => m_is_subscribe = value; }

        /// <summary>
        /// Gets or sets the Trade_type
        /// 交易类型	是	String(16)	MICROPAY	支付类型为MICROPAY(即扫码支付)
        /// </summary>
        [XmlElement("trade_type")]
        public string Trade_type { get => m_trade_type; set => m_trade_type = value; }

        /// <summary>
        /// Gets or sets the Detail
        /// 商品详情	否	String(6000)	与提交数据一致	实际提交的返回
        /// </summary>
        [XmlElement("detail")]
        public string Detail { get => m_detail; set => m_detail = value; }

        /// <summary>
        /// Gets or sets the Bank_type
        /// 付款银行	是	String(16)	CMC	银行类型，采用字符串类型的银行标识，值列表详见银行类型
        /// </summary>
        [XmlElement("bank_type")]
        public string Bank_type { get => m_bank_type; set => m_bank_type = value; }

        /// <summary>
        /// Gets or sets the Fee_type
        /// 货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public string Fee_type { get => m_fee_type; set => m_fee_type = value; }

        /// <summary>
        /// Gets or sets the Total_fee
        /// 订单金额	是	Int	888	订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement("total_fee")]
        public string Total_fee { get => m_total_fee; set => m_total_fee = value; }

        /// <summary>
        /// Gets or sets the Settlement_total_fee
        /// 应结订单金额	否	Int	100	应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public string Settlement_total_fee { get => m_settlement_total_fee; set => m_settlement_total_fee = value; }

        /// <summary>
        /// Gets or sets the Coupon_fee
        /// 代金券金额	否	Int	100	“代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        [XmlElement("coupon_fee")]
        public string Coupon_fee { get => m_coupon_fee; set => m_coupon_fee = value; }

        /// <summary>
        /// Gets or sets the Cash_fee_type
        /// 现金支付货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string Cash_fee_type { get => m_cash_fee_type; set => m_cash_fee_type = value; }

        /// <summary>
        /// Gets or sets the Cash_fee
        /// 现金支付金额	是	Int	100	订单现金支付金额，详见支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public string Cash_fee { get => m_cash_fee; set => m_cash_fee = value; }

        /// <summary>
        /// Gets or sets the Transaction_id
        /// 微信支付订单号	是	String(32)	1.21775E+27	微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string Transaction_id { get => m_transaction_id; set => m_transaction_id = value; }

        /// <summary>
        /// Gets or sets the Out_trade_no
        /// 商户订单号	是	String(32)	1.21775E+27	商户系统的订单号，与请求一致。
        /// </summary>
        [XmlElement("out_trade_no")]
        public string Out_trade_no { get => m_out_trade_no; set => m_out_trade_no = value; }

        /// <summary>
        /// Gets or sets the Attach
        /// 商家数据包	否	String(128)	123456	商家数据包，原样返回
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get => m_attach; set => m_attach = value; }

        /// <summary>
        /// Gets or sets the Time_end
        /// 支付完成时间	是	String(14)	2.0141E+13	订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。详见时间规则
        /// </summary>
        [XmlElement("time_end")]
        public string Time_end { get => m_time_end; set => m_time_end = value; }

        /// <summary>
        /// 是否成功
        /// </summary>
        /// <returns></returns>
        public override bool IsSuccess()
        {
            return ReturnCode == "SUCCESS" && ResultCode == "SUCCESS";
        }
    }
}
