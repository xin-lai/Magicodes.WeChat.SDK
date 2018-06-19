// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ReverseResult.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:23
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Pays.Reverse
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Defines the <see cref="ReverseResult" />
    /// </summary>
    [Serializable]
    [XmlRoot("xml")]
    public class ReverseResult : PayResult
    {
        /// <summary>
        /// Gets or sets the Appid
        /// 公众账号ID是String(32)wx8888888888888888返回提交的公众账号ID
        /// </summary>
        [XmlElement("appid")]
        public string Appid { get; set; }

        /// <summary>
        /// Gets or sets the Mch_id
        /// 商户号是String(32)1900000109返回提交的商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string Mch_id { get; set; }

        /// <summary>
        /// Gets or sets the Nonce_str
        /// 随机字符串是String(32)5K8264ILTKCH16CQ2502SI8ZNMTM67VS微信返回的随机字符串
        /// </summary>
        [XmlElement("nonce_str")]
        public string Nonce_str { get; set; }

        /// <summary>
        /// Gets or sets the Sign
        /// 签名是String(32)C380BEC2BFD727A4B6845133519F3AD6返回数据的签名，详见签名算法
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// Gets or sets the Result_code
        /// 业务结果是String(16)SUCCESSSUCCESS/FAIL
        /// </summary>
        [XmlElement("result_code")]
        public string Result_code { get; set; }

        /// <summary>
        /// Gets or sets the Err_code
        /// 错误代码否String(32)SYSTEMERROR详细参见错误列表
        /// </summary>
        [XmlElement("err_code")]
        public string Err_code { get; set; }

        /// <summary>
        /// Gets or sets the Err_code_des
        /// 错误描述否String(128)系统错误结果信息描述
        /// </summary>
        [XmlElement("err_code_des")]
        public string Err_code_des { get; set; }

        /// <summary>
        /// Gets or sets the Recall
        /// 是否重调是String(1)Y是否需要继续调用撤销，Y-需要，N-不需要
        /// </summary>
        [XmlElement("recall")]
        public string Recall { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        /// <returns></returns>
        public override bool IsSuccess()
        {
            return Result_code == "SUCCESS" && ReturnCode == "SUCCESS";
        }
    }
}
