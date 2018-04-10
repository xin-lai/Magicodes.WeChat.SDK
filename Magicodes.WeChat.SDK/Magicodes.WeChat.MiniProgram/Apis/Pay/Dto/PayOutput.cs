using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Magicodes.WeChat.MiniProgram.Apis.Pay.Dto
{
    [XmlRoot("xml")]
    [Serializable]
    public class PayOutput
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

        /// <summary>
        ///     微信分配的公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        ///     微信支付分配的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string Mch_Id { get; set; }

        /// <summary>
        ///     微信支付分配的终端设备号
        /// </summary>
        [XmlElement("device_info")]
        public string Device_Info { get; set; }

        /// <summary>
        ///     随机字符串，不长于32 位
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        ///   业务结果  SUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }


        /// <summary>
        ///     返回状态码
        ///     SUCCESS/FAIL，此字段是通信标识，非交易标识，交易是否成功需要查看result_code来判断
        /// </summary>
        [XmlElement("return_code")]
        public string PayReturnCode { get; set; }

        /// <summary>
        /// 详细结果
        /// </summary>
        [XmlIgnore]
        public string DetailResult { get; set; }

        /// <summary>
        ///     返回信息，返回信息，如非空，为错误原因，签名失败，参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public string Message { get; set; }

        /// <summary>
        /// 是否支付成功
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess() => PayReturnCode == "SUCCESS" && ResultCode == "SUCCESS";

        /// <summary>
        /// 获取错误友好提示
        /// </summary>
        /// <returns></returns>
        public string GetFriendlyMessage() => $"{ErrCode}：{ErrCodeDes}";
    }
}
