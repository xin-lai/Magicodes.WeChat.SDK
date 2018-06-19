// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MessageApi.cs
//          description :
//  
//          created by 李文强 at  2017/03/22 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.Message
{
    using Magicodes.WeChat.SDK.Apis.Message.Input;
    using Magicodes.WeChat.SDK.Apis.Message.Result;

    /// <summary>
    /// 高级群发接口
    ///     http://mp.weixin.qq.com/wiki/15/40b6865b893947b764e2de8e4a1fb55f.html
    /// </summary>
    public class MessageApi : ApiBase
    {
        /// <summary>
        /// Defines the ApiName
        /// </summary>
        private const string ApiName = "message";

        /// <summary>
        /// 全部群发或者根据分组进行群发【订阅号与服务号认证后均可用】
        ///     https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="input">The input<see cref="SendAllInputBase"/></param>
        /// <returns>返回操作结果</returns>
        public MessageApiResult SendAll(SendAllInputBase input)
        {
            var url = GetAccessApiUrl("mass/sendall", ApiName);
            return Post<MessageApiResult>(url, input);
        }

        /// <summary>
        /// 根据OpenID列表群发【订阅号不可用，服务号认证后可用】
        ///     https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public MessageApiResult Send(SendInputBase input)
        {
            var url = GetAccessApiUrl("mass/send", ApiName);
            return Post<MessageApiResult>(url, input);
        }

        /// <summary>
        /// 删除群发【订阅号与服务号认证后均可用】
        ///     https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public ApiResult Delete(string messageId)
        {
            var url = GetAccessApiUrl("mass/delete", ApiName);
            return Post<MessageApiResult>(url, new { msg_id = messageId });
        }

        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】
        ///     https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token=ACCESS_TOKEN
        /// </summary>
        /// <param name="input">The input<see cref="PreviewInputBase"/></param>
        /// <returns></returns>
        public ApiResult Preview(PreviewInputBase input)
        {
            var url = GetAccessApiUrl("mass/preview", ApiName);
            return Post<MessageApiResult>(url, input);
        }
    }
}
