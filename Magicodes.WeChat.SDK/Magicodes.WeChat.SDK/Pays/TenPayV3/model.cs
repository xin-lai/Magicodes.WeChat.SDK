// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : model.cs
//          description :
//  
//          created by 李文强 at  2016/09/21 14:04
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub : https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Pays.TenPayV3
{
    [XmlRoot("xml")]
    [Serializable]
    public class Result : PayResult
    {
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
        ///     SUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }
    }

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


    [XmlRoot("xml")]
    [Serializable]
    public class UnifiedorderRequest
    {
        /// <summary>
        ///     OpenId
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        ///     【不用填写】微信开放平台审核通过的应用APPID
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        ///     【不用填写】微信支付分配的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        ///     终端设备号(门店号或收银设备ID)，默认请传"WEB"
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        ///     随机字符串，不长于32位
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        ///     【不用填写】签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        ///     商品描述交易字段格式根据不同的应用场景按照以下格式： APP——需传入应用市场上的APP名字-实际商品名称，天天爱消除-游戏充值。
        /// </summary>
        [XmlElement("body")]
        public string Body { get; set; }

        /// <summary>
        ///     商品名称明细列表
        /// </summary>
        [XmlElement("detail")]
        public string Detail { get; set; }

        /// <summary>
        ///     附加数据，在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        ///     商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     符合ISO 4217标准的三位字母代码，默认人民币：CNY
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        ///     订单总金额，单位为分
        /// </summary>
        [XmlElement("total_fee")]
        public string TotalFee { get; set; }

        /// <summary>
        ///     用户端实际ip
        /// </summary>
        [XmlElement("spbill_create_ip")]
        public string SpbillCreateIp { get; set; }

        /// <summary>
        ///     订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。
        /// </summary>
        [XmlElement("time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        ///     订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010
        /// </summary>
        [XmlElement("time_expire")]
        public string TimeExpire { get; set; }

        /// <summary>
        ///     商品标记，代金券或立减优惠功能的参数，说明详见代金券或立减优惠
        /// </summary>
        [XmlElement("goods_tag")]
        public string GoodsTag { get; set; }

        /// <summary>
        ///     【不用填写】接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数
        /// </summary>
        [XmlElement("notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        ///     支付类型（JSAPI，NATIVE，APP）公众号内支付填JSAPI
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        ///     no_credit--指定不能使用信用卡支付
        /// </summary>
        [XmlElement("limit_pay")]
        public string LimitPay { get; set; }
    }

    [XmlRoot("xml")]
    [Serializable]
    public class NotifyResult : PayResult
    {
        /// <summary>
        ///     微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        ///     微信支付分配的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        ///     微信支付分配的终端设备号
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        ///     随机字符串，不长于32位
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        ///     业务结果，SUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        ///     错误返回的信息描述
        /// </summary>
        [XmlElement("err_code")]
        public string ErrCode { get; set; }

        /// <summary>
        ///     错误返回的信息描述
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrCodeDes { get; set; }

        /// <summary>
        ///     用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement("openid")]
        public string OpenId { get; set; }

        /// <summary>
        ///     用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [XmlElement("is_subscribe")]
        public string IsSubscribe { get; set; }

        /// <summary>
        ///     交易类型，JSAPI、NATIVE、APP
        /// </summary>
        [XmlElement("trade_type")]
        public string TradeType { get; set; }

        /// <summary>
        ///     银行类型，采用字符串类型的银行标识，银行类型见银行列表
        /// </summary>
        [XmlElement("bank_type")]
        public string BankType { get; set; }

        /// <summary>
        ///     订单总金额，单位为分
        /// </summary>
        [XmlElement("total_fee")]
        public string TotalFee { get; set; }

        /// <summary>
        ///     应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额
        /// </summary>
        [XmlElement("settlement_total_fee")]
        public string SettlementTotalFee { get; set; }

        /// <summary>
        ///     货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        ///     货币类型现金支付金额订单现金支付金额，详见支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public string CashFee { get; set; }

        /// <summary>
        ///     货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement("cash_fee_type")]
        public string CashFeeType { get; set; }

        /// <summary>
        ///     代金券金额<=订单金额，订单金额-代金券金额=现金支付金额，详见支付金额]
        /// </summary>
        [XmlElement("coupon_fee")]
        public string CouponFee { get; set; }

        /// <summary>
        ///     代金券使用数量
        /// </summary>
        [XmlElement("coupon_count")]
        public string CouponCount { get; set; }

        /// <summary>
        ///     CASH--充值代金券         NO_CASH---非充值代金券        订单使用代金券时有返回（取值：CASH、NO_CASH）。$n为下标,从0开始编号，举例：coupon_type_$0
        /// </summary>
        [XmlElement("coupon_type_$n")]
        public string CouponTypeN { get; set; }

        /// <summary>
        ///     代金券ID,$n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_id_$n")]
        public string CouponIdN { get; set; }

        /// <summary>
        ///     单个代金券支付金额,$n为下标，从0开始编号
        /// </summary>
        [XmlElement("coupon_fee_$n")]
        public string CouponFeeN { get; set; }

        /// <summary>
        ///     微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        ///     商户系统的订单号，与请求一致
        /// </summary>
        [XmlElement("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     商家数据包，原样返回
        /// </summary>
        [XmlElement("attach")]
        public string Attach { get; set; }

        /// <summary>
        ///     支付完成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [XmlElement("time_end")]
        public string TimeEnd { get; set; }
    }

    [XmlRoot("xml")]
    [Serializable]
    public class NotifyRequest
    {
        /// <summary>
        ///     SUCCESS/FAIL SUCCESS表示商户接收通知成功并校验成功
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        ///     返回信息，如非空，为错误原因：签名失败 参数格式校验错误
        /// </summary>
        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }
    }
}