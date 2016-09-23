// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomMessageApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    /// <summary>
    ///     客服接口
    /// </summary>
    public class CustomMessageApi : ApiBase
    {
        private const string ApiName = "message/custom";

        /// <summary>
        ///     发送文本消息
        /// </summary>
        /// <returns></returns>
        public ApiResult SendTextMessage(TextMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送图片消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendImageMessage(ImageMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送语音消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendVoiceMessage(VoiceMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送视频消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendVideoMessage(VideoMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送音乐消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendMusicMessage(MusicMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送多图文消息（外链）
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendNewsMessage(NewsMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送多图文消息（微信内置图文页）
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendMpNewsMessage(MpNewsMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送卡券
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ApiResult SendWxCardMessage(WxCardMessage message)
        {
            return Send(message);
        }

        /// <summary>
        ///     发送客服消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private ApiResult Send(CustomMessageSendApiResultBase model)
        {
            //获取api请求url
            var url = GetAccessApiUrl("send", ApiName);
            return Post<ApiResult>(url, model);
        }
    }
}