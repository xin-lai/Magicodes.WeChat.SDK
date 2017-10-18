using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.Pays.TenPayV3
{
    /// <summary>
    /// 支付的场景信息
    /// </summary>
    public class SceneInfo
    {
        /// <summary>
        /// H5支付信息
        /// </summary>
        [XmlElement("h5_info")]
        public H5Info H5Info { get; set; }
    }
}
