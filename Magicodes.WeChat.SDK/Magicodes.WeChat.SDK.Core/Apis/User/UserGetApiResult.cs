// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserGetApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Magicodes.WeChat.SDK.Helper;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.User
{
    /// <summary>
    ///     用户信息返回结果
    /// </summary>
    public class UserGetApiResult : ApiResult
    {
        /// <summary>
        ///     用户是否订阅该公众号标识，值为False时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        [JsonProperty("subscribe")]
        public bool Subscribe { get; set; }

        /// <summary>
        ///     用户的标识，对当前公众号唯一
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        ///     用户的昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        ///     用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        [JsonProperty("sex")]
        public WeChatSexTypes Sex { get; set; }

        /// <summary>
        ///     用户的语言，简体中文为zh_CN
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        ///     用户所在城市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        ///     用户所在省份
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }

        /// <summary>
        ///     用户所在国家
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        ///     用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        [JsonProperty("headimgurl")]
        public string Headimgurl { get; set; }

        /// <summary>
        ///     用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        [JsonProperty("subscribe_time")]
        internal long Subscribe_Time { get; set; }

        /// <summary>
        ///     用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public DateTime SubscribeTime
        {
            get { return Subscribe_Time > 0 ? Subscribe_Time.ConvertToDateTime() : default(DateTime); }
        }

        /// <summary>
        ///     只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。详见：获取用户个人信息（UnionID机制）
        /// </summary>
        [JsonProperty("unionid")]
        public string Unionid { get; set; }

        /// <summary>
        ///     公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        ///     用户所在的分组ID
        /// </summary>
        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        public override bool IsSuccess()
        {
            return Subscribe;
        }
    }
}