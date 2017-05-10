using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Magicodes.WeChat.SDK.Core.ServerMessages.From;
using Magicodes.WeChat.SDK.Core.ServerMessages.To;
using Magicodes.WeChat.SDK.Helper;

namespace Magicodes.WeChat.SDK.Core.ServerMessages
{
    /// <summary>
    /// 服务器消息处理
    /// </summary>
    public class ServerMessageHandler
    {
        protected object Key;


        public ServerMessageHandler(object key)
        {
            Key = key;
        }

        /// <summary>
        /// 检查签名
        /// </summary>
        /// <returns>返回正确的签名</returns>
        public bool CheckSignature(string signature, string timestamp, string nonce)
        {
            var token = WeChatConfigManager.Current.GetConfig(Key).Token;
            var arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            var arrString = string.Join("", arr);
            var sha1 = SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            var enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }

            return enText.ToString() == signature;
        }
        /// <summary>
        /// 处理函数集合
        /// </summary>
        public Dictionary<Type, Func<IFromMessage, ToMessageBase>> HandleFuncs =
            new Dictionary<Type, Func<IFromMessage, ToMessageBase>>();

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
            //接收的消息
            IFromMessage fromMessage = null;
            //处理结果
            Tuple<ToMessageBase, IFromMessage> resulTuple = null;
            //处理事件消息
            if (msgType == "event")
            {
                var fromEventTypeElement = xmlElement.Element("Event");
                if (string.IsNullOrWhiteSpace(fromEventTypeElement?.Value)) throw new ApiArgumentException("事件类型不能为空");
                var fromEvent = fromEventTypeElement.Value.Trim().ToLower();
                var fromEventType = (FromEventTypes)Enum.Parse(typeof(FromEventTypes), fromEvent);
                switch (fromEventType)
                {
                    case FromEventTypes.subscribe:
                        resulTuple = await ExcuteHandleFunc<FromSubscribeEvent>(xmlStr);
                        break;
                    case FromEventTypes.unsubscribe:
                        resulTuple = await ExcuteHandleFunc<FromUnsubscribeEvent>(xmlStr);
                        break;
                    case FromEventTypes.scan:
                        resulTuple = await ExcuteHandleFunc<FromScanEvent>(xmlStr);
                        break;
                    case FromEventTypes.location:
                        resulTuple = await ExcuteHandleFunc<FromLocationEvent>(xmlStr);
                        break;
                    case FromEventTypes.click:
                        resulTuple = await ExcuteHandleFunc<FromClickEvent>(xmlStr);
                        break;
                    case FromEventTypes.view:
                        resulTuple = await ExcuteHandleFunc<FromViewEvent>(xmlStr);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            else
            {
                //处理会话消息
                var fromMessageType = (FromMessageTypes)Enum.Parse(typeof(FromMessageTypes), msgType);
                switch (fromMessageType)
                {
                    case FromMessageTypes.text:
                        resulTuple = await ExcuteHandleFunc<FromTextMessage>(xmlStr);
                        break;
                    case FromMessageTypes.image:
                        resulTuple = await ExcuteHandleFunc<FromImageMessage>(xmlStr);
                        break;
                    case FromMessageTypes.voice:
                        resulTuple = await ExcuteHandleFunc<FromVoiceMessage>(xmlStr);
                        break;
                    case FromMessageTypes.video:
                        resulTuple = await ExcuteHandleFunc<FromVideoMessage>(xmlStr);
                        break;
                    case FromMessageTypes.shortvideo:
                        resulTuple = await ExcuteHandleFunc<FromShortVideoMessage>(xmlStr);
                        break;
                    case FromMessageTypes.location:
                        resulTuple = await ExcuteHandleFunc<FromLocationMessage>(xmlStr);
                        break;
                    case FromMessageTypes.link:
                        resulTuple = await ExcuteHandleFunc<FromLinkMessage>(xmlStr);
                        break;
                    default:
                        throw new NotSupportedException("暂不支持类型为[" + msgType + "]的消息类型");
                }
            }

            if (resulTuple != null)
            {
                fromMessage = resulTuple.Item2;
                toMessage = resulTuple.Item1;
            }
            #region 验证多图文格式
            if (toMessage is ToNewsMessage)
            {
                var news = toMessage as ToNewsMessage;
                if (news.Articles.Count > 10)
                    throw new NotSupportedException("图文消息不能超过10条");
                if (news.Articles.Count == 0)
                    throw new ApiArgumentException("至少需要包含一条图文消息");
                news.ArticleCount = news.Articles.Count;
            }
            #endregion
            #region 设置回复消息的时间戳等内容
            if (toMessage != null && toMessage.CreateTimestamp == default(long))
            {
                //设置时间戳
                toMessage.CreateTimestamp = toMessage.CreateDateTime.ConvertToTimeStamp();
                toMessage.FromUserName = fromMessage.ToUserName;
                toMessage.ToUserName = fromMessage.FromUserName;
            } 
            #endregion
            return await Task.FromResult(toMessage);
        }

        /// <summary>
        /// 执行处理函数
        /// </summary>
        /// <typeparam name="T">接受类型</typeparam>
        /// <param name="xmlStr">XML字符串</param>
        /// <returns></returns>
        private async Task<Tuple<ToMessageBase, IFromMessage>> ExcuteHandleFunc<T>(string xmlStr) where T : IFromMessage
        {
            ToMessageBase toMessage = null;
            FromMessageBase fromMessage = null;
            if (HandleFuncs.ContainsKey(typeof(FromTextMessage)))
            {
                fromMessage = XmlHelper.DeserializeObject<FromTextMessage>(xmlStr);
                if (fromMessage != null)
                    toMessage = await Task.FromResult(HandleFuncs[typeof(FromTextMessage)]
                        .Invoke(fromMessage));
            }
            return await Task.FromResult(new Tuple<ToMessageBase, IFromMessage>(toMessage, fromMessage));
        }
    }
}