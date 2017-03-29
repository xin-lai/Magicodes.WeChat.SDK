// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserGroupCreateModel.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.UserGroup
{
    /// <summary>
    ///     用户组创建模型
    /// </summary>
    public class UserGroupCreateModel
    {
        /// <summary>
        ///     用户组
        /// </summary>
        [JsonProperty("group")]
        public UserGroupInfo Group { get; set; }

        /// <summary>
        ///     用户组信息
        /// </summary>
        public class UserGroupInfo
        {
            /// <summary>
            ///     组名
            /// </summary>
            [MaxLength(30)]
            [Required]
            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}