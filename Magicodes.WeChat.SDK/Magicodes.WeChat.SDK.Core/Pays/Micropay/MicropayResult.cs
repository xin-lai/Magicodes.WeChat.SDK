using Magicodes.WeChat.SDK.Pays.TenPayV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Pays.MicroPay
{

    [XmlRoot("xml")]
    [Serializable]
    public class MicropayResult : Result
    {
        private string m_openid;//用户标识	是	String(128)	Y	用户在商户appid 下的唯一标识
        private string m_is_subscribe;//是否关注公众账号	是	String(1)	Y	用户是否关注公众账号，仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        private string m_trade_type;//交易类型	是	String(16)	MICROPAY	支付类型为MICROPAY(即扫码支付)
        private string m_detail;//商品详情	否	String(6000)	与提交数据一致	实际提交的返回
        private string m_bank_type;//付款银行	是	String(16)	CMC	银行类型，采用字符串类型的银行标识，值列表详见银行类型
        private string m_fee_type;//货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        private string m_total_fee;//订单金额	是	Int	888	订单总金额，单位为分，只能为整数，详见支付金额
        private string m_settlement_total_fee;//应结订单金额	否	Int	100	应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        private string m_coupon_fee;//代金券金额	否	Int	100	“代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        private string m_cash_fee_type;//现金支付货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        private string m_cash_fee;//现金支付金额	是	Int	100	订单现金支付金额，详见支付金额
        private string m_transaction_id;//微信支付订单号	是	String(32)	1.21775E+27	微信支付订单号
        private string m_out_trade_no;//商户订单号	是	String(32)	1.21775E+27	商户系统的订单号，与请求一致。
        private string m_attach;//商家数据包	否	String(128)	123456	商家数据包，原样返回
        private string m_time_end;//支付完成时间	是	String(14)	2.0141E+13	订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。详见时间规则

        /// <summary>
        /// 用户标识	是	String(128)	Y	用户在商户appid 下的唯一标识
        /// </summary>        
        [XmlElement("openid")]
        public string Openid
        {
            get { return m_openid; }
            set { m_openid = value; }
        }

        /// <summary>
        /// 是否关注公众账号	是	String(1)	Y	用户是否关注公众账号，仅在公众账号类型支付有效，取值范围：Y或N;Y-关注;N-未关注
        /// </summary>        
        [XmlElement("is_subscribe")]
        public string Is_subscribe
        {
            get { return m_is_subscribe; }
            set { m_is_subscribe = value; }
        }

        /// <summary>
        /// 交易类型	是	String(16)	MICROPAY	支付类型为MICROPAY(即扫码支付)
        /// </summary>        
        [XmlElement("trade_type")]
        public string Trade_type
        {
            get { return m_trade_type; }
            set { m_trade_type = value; }
        }

        /// <summary>
        /// 商品详情	否	String(6000)	与提交数据一致	实际提交的返回
        /// </summary>        
        [XmlElement("detail")]
        public string Detail
        {
            get { return m_detail; }
            set { m_detail = value; }
        }

        /// <summary>
        /// 付款银行	是	String(16)	CMC	银行类型，采用字符串类型的银行标识，值列表详见银行类型
        /// </summary>        
        [XmlElement("bank_type")]
        public string Bank_type
        {
            get { return m_bank_type; }
            set { m_bank_type = value; }
        }

        /// <summary>
        /// 货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>        
        [XmlElement("fee_type")]
        public string Fee_type
        {
            get { return m_fee_type; }
            set { m_fee_type = value; }
        }

        /// <summary>
        /// 订单金额	是	Int	888	订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>        
        [XmlElement("total_fee")]
        public string Total_fee
        {
            get { return m_total_fee; }
            set { m_total_fee = value; }
        }

        /// <summary>
        /// 应结订单金额	否	Int	100	应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>        
        [XmlElement("settlement_total_fee")]
        public string Settlement_total_fee
        {
            get { return m_settlement_total_fee; }
            set { m_settlement_total_fee = value; }
        }

        /// <summary>
        /// 代金券金额	否	Int	100	“代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>        
        [XmlElement("coupon_fee")]
        public string Coupon_fee
        {
            get { return m_coupon_fee; }
            set { m_coupon_fee = value; }
        }

        /// <summary>
        /// 现金支付货币类型	否	String(16)	CNY	符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>        
        [XmlElement("cash_fee_type")]
        public string Cash_fee_type
        {
            get { return m_cash_fee_type; }
            set { m_cash_fee_type = value; }
        }

        /// <summary>
        /// 现金支付金额	是	Int	100	订单现金支付金额，详见支付金额
        /// </summary>        
        [XmlElement("cash_fee")]
        public string Cash_fee
        {
            get { return m_cash_fee; }
            set { m_cash_fee = value; }
        }

        /// <summary>
        /// 微信支付订单号	是	String(32)	1.21775E+27	微信支付订单号
        /// </summary>        
        [XmlElement("transaction_id")]
        public string Transaction_id
        {
            get { return m_transaction_id; }
            set { m_transaction_id = value; }
        }

        /// <summary>
        /// 商户订单号	是	String(32)	1.21775E+27	商户系统的订单号，与请求一致。
        /// </summary>        
        [XmlElement("out_trade_no")]
        public string Out_trade_no
        {
            get { return m_out_trade_no; }
            set { m_out_trade_no = value; }
        }

        /// <summary>
        /// 商家数据包	否	String(128)	123456	商家数据包，原样返回
        /// </summary>        
        [XmlElement("attach")]
        public string Attach
        {
            get { return m_attach; }
            set { m_attach = value; }
        }

        /// <summary>
        /// 支付完成时间	是	String(14)	2.0141E+13	订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。详见时间规则
        /// </summary>        
        [XmlElement("time_end")]
        public string Time_end
        {
            get { return m_time_end; }
            set { m_time_end = value; }
        }

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
