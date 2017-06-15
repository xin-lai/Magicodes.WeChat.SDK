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
    public class QueryRequest
    {
        private string m_appid;//公众账号ID	是	String(32)	wxd678efh567hg6787	微信分配的公众账号ID（企业号corpid即为此appId）
        private string m_mch_id;//商户号	是	String(32)	1230000109	微信支付分配的商户号
        private string m_transaction_id;//微信订单号	二选一	String(32)	1.00966E+27	微信的订单号，优先使用
        private string m_out_trade_no;//商户订单号		String(32)	2.01508E+13	商户系统内部的订单号，当没提供transaction_id时需要传这个。
        private string m_nonce_str;//随机字符串	是	String(32)	C380BEC2BFD727A4B6845133519F3AD6	随机字符串，不长于32位。推荐随机数生成算法
        private string m_sign;//签名	是	String(32)	5K8264ILTKCH16CQ2502SI8ZNMTM67VS	签名，详见签名生成算法
        private string m_sign_type;//签名类型	否	String(32)	HMAC-SHA256	签名类型，目前支持HMAC-SHA256和MD5，默认为MD5

        /// <summary>
        /// 公众账号ID	是	String(32)	wxd678efh567hg6787	微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlElement("appid")]
        public string Appid
        {
            get { return m_appid; }
            set { m_appid = value; }
        }

        /// <summary>
        /// 商户号	是	String(32)	1230000109	微信支付分配的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string Mch_id
        {
            get { return m_mch_id; }
            set { m_mch_id = value; }
        }

        /// <summary>
        /// 微信订单号	二选一	String(32)	1.00966E+27	微信的订单号，优先使用
        /// </summary>
        [XmlElement("transaction_id")]
        public string Transaction_id
        {
            get { return m_transaction_id; }
            set { m_transaction_id = value; }
        }

        /// <summary>
        /// 商户订单号		String(32)	2.01508E+13	商户系统内部的订单号，当没提供transaction_id时需要传这个。
        /// </summary>
        [XmlElement("out_trade_no")]
        public string Out_trade_no
        {
            get { return m_out_trade_no; }
            set { m_out_trade_no = value; }
        }

        /// <summary>
        /// 随机字符串	是	String(32)	C380BEC2BFD727A4B6845133519F3AD6	随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        [XmlElement("nonce_str")]
        public string Nonce_str
        {
            get { return m_nonce_str; }
            set { m_nonce_str = value; }
        }

        /// <summary>
        /// 签名	是	String(32)	5K8264ILTKCH16CQ2502SI8ZNMTM67VS	签名，详见签名生成算法
        /// </summary>
        [XmlElement("sign")]
        public string Sign
        {
            get { return m_sign; }
            set { m_sign = value; }
        }

        /// <summary>
        /// 签名类型	否	String(32)	HMAC-SHA256	签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [XmlElement("sign_type")]
        public string Sign_type
        {
            get { return m_sign_type; }
            set { m_sign_type = value; }
        }



    }
}
