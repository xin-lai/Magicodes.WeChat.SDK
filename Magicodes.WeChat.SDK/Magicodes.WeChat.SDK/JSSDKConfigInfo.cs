// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : JSSDKConfigInfo.cs
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
    public class JSSDKConfigInfo
    {
        /// <summary>
        ///     公众号的唯一标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        ///     生成签名的时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        ///     生成签名的随机串
        /// </summary>
        public string NonceStr { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        public string Signature { get; set; }
    }
}