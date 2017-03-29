// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : XmlHelper.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Magicodes.WeChat.SDK.Helper
{
    public class XmlHelper
    {
        /// <summary>
        ///     XML序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var xmlSerial = new XmlSerializer(obj.GetType());
                //序列化对象
                xmlSerial.Serialize(stream, obj);
                stream.Position = 0;
                using (var sr = new StreamReader(stream))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        ///     反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(Stream stream)
        {
            var xmlSerial = new XmlSerializer(typeof(T));
            return (T) xmlSerial.Deserialize(stream);
        }

        /// <summary>
        ///     反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string input) where T : class
        {
            if (!input.StartsWith("<?xml"))
                input = @"<?xml version=""1.0"" encoding=""gb2312""?>" + input;
            using (var mem = new MemoryStream(Encoding.Default.GetBytes(input)))
            {
                using (var reader = XmlReader.Create(mem))
                {
                    var formatter = new XmlSerializer(typeof(T));
                    return formatter.Deserialize(reader) as T;
                }
            }
        }
    }
}