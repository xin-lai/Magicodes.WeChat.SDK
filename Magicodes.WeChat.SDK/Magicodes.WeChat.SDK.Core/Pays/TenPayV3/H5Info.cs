// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : H5Info.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:23
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
    /// H5支付信息
    /// </summary>
    [XmlInclude(typeof(WapInfo))]
    public abstract class H5Info
    {
        /// <summary>
        /// Gets or sets the Type
        /// 场景类型
        /// </summary>
        [XmlElement("type")]
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
