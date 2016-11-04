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
    public class MicropayRequest
    {
        private string m_appid;//公众账号ID	是	String(32)	wx8888888888888888	微信分配的公众账号ID（企业号corpid即为此appId）
        private string m_mch_id;//商户号	是	String(32)	1900000109	微信支付分配的商户号
        private string m_device_info;//设备号	否	String(32)	1.3467E+13	终端设备号(商户自定义，如门店编号)
        private string m_nonce_str;//随机字符串	是	String(32)	5K8264ILTKCH16CQ2502SI8ZNMTM67VS	随机字符串，不长于32位。推荐随机数生成算法
        private string m_sign;//签名	是	String(32)	C380BEC2BFD727A4B6845133519F3AD6	签名，详见签名生成算法
        private string m_sign_type;//签名类型	否	String(32)	HMAC-SHA256	签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        private string m_body;//商品描述	是	String(128)	image形象店-深圳腾大- QQ公仔	商品简单描述，该字段须严格按照规范传递，具体请见参数规定
        private string m_detail;//商品详情	否	String(6000)	{	商品详细列表，使用Json格式，传输签名前请务必使用CDATA标签将JSON文本串保护起来。
        private string m_attach;//附加数据	否	String(127)	说明	附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        private string m_out_trade_no;//商户订单号	是	String(32)	1.21775E+27	商户系统内部的订单号,32个字符内、可包含字母,其他说明见商户订单号
        private string m_total_fee;//订单金额	是	Int	888	订单总金额，单位为分，只能为整数，详见支付金额
        private string m_fee_type;//货币类型	否	String(16)	CNY	符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        private string m_spbill_create_ip;//终端IP	是	String(16)	8.8.8.8	调用微信支付API的机器IP
        private string m_goods_tag;//商品标记	否	String(32)	1234	商品标记，代金券或立减优惠功能的参数，说明详见代金券或立减优惠
        private string m_auth_code;//授权码是String(128)1.20061E+17扫码支付授权码，设备读取用户微信中的条码或者二维码信息

        /// <summary>
        /// 公众账号ID	是	String(32)	wx8888888888888888	微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlElement("appid")]
        public string Appid
        {
            get { return m_appid; }
            set { m_appid = value; }
        }

        /// <summary>
        /// 商户号	是	String(32)	1900000109	微信支付分配的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string Mch_id
        {
            get { return m_mch_id; }
            set { m_mch_id = value; }
        }

        /// <summary>
        /// 设备号	否	String(32)	1.3467E+13	终端设备号(商户自定义，如门店编号)
        /// </summary>
        [XmlElement("device_info")]
        public string Device_info
        {
            get { return m_device_info; }
            set { m_device_info = value; }
        }

        /// <summary>
        /// 随机字符串	是	String(32)	5K8264ILTKCH16CQ2502SI8ZNMTM67VS	随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        [XmlElement("nonce_str")]
        public string Nonce_str
        {
            get { return m_nonce_str; }
            set { m_nonce_str = value; }
        }

        /// <summary>
        /// 签名	是	String(32)	C380BEC2BFD727A4B6845133519F3AD6	签名，详见签名生成算法
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

        /// <summary>
        /// 商品描述	是	String(128)	image形象店-深圳腾大- QQ公仔	商品简单描述，该字段须严格按照规范传递，具体请见参数规定
        /// </summary>
        [XmlElement("body")]
        public string Body
        {
            get { return m_body; }
            set { m_body = value; }
        }

        /// <summary>
        /// 商品详情	否	String(6000)	{	商品详细列表，使用Json格式，传输签名前请务必使用CDATA标签将JSON文本串保护起来。
        /// </summary>
        [XmlElement("detail")]
        public string Detail
        {
            get { return m_detail; }
            set { m_detail = value; }
        }

        /// <summary>
        /// 附加数据	否	String(127)	说明	附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        /// </summary>
        [XmlElement("attach")]
        public string Attach
        {
            get { return m_attach; }
            set { m_attach = value; }
        }

        /// <summary>
        /// 商户订单号	是	String(32)	1.21775E+27	商户系统内部的订单号,32个字符内、可包含字母,其他说明见商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string Out_trade_no
        {
            get { return m_out_trade_no; }
            set { m_out_trade_no = value; }
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
        /// 货币类型	否	String(16)	CNY	符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public string Fee_type
        {
            get { return m_fee_type; }
            set { m_fee_type = value; }
        }

        /// <summary>
        /// 终端IP	是	String(16)	8.8.8.8	调用微信支付API的机器IP
        /// </summary>
        [XmlElement("spbill_create_ip")]
        public string Spbill_create_ip
        {
            get { return m_spbill_create_ip; }
            set { m_spbill_create_ip = value; }
        }

        /// <summary>
        /// 商品标记	否	String(32)	1234	商品标记，代金券或立减优惠功能的参数，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("goods_tag")]
        public string Goods_tag
        {
            get { return m_goods_tag; }
            set { m_goods_tag = value; }
        }

        /// <summary>
        /// 授权码是String(128)1.20061E+17扫码支付授权码，设备读取用户微信中的条码或者二维码信息
        /// </summary>
        [XmlElement("auth_code")]
        public string Auth_code
        {
            get { return m_auth_code; }
            set { m_auth_code = value; }
        }
    }
}