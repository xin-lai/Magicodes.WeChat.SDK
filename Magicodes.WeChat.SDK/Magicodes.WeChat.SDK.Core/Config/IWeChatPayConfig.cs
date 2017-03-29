// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : IWeChatPayConfig.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK
{
    public interface IWeChatPayConfig
    {
        /// <summary>
        ///     证书相对路径
        /// </summary>
        string PayCertPath { get; set; }

        /// <summary>
        ///     证书密钥（与微信商户平台商户MchID一致)
        /// </summary>
        string CertPassword { get; set; }

        /// <summary>
        ///     支付密钥
        /// </summary>
        string TenPayKey { get; set; }

        /// <summary>
        ///     商户Mch_ID
        /// </summary>
        string MchId { get; set; }

        /// <summary>
        ///     支付完成后的回调处理页面
        /// </summary>
        string Notify { get; set; }
    }
}