using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Core.Pays.TenPayV3
{
    /// <summary>
    /// H5支付信息
    /// </summary>
    [XmlInclude(typeof(WapInfo))]
    public abstract class H5Info
    {
        /// <summary>
        /// 场景类型
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }
    }
}