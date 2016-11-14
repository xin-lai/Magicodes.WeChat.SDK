// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ApiResult.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis
{
    /// <summary>
    ///     API请求结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        ///     返回码
        /// </summary>
        [JsonProperty("errcode")]
        public ReturnCodes ReturnCode { get; set; }

        /// <summary>
        ///     消息
        /// </summary>
        [JsonProperty("errmsg")]
        public string Message { get; set; }

        /// <summary>
        ///     详细内容
        /// </summary>
        public string DetailResult { get; set; }

        /// <summary>
        ///     是否为成功返回
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSuccess()
        {
            return
                ((Message == "ok") && (ReturnCode == ReturnCodes.请求成功)) ||
                //为了应付微信神坑，返回{}
                ((ReturnCode == ReturnCodes.请求成功) && (Message == null)) ||
                //这字符串我也是醉了
                ((Message == "no error") && (ReturnCode == ReturnCodes.请求成功));
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