// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserGroupCreateResultModel.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.UserGroup
{
    /// <summary>
    ///     用户组创建结果模型
    /// </summary>
    public class UserGroupCreateResultModel : ApiResult
    {
        /// <summary>
        ///     用户组
        /// </summary>
        [JsonProperty("group")]
        public UserGroupInfo Group { get; set; }

        public override bool IsSuccess()
        {
            return Message == null;
        }

        /// <summary>
        ///     用户组信息
        /// </summary>
        public class UserGroupInfo
        {
            /// <summary>
            ///     分组id，由微信分配
            /// </summary>
            [JsonProperty("id")]
            public int Id { get; set; }

            /// <summary>
            ///     分组名字，UTF8编码
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}