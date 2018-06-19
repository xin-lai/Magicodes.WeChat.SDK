// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : WapInfo.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:25
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Core.Pays.TenPayV3
{
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    /// <summary>
    /// WAP支付信息
    /// </summary>
    public class WapInfo : H5Info
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WapInfo"/> class.
        /// </summary>
        public WapInfo()
        {
            Type = "Wap";
        }

        /// <summary>
        /// Gets or sets the WapUrl
        /// WAP网站URL地址
        /// </summary>
        [XmlElement("wap_url")]
        [JsonProperty("wap_url")]
        public string WapUrl { get; set; }

        /// <summary>
        /// Gets or sets the WapName
        /// WAP 网站名
        /// </summary>
        [XmlElement("wap_name")]
        [JsonProperty("wap_name")]
        public string WapName { get; set; }
    }
}
