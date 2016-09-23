// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : NormalRedPackResult.cs
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
    public class NormalRedPackResult : Result
    {
        /// <summary>
        ///     商户订单号（每个订单号必须唯一） 组成：mch_id+yyyymmdd+10位一天内不能重复的数字
        /// </summary>
        [XmlAttribute("mch_billno")]
        public string MchBillno { get; set; }

        /// <summary>
        ///     商户号，微信支付分配的商户号
        /// </summary>
        [XmlAttribute("mch_id")]
        public string mch_id { get; set; }

        /// <summary>
        ///     公众账号appid。商户appid，接口传入的所有appid应该为公众号的appid（在mp.weixin.qq.com申请的），不能为APP的appid（在open.weixin.qq.com申请的）。
        /// </summary>
        [XmlAttribute("wxappid")]
        public string WxAppId { get; set; }

        /// <summary>
        ///     用户openid
        /// </summary>
        [XmlAttribute("re_openid")]
        public string ReOpenid { get; set; }

        /// <summary>
        ///     付款金额，单位分
        /// </summary>
        [XmlAttribute("total_amount")]
        public string TotalAmount { get; set; }

        /// <summary>
        ///     红包订单的微信单号
        /// </summary>
        [XmlAttribute("send_listid")]
        public string SendListId { get; set; }
    }
}