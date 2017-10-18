using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.Pays.TenPayV3
{
    /// <summary>
    /// WAP支付信息
    /// </summary>
    public class WapInfo : H5Info
    {
        public WapInfo()
        {
            Type = "Wap";
        }

        /// <summary>
        /// WAP网站URL地址
        /// </summary>
        [XmlElement("wap_url")]
        public string WapUrl { get; set; }

        /// <summary>
        /// WAP 网站名
        /// </summary>
        [XmlElement("wap_name")]
        public string WapName { get; set; }
    }
}
