// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserGroupGetByIdResultModel.cs
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
    ///     用户组获取结果模型
    /// </summary>
    public class UserGroupGetByIdResultModel : ApiResult
    {
        /// <summary>
        ///     用户组Id
        /// </summary>
        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        public override bool IsSuccess()
        {
            return Message == null;
        }
    }
}