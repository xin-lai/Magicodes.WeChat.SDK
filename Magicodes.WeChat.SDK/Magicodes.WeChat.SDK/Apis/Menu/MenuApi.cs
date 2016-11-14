// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MenuApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    ///     自定义菜单接口
    ///     http://mp.weixin.qq.com/wiki/10/0234e39a2025342c17a7d23595c6b40a.html
    /// </summary>
    public class MenuApi : ApiBase
    {
        private const string ApiName = "menu";

        /// <summary>
        ///     自定义菜单查询接口
        ///     https://api.weixin.qq.com/cgi-bin/menu/get?access_token=ACCESS_TOKEN
        /// </summary>
        /// <returns>菜单返回结果</returns>
        public MenuGetApiResult Get()
        {
            //获取api请求url
            var url = GetAccessApiUrl("get", ApiName);
            return Get<MenuGetApiResult>(url, new MenuButtonsCustomConverter());
        }

        /// <summary>
        ///     根据JSON字符串获取对象
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public MenuInfo GetMenusByJson(string jsonStr)
        {
            return JsonConvert.DeserializeObject<MenuInfo>(jsonStr, new MenuButtonsCustomConverter());
        }

        /// <summary>
        ///     根据JSON字符串创建菜单
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public ApiResult CreateByJson(string jsonStr)
        {
            return Create(GetMenusByJson(jsonStr));
        }

        /// <summary>
        ///     自定义菜单创建接口
        ///     https://api.weixin.qq.com/cgi-bin/menu/create?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="menuJson">菜单请求json格式</param>
        /// <returns>返回操作结果</returns>
        public ApiResult Create(MenuInfo model)
        {
            var url = GetAccessApiUrl("create", ApiName);
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     自定义菜单删除接口
        ///     https://api.weixin.qq.com/cgi-bin/menu/delete?access_token=ACCESS_TOKEN
        /// </summary>
        /// <returns>返回操作结果</returns>
        public ApiResult Delete()
        {
            var url = GetAccessApiUrl("delete", ApiName);
            return Get<ApiResult>(url);
        }

        /// <summary>
        ///     获取自定义菜单配置接口
        ///     https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token=ACCESS_TOKEN
        /// </summary>
        /// <returns>菜单返回结果(结果会来自2种情况：1,公众平台官网通过网站功能发布菜单2,通过API调用设置的菜单)</returns>
        public SelfMenuGetApiResultModel GetCurrentSelfmenuInfo()
        {
            var url = GetAccessApiUrl(null, "get_current_selfmenu_info");
            return Get<SelfMenuGetApiResultModel>(url, new MenuButtonsCustomConverter());
        }

        #region 个性化菜单接口

        /// <summary>
        ///     创建个性化菜单
        ///     https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="menuJson">菜单请求json格式</param>
        /// <returns>返回操作结果</returns>
        public ApiResult AddConditional(ConditionalMenuInfo model)
        {
            var url = GetAccessApiUrl("addconditional", ApiName);
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     删除个性化菜单
        ///     https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="menuIdJson">菜单id，请求json格式</param>
        /// <returns></returns>
        public ApiResult DelConditional(string menuId)
        {
            var url = GetAccessApiUrl("delconditional", ApiName);
            var model = new { menuid = menuId };
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     测试个性化菜单匹配结果
        ///     https://api.weixin.qq.com/cgi-bin/menu/trymatch?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="userIdJson">粉丝的OpenID或者粉丝的微信号，请求json格式</param>
        /// <returns></returns>
        public MenuGetApiResult TryMatch(string userId)
        {
            var url = GetAccessApiUrl("trymatch", ApiName);
            var model = new { user_id = userId };
            return Post<MenuGetApiResult>(url, model);
        }

        #endregion
    }
}