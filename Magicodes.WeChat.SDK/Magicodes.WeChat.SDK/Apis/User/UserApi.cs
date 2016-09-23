// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;

namespace Magicodes.WeChat.SDK.Apis.User
{
    /// <summary>
    ///     用户信息等相关操作
    /// </summary>
    public class UserApi : ApiBase
    {
        private const string APIName = "user/info";

        /// <summary>
        ///     获取帐号的关注者列表，关注者列表由一串OpenID（加密后的微信号，每个用户对每个公众号的OpenID是唯一的）组成。一次拉取调用最多拉取10000个关注者的OpenID，可以通过多次拉取的方式来满足需求。
        /// </summary>
        /// <param name="nextOpenId">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns>关注者账号列表</returns>
        public OpenIdListGetApiResult GetOpenIdList(string nextOpenId = null)
        {
            var urlParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(nextOpenId))
                urlParams.Add("next_openid", nextOpenId);
            var url = GetAccessApiUrl("get", "user", ApiRoot, urlParams);
            return Get<OpenIdListGetApiResult>(url);
        }

        /// <summary>
        ///     获取用户基本信息
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public UserGetApiResult Get(string openId, string lang = "zh_CN")
        {
            var urlParams = new Dictionary<string, string>();
            urlParams.Add("openid", openId);
            urlParams.Add("lang", lang);
            //获取api请求url
            var url = GetAccessApiUrl(null, APIName, ApiRoot, urlParams);
            return Get<UserGetApiResult>(url);
        }

        /// <summary>
        ///     获取用户基本信息
        /// </summary>
        /// <param name="openIds"></param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public UserBatchGetApiResult Get(string[] openIds, string lang = "zh_CN")
        {
            var userList = new List<dynamic>();
            if (openIds.Length > 100)
                throw new ApiArgumentException("传入的OpenIds长度不能超过100！", "openIds");

            foreach (var item in openIds)
                userList.Add(new
                {
                    openid = item,
                    lang
                });
            var model = new
            {
                user_list = userList
            };
            //获取api请求url
            var url = GetAccessApiUrl("batchget", APIName);
            return Post<UserBatchGetApiResult>(url, model);
        }

        /// <summary>
        ///     设置备注
        /// </summary>
        /// <param name="openId">OpenId</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public ApiResult SetRemark(string openId, string remark)
        {
            //获取api请求url
            var url = GetAccessApiUrl("updateremark", APIName);
            //Post数据
            var model = new
            {
                openid = openId,
                remark
            };
            return Post<ApiResult>(url, model);
        }
    }
}