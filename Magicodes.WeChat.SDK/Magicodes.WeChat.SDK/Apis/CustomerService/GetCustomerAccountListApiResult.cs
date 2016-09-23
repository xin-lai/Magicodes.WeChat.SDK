// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : GetCustomerAccountListApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.CustomerService
{
    /// <summary>
    ///     获取所有客服账号结果
    /// </summary>
    public class GetCustomerAccountListApiResult : ApiResult
    {
        /// <summary>
        ///     客服账号列表
        /// </summary>
        [JsonProperty("kf_list")]
        public CustomerAccountInfo[] AccountList { get; set; }

        public override bool IsSuccess()
        {
            return Message == null;
        }

        /// <summary>
        ///     客服账号信息
        /// </summary>
        public class CustomerAccountInfo
        {
            /// <summary>
            ///     完整客服账号，格式为：账号前缀@公众号微信号
            /// </summary>
            [JsonProperty("kf_account")]
            public string AccountName { get; set; }

            /// <summary>
            ///     客服昵称
            /// </summary>
            [JsonProperty("kf_nick")]
            public string NickName { get; set; }

            /// <summary>
            ///     客服工号
            /// </summary>
            [JsonProperty("kf_id")]
            public string JobNumber { get; set; }

            /// <summary>
            ///     客服头像
            /// </summary>
            [JsonProperty("kf_headimgurl")]
            public string HeadUrl { get; set; }
        }
    }
}