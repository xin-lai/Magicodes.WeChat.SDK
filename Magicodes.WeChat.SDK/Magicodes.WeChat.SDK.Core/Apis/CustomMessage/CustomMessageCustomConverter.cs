// ======================================================================
//  
//          Copyright (C) 2018-2068 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomMessageCustomConverter.cs
//          description :
//  
//          created by codelove1314@live.cn at  2018-06-19 10:47:49
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// =======================================================================

namespace Magicodes.WeChat.SDK.Apis.CustomMessage
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using System;

    /// <summary>
    /// 客服消息格式转换器 <see cref="CustomMessageCustomConverter" />
    /// </summary>
    public class CustomMessageCustomConverter : CustomCreationConverter<CustomMessageSendApiResultBase>
    {
        /// <summary>
        /// The ReadJson
        /// </summary>
        /// <param name="reader">The reader<see cref="JsonReader"/></param>
        /// <param name="objectType">The objectType<see cref="Type"/></param>
        /// <param name="existingValue">The existingValue<see cref="object"/></param>
        /// <param name="serializer">The serializer<see cref="JsonSerializer"/></param>
        /// <returns>The <see cref="object"/></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var jObject = JObject.Load(reader);
            var target = default(CustomMessageSendApiResultBase);
            //获取type属性
            var type = jObject.Property("msgtype");
            if (type != null && type.Count > 0)
            {
                var typeValue = type.Value.ToString();
                var msgType = (MessageTypes)Enum.Parse(typeof(MessageTypes), typeValue);


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

            }

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        /// <summary>
        /// 创建对象（会被填充）
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>对象</returns>
        public override CustomMessageSendApiResultBase Create(Type objectType)
        {
            return new CustomMessageSendApiResultBase();
        }
    }
}
