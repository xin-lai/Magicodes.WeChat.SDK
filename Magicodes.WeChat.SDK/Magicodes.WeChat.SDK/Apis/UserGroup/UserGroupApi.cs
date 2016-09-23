// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserGroupApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;

namespace Magicodes.WeChat.SDK.Apis.UserGroup
{
    /// <summary>
    ///     用户组增删改查等操作
    /// </summary>
    public class UserGroupApi : ApiBase
    {
        private const string APIName = "groups";

        /// <summary>
        ///     创建组
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <returns>创建模型</returns>
        public UserGroupCreateResultModel Create(string groupName)
        {
            //获取api请求url
            var url = GetAccessApiUrl("create", APIName);
            //添加创建模型
            var createModel = new UserGroupCreateModel
            {
                Group = new UserGroupCreateModel.UserGroupInfo
                {
                    Name = groupName
                }
            };
            return Post<UserGroupCreateResultModel>(url, createModel);
        }

        /// <summary>
        ///     获取所有用户组
        /// </summary>
        /// <returns>返回结果</returns>
        public UserGroupGetResultModel Get()
        {
            //获取api请求url
            var url = GetAccessApiUrl("get", APIName);
            return Get<UserGroupGetResultModel>(url);
        }

        /// <summary>
        ///     获取用户所在组
        /// </summary>
        /// <returns></returns>
        public UserGroupGetByIdResultModel GetById(string openId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("getid", APIName);
            //添加创建模型
            var model = new
            {
                openid = openId
            };
            return Post<UserGroupGetByIdResultModel>(url, model);
        }

        /// <summary>
        ///     修改用户组名称
        /// </summary>
        /// <param name="id">组Id</param>
        /// <param name="newName">新组名</param>
        /// <returns>API调用结果</returns>
        public ApiResult Update(int id, string newName)
        {
            //获取api请求url
            var url = GetAccessApiUrl("update", APIName);
            //Post数据
            var model = new
            {
                group = new
                {
                    id,
                    name = newName
                }
            };
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     移动用户分组
        /// </summary>
        /// <param name="openId">微信用户OPENID</param>
        /// <param name="toGroupId">新组Id</param>
        /// <returns>API调用结果</returns>
        public ApiResult MemeberUpdate(string openId, int toGroupId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("members/update", APIName);
            //Post数据
            var model = new
            {
                openid = openId,
                to_groupid = toGroupId
            };
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     批量移动用户分组
        /// </summary>
        /// <param name="openIds">用户OPENID数组</param>
        /// <param name="toGroupId">目标组Id</param>
        /// <returns>API调用结果</returns>
        public ApiResult MemeberUpdate(string[] openIds, int toGroupId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("members/batchupdate", APIName);
            //Post数据
            var model = new
            {
                openid_list = openIds,
                to_groupid = toGroupId
            };
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     删除分组
        /// </summary>
        /// <param name="groupId">分组Id</param>
        /// <returns>调用结果</returns>
        public ApiResult Delete(int groupId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("delete", APIName);
            //0：未分组
            //1：默认组
            //2：星标组
            if (groupId <= 2)
                throw new Exception("系统组无法删除！");
            //Post数据
            var model = new
            {
                group = new
                {
                    id = groupId
                }
            };
            return Post<ApiResult>(url, model);
        }
    }
}