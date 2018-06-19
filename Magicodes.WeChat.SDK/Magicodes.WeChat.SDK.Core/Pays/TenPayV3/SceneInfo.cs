// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : SceneInfo.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:48:24
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
    /// 支付的场景信息
    /// </summary>
    public class SceneInfo
    {
        /// <summary>
        /// Gets or sets the H5Info
        /// H5支付信息
        /// </summary>
        [XmlElement("h5_info")]
        [JsonProperty("h5_info")]
        public H5Info H5Info { get; set; }
    }
}
