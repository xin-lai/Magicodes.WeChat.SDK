using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Magicodes.WeChat.SDK.Core.ServerMessages.From;
using Magicodes.WeChat.SDK.Core.ServerMessages.To;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Core.ServerMessages
{
    public class ServerMessageHandler
    {
        protected object Key;


        public ServerMessageHandler(object key)
        {
            Key = key;
        }

        /// <summary>
        ///     接收并处理文本消息
        /// </summary>
        public Func<FromTextMessage, ToMessageBase> HandleTextMessage { get; set; }

        /// <summary>
        ///     处理图片消息
        /// </summary>
        public Func<FromImageMessage, ToMessageBase> HandleImageMessage { get; set; }

        /// <summary>
        ///     处理语音消息
        /// </summary>
        public Func<FromVoiceMessage, ToMessageBase> HandleVoiceMessage { get; set; }

        /// <summary>
        ///     处理链接消息
        /// </summary>
        public Func<FromLinkMessage, ToMessageBase> HandleLinkMessage { get; set; }

        /// <summary>
        ///     处理位置消息
        /// </summary>
        public Func<FromLocationMessage, ToMessageBase> HandleLocationMessage { get; set; }

        /// <summary>
        ///     处理短视频消息
        /// </summary>
        public Func<FromShortVideoMessage, ToMessageBase> HandleShortVideoMessage { get; set; }

        /// <summary>
        ///     处理视频消息
        /// </summary>
        public Func<FromVideoMessage, ToMessageBase> HandleVideoMessage { get; set; }


        /// <summary>
        ///     处理消息
        /// </summary>
        /// <param name="xmlStr">XML字符串</param>
        public async Task<ToMessageBase> HandleMessage(string xmlStr)
        {
            ToMessageBase toMessage = null;
            //记录日志
            WeChatHelper.LoggerAction?.Invoke("ServerMessageHandler", xmlStr);

            var xmlElement = XElement.Parse(xmlStr);
            var msgTypeElement = xmlElement.Element("MsgType");
            if (string.IsNullOrWhiteSpace(msgTypeElement?.Value)) throw new ApiArgumentException("消息类型不能为空");
            var msgType = msgTypeElement.Value.Trim().ToLower();
            var fromMessageType = (FromMessageTypes) Enum.Parse(typeof(FromMessageTypes), msgType);
            //接收的消息
            FromMessageBase formMsg = null;
            switch (fromMessageType)
            {
                case FromMessageTypes.text:
                    if (HandleTextMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromTextMessage>(xmlStr);
                        toMessage = await Task.FromResult(HandleTextMessage.Invoke((FromTextMessage) formMsg));
                    }
                    break;
                case FromMessageTypes.image:
                    if (HandleImageMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromImageMessage>(xmlStr);
                        toMessage = await Task.FromResult(HandleImageMessage.Invoke((FromImageMessage) formMsg));
                    }
                    break;
                case FromMessageTypes.voice:
                    if (HandleVoiceMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromVoiceMessage>(xmlStr);
                        toMessage = await Task.FromResult(HandleVoiceMessage.Invoke((FromVoiceMessage) formMsg));
                    }
                    break;
                case FromMessageTypes.video:
                    if (HandleVideoMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromVideoMessage>(xmlStr);
                        toMessage = await Task.FromResult(HandleVideoMessage.Invoke((FromVideoMessage) formMsg));
                    }
                    break;
                case FromMessageTypes.shortvideo:
                    if (HandleShortVideoMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromShortVideoMessage>(xmlStr);
                        toMessage = await Task.FromResult(
                            HandleShortVideoMessage.Invoke((FromShortVideoMessage) formMsg));
                    }
                    break;
                case FromMessageTypes.location:
                    if (HandleLocationMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromLocationMessage>(xmlStr);
                        toMessage = await Task.FromResult(HandleLocationMessage.Invoke((FromLocationMessage) formMsg));
                    }
                    break;
                case FromMessageTypes.link:
                    if (HandleLinkMessage != null)
                    {
                        formMsg = XmlHelper.DeserializeObject<FromLinkMessage>(xmlStr);
                        toMessage = await Task.FromResult(HandleLinkMessage.Invoke((FromLinkMessage) formMsg));
                    }
                    break;
                default:
                    throw new NotSupportedException("暂不支持类型为[" + msgType + "]的消息类型");
            }
            if (toMessage is ToNewsMessage)
            {
                var news = toMessage as ToNewsMessage;
                if (news.Articles.Count > 10)
                    throw new NotSupportedException("图文消息不能超过10条");
                if (news.Articles.Count == 0)
                    throw new ApiArgumentException("至少需要包含一条图文消息");
                news.ArticleCount = news.Articles.Count;
            }
            if (toMessage != null && toMessage.CreateTimestamp == default(long))
            {
                //设置时间戳
                toMessage.CreateTimestamp = toMessage.CreateDateTime.ConvertToTimeStamp();
                toMessage.FromUserName = formMsg.ToUserName;
                toMessage.ToUserName = formMsg.FromUserName;
            }
            return await Task.FromResult(toMessage);
        }
    }
}