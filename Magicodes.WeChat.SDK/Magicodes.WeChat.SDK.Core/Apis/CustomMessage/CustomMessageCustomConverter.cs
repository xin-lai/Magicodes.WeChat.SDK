using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    public class CustomMessageCustomConverter : CustomCreationConverter<CustomMessageSendApiResultBase>
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var jObject = JObject.Load(reader);
            var target = default(CustomMessageSendApiResultBase);
            //获取type属性
            var type = jObject.Property("msgtype");
            if ((type != null) && (type.Count > 0))
            {
                var typeValue = type.Value.ToString();
                var msgType = (MessageTypes)Enum.Parse(typeof(MessageTypes), typeValue);

                #region 根据类型返回相应消息类型
                switch (msgType)
                {
                    case MessageTypes.text:
                        target = new TextMessage();
                        break;
                    case MessageTypes.image:
                        target = new ImageMessage();
                        break;
                    case MessageTypes.voice:
                        target = new VoiceMessage();
                        break;
                    case MessageTypes.video:
                        target = new VideoMessage();
                        break;
                    case MessageTypes.music:
                        target = new MusicMessage();
                        break;
                    case MessageTypes.news:
                        target = new NewsMessage();
                        break;
                    case MessageTypes.mpnews:
                        target = new MpNewsMessage();
                        break;
                    case MessageTypes.wxcard:
                        target = new WxCardMessage();
                        break;
                    default:
                        throw new NotSupportedException("不支持此类型：" + msgType);
                }


                #endregion
            }

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        /// <summary>
        ///     创建对象（会被填充）
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>对象</returns>
        public override CustomMessageSendApiResultBase Create(Type objectType)
        {
            return new CustomMessageSendApiResultBase();
        }
    }
}
