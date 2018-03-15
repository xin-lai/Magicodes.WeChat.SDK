// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ApiResult.cs
//          description :
//  
//          created by 李文强 at  2018/03/15 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Apis
{
    /// <summary>
    ///     API请求结果
    /// </summary>
    public class ApiOutput
    {
        /// <summary>
        ///     返回码
        /// </summary>
        [JsonProperty("errcode")]
        public ReturnCodes ReturnCode { get; set; }

        /// <summary>
        ///     错误消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string Message { get; set; }

        /// <summary>
        ///     请求详情（一般请忽略）
        /// </summary>
        public string DetailResult { get; set; }

        /// <summary>
        ///     是否为成功返回
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSuccess()
        {
            return ReturnCode == ReturnCodes.请求成功;
        }

        /// <summary>
        ///     获取友好提示
        /// </summary>
        /// <returns></returns>
        public virtual string GetFriendlyMessage()
        {
            return ReturnCode.ToString();
        }
    }
}