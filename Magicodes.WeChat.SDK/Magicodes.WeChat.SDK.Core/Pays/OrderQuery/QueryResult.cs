using Magicodes.WeChat.SDK.Pays.TenPayV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Pays.OrderQuery
{
    [Serializable]
    [XmlRoot("xml")]
    public class QueryResult : Result
    {
        private string m_openid;//用户标识	是	String(128)	oUpF8uMuAJO_M2pxb1Q9zNjWeS6o	用户在商户appid下的唯一标识
        private string m_is_subscribe;//是否关注公众账号	否	String(1)	Y	用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        private string m_trade_type;//交易类型	是	String(16)	JSAPI	调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，MICROPAY，详细说明见参数规定
        private string m_trade_state;//交易状态	是	String(32)	SUCCESS	SUCCESS—支付成功,REFUND—转入退款,NOTPAY—未支付,CLOSED—已关闭,REVOKED—已撤销（刷卡支付）,USERPAYING--用户支付中,PAYERROR--支付失败(其他原因，如银行返回失败)
        private string m_bank_type;//付款银行	是	String(16)	CMC	银行类型，采用字符串类型的银行标识
        private string m_total_fee;//订单金额	是	Int	100	订单总金额，单位为分
        private string m_settlement_total_fee;//应结订单金额	否	Int	100	应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        private string m_fee_type;//货币种类	否	String(8)	CNY	货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        private string m_cash_fee;//现金支付金额	是	Int	100	现金支付金额订单现金支付金额，详见支付金额
        private string m_cash_fee_type;//现金支付货币类型	否	String(16)	CNY	货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        private string m_coupon_fee;//代金券金额	否	Int	100	“代金券”金额<=订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        private string m_coupon_count;//代金券使用数量	否	Int	1	代金券使用数量
        private string m_coupon_type_0;//代金券类型	否	String	CASH	CASH--充值代金券,NO_CASH---非充值代金券,订单使用代金券时有返回（取值：CASH、NO_CASH）。$n为下标,从0开始编号，举例：coupon_type_$0
        private string m_coupon_id_0;//代金券ID	否	String(20)	10000 	代金券ID, $n为下标，从0开始编号
        private string m_coupon_fee_0;//单个代金券支付金额	否	Int	100	单个代金券支付金额, $n为下标，从0开始编号
        private string m_transaction_id;//微信支付订单号	是	String(32)	1.00966E+27	微信支付订单号
        private string m_out_trade_no;//商户订单号	是	String(32)	2.01508E+13	商户系统的订单号，与请求一致。
        private string m_attach;//附加数据	否	String(128)	深圳分店	附加数据，原样返回
        private string m_time_end;//支付完成时间	是	String(14)	2.0141E+13	订单支付时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        private string m_trade_state_desc;//交易状态描述	是	String(256)	支付失败，请重新下单支付	对当前查询订单状态的描述和下一步操作的指引



        /// <summary>
        /// 用户标识	是	String(128)	oUpF8uMuAJO_M2pxb1Q9zNjWeS6o	用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement("openid")]
        public string Openid
        {
            get { return m_openid; }
            set { m_openid = value; }
        }

        /// <summary>
        /// 是否关注公众账号	否	String(1)	Y	用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [XmlElement("is_subscribe")]
        public string Is_subscribe
        {
            get { return m_is_subscribe; }
            set { m_is_subscribe = value; }
        }

        /// <summary>
        /// 交易类型	是	String(16)	JSAPI	调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，MICROPAY，详细说明见参数规定
        /// </summary>
        [XmlElement("trade_type")]
        public string Trade_type
        {
            get { return m_trade_type; }
            set { m_trade_type = value; }
        }

        /// <summary>
        /// 交易状态	是	String(32)	SUCCESS	SUCCESS—支付成功,REFUND—转入退款,NOTPAY—未支付,CLOSED—已关闭,REVOKED—已撤销（刷卡支付）,USERPAYING--用户支付中,PAYERROR--支付失败(其他原因，如银行返回失败)
        /// </summary>
        [XmlElement("trade_state")]
        public string Trade_state
        {
            get { return m_trade_state; }
            set { m_trade_state = value; }
        }

        /// <summary>
        /// 付款银行	是	String(16)	CMC	银行类型，采用字符串类型的银行标识
        /// </summary>
        [XmlElement("bank_type")]
        public string Bank_type
        {
            get { return m_bank_type; }
            set { m_bank_type = value; }
        }

        /// <summary>
        /// 订单金额	是	Int	100	订单总金额，单位为分
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
        /// 货币种类	否	String(8)	CNY	货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public string Fee_type
        {
            get { return m_fee_type; }
            set { m_fee_type = value; }
        }

        /// <summary>
        /// 现金支付金额	是	Int	100	现金支付金额订单现金支付金额，详见支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public string Cash_fee
        {
            get { return m_cash_fee; }
            set { m_cash_fee = value; }
        }

        /// <summary>
        /// 现金支付货币类型	否	String(16)	CNY	货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string Cash_fee_type
        {
            get { return m_cash_fee_type; }
            set { m_cash_fee_type = value; }
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
        /// 代金券使用数量	否	Int	1	代金券使用数量
        /// </summary>
        [XmlElement("coupon_count")]
        public string Coupon_count
        {
            get { return m_coupon_count; }
            set { m_coupon_count = value; }
        }

        /// <summary>
        /// 代金券类型	否	String	CASH	CASH--充值代金券,NO_CASH---非充值代金券,订单使用代金券时有返回（取值：CASH、NO_CASH）。$n为下标,从0开始编号，举例：coupon_type_$0
        /// </summary>
        [XmlElement("coupon_type_0")]
        public string Coupon_type_0
        {
            get { return m_coupon_type_0; }
            set { m_coupon_type_0 = value; }
        }

        /// <summary>
        /// 代金券ID	否	String(20)	10000 	代金券ID, $n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_id_0")]
        public string Coupon_id_0
        {
            get { return m_coupon_id_0; }
            set { m_coupon_id_0 = value; }
        }

        /// <summary>
        /// 单个代金券支付金额	否	Int	100	单个代金券支付金额, $n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_fee_0")]
        public string Coupon_fee_0
        {
            get { return m_coupon_fee_0; }
            set { m_coupon_fee_0 = value; }
        }

        /// <summary>
        /// 微信支付订单号	是	String(32)	1.00966E+27	微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string Transaction_id
        {
            get { return m_transaction_id; }
            set { m_transaction_id = value; }
        }

        /// <summary>
        /// 商户订单号	是	String(32)	2.01508E+13	商户系统的订单号，与请求一致。
        /// </summary>
        [XmlElement("out_trade_no")]
        public string Out_trade_no
        {
            get { return m_out_trade_no; }
            set { m_out_trade_no = value; }
        }

        /// <summary>
        /// 附加数据	否	String(128)	深圳分店	附加数据，原样返回
        /// </summary>
        [XmlElement("attach")]
        public string Attach
        {
            get { return m_attach; }
            set { m_attach = value; }
        }

        /// <summary>
        /// 支付完成时间	是	String(14)	2.0141E+13	订单支付时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [XmlElement("time_end")]
        public string Time_end
        {
            get { return m_time_end; }
            set { m_time_end = value; }
        }

        /// <summary>
        /// 交易状态描述	是	String(256)	支付失败，请重新下单支付	对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        [XmlElement("trade_state_desc")]
        public string Trade_state_desc
        {
            get { return m_trade_state_desc; }
            set { m_trade_state_desc = value; }
        }

        /// <summary>
        ///是否成功
        /// </summary>
        /// <returns></returns>
        public override bool IsSuccess()
        {
            return ResultCode == "SUCCESS" && ReturnCode == "SUCCESS";
        }
    }
}
