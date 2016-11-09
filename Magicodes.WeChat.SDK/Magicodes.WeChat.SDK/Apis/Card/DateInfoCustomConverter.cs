// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : DateInfoCustomConverter.cs
//          description :
//  
//          created by 李文强 at  2016/11/9 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    ///     使用日期自定义对象创建转换器
    ///     根据日期类型自定义创建
    /// </summary>
    public class DateInfoCustomConverter : CustomCreationConverter<DateInfo>
    {
        /// <summary>
        ///     读取目标对象的JSON表示
        /// </summary>
        /// <param name="reader">JsonReader</param>
        /// <param name="objectType">对象类型</param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns>对象</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var jObject = JObject.Load(reader);
            DateInfo target = null;
            //获取type属性
            var type = jObject.Property("type");
            if ((type != null) && (type.Count > 0))
            {
                var typeValue = type.Value.ToString();
                var dateInfoType = (DateInfoTypes)Enum.Parse(typeof(DateInfoTypes), typeValue);
                switch (dateInfoType)
                {
                    case DateInfoTypes.DATE_TYPE_FIX_TIME_RANGE:
                        {
                            var fixTimeRangeDateInfo = new FixTimeRangeDateInfo();

                            var beginTime = jObject.Property("begin_time");
                            if ((beginTime != null) && (beginTime.Count > 0))
                            {
                                fixTimeRangeDateInfo.BeginTime = DateTime.Parse(beginTime.Value.ToString());
                            }

                            var endtime = jObject.Property("end_time");
                            if ((endtime != null) && (endtime.Count > 0))
                            {
                                fixTimeRangeDateInfo.EndTime = DateTime.Parse(endtime.Value.ToString());
                            }
                            target = fixTimeRangeDateInfo;
                        }
                        break;
                    case DateInfoTypes.DATE_TYPE_FIX_TERM:
                        {
                            var fixTermDateInfo = new FixTermDateInfo();
                            var endtime = jObject.Property("end_time");
                            if ((endtime != null) && (endtime.Count > 0))
                            {
                                fixTermDateInfo.EndTime = DateTime.Parse(endtime.Value.ToString());
                            }
                            target = fixTermDateInfo;
                        }
                        break;
                    default:
                        break;
                }
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        /// <summary>
        ///     创建对象（会被填充）
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>对象</returns>
        public override DateInfo Create(Type objectType)
        {
            return new DateInfo();
        }
    }
}