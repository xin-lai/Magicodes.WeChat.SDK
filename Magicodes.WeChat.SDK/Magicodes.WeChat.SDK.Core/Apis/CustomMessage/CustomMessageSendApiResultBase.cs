// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomMessageSendApiResultBase.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    public class CustomMessageSendApiResultBase
    {
        /// <summary>
        ///     普通用户openid
        /// </summary>
        [JsonProperty("touser")]
        public string Touser { get; set; }

        /// <summary>
        ///     消息类型
        ///     文本为text，图片为image，语音为voice，视频消息为video，音乐消息为music，图文消息（点击跳转到外链）为news，图文消息（点击跳转到图文消息页面）为mpnews，卡券为wxcard
        /// </summary>
        [JsonProperty("msgtype")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageTypes Type { get; set; }

        /// <summary>
        ///     指定发送消息的客服账号
        /// </summary>
        [JsonProperty("customservice")]
        public Customservice Customservice { get; set; }
    }
}