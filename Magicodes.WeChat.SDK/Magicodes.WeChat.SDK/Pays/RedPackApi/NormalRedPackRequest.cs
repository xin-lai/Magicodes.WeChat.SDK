// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NormalRedPackRequest.cs
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

namespace Magicodes.WeChat.SDK.Pays.RedPackApi
{
    [XmlRoot("xml")]
    [Serializable]
    public class NormalRedPackRequest
    {
        /// <summary>
        ///     随机字符串，不长于32位
        /// </summary>
        [XmlAttribute("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        [XmlAttribute("sign")]
        public string Sign { get; set; }

        /// <summary>
        ///     户订单号（每个订单号必须唯一） 组成：mch_id+yyyymmdd+10位一天内不能重复的数字。接口根据商户订单号支持重入，如出现超时可再调用。
        /// </summary>
        [XmlAttribute("mch_billno")]
        public string MchBillno { get; set; }

        /// <summary>
        ///     微信支付分配的商户号
        /// </summary>
        [XmlAttribute("mch_id")]
        public string MchId { get; set; }

        /// <summary>
        ///     微信分配的公众账号ID（企业号corpid即为此appId）。接口传入的所有appid应该为公众号的appid（在mp.weixin.qq.com申请的），不能为APP的appid（在open.weixin.qq.com申请的）。
        /// </summary>
        [XmlAttribute("wxappid")]
        public string WxAppId { get; set; }

        /// <summary>
        ///     红包发送者名称
        /// </summary>
        [XmlAttribute("send_name")]
        public string SendName { get; set; }

        /// <summary>
        ///     接受红包的用户 用户在wxappid下的openid
        /// </summary>
        [XmlAttribute("re_openid")]
        public string ReOpenId { get; set; }

        /// <summary>
        ///     付款金额，单位分
        /// </summary>
        [XmlAttribute("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>
        ///     红包发放总人数，total_num=1
        /// </summary>
        [XmlAttribute("total_num")]
        public string TotalNum { get; set; }

        /// <summary>
        ///     红包祝福语
        /// </summary>
        [XmlAttribute("wishing")]
        public string Wishing { get; set; }

        /// <summary>
        ///     调用接口的机器Ip地址
        /// </summary>
        [XmlAttribute("client_ip")]
        public string ClientIp { get; set; }

        /// <summary>
        ///     活动名称
        /// </summary>
        [XmlAttribute("act_name")]
        public string ActName { get; set; }

        /// <summary>
        ///     备注
        /// </summary>
        [XmlAttribute("remark")]
        public string Remark { get; set; }
    }
}