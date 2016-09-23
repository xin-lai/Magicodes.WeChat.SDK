// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomerServiceApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Apis.CustomerService
{
    /// <summary>
    ///     客服接口
    /// </summary>
    public class CustomerServiceApi : ApiBase
    {
        private const string ApiName = "customservice";
        private const string CustomerServiceApiRoot = "https://api.weixin.qq.com";

        /// <summary>
        ///     添加客服账号
        /// </summary>
        /// <param name="accountName">客服账号</param>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <returns>调用结果</returns>
        public ApiResult AddCustomerAccount(string accountName, string nickname, string password)
        {
            accountName = SetAccountName(accountName);
            //获取api请求url
            var url = GetAccessApiUrl("kfaccount/add", ApiName, CustomerServiceApiRoot);
            //Post数据
            var model = new
            {
                kf_account = accountName,
                nickname,
                //需要加密处理
                password = password.GetWeChatMd5()
            };
            return Post<ApiResult>(url, model);
        }

        private string SetAccountName(string accountName)
        {
            if (!accountName.Contains("@"))
                accountName = string.Format("{0}@{1}", accountName, AppConfig.WeiXinAccount);
            return accountName;
        }

        /// <summary>
        ///     修改客服账号
        /// </summary>
        /// <param name="accountName">客服账号</param>
        /// <param name="nickname">昵称</param>
        /// <param name="password">密码</param>
        /// <returns>调用结果</returns>
        public ApiResult UpdateCustomerAccount(string accountName, string nickname, string password)
        {
            accountName = SetAccountName(accountName);
            //获取api请求url
            var url = GetAccessApiUrl("kfaccount/update", ApiName, CustomerServiceApiRoot);
            //Post数据
            var model = new
            {
                kf_account = accountName,
                nickname,
                password = password.GetWeChatMd5()
            };
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     删除客服账号
        /// </summary>
        /// <param name="accountName">客服账号</param>
        /// <returns>调用结果</returns>
        public ApiResult RemoveCustomerAccount(string accountName)
        {
            accountName = SetAccountName(accountName);
            var urlParams = new Dictionary<string, string>
            {
                {"kf_account", accountName}
            };
            //获取api请求url
            var url = GetAccessApiUrl("kfaccount/del", ApiName, CustomerServiceApiRoot, urlParams);
            return Get<ApiResult>(url);
        }

        /// <summary>
        ///     获取所有客服账号
        /// </summary>
        /// <returns>所有客服账号结果</returns>
        public GetCustomerAccountListApiResult GetCustomerAccountList()
        {
            //获取api请求url
            var url = GetAccessApiUrl("getkflist", ApiName);
            return Get<GetCustomerAccountListApiResult>(url);
        }
    }
}