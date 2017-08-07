using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    ///     关注事件
    /// </summary>
    [XmlRoot("xml")]
    public class FromSubscribeEvent : FromEventBase
    {
        public FromSubscribeEvent()
        {
            Event = FromEventTypes.subscribe;
        }

        /// <summary>
        ///     事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        ///     事件字典值
        /// </summary>
        public Dictionary<string, string> Data
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EventKey))
                {
                    return null;
                }
                return EventKey.StartsWith("{") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(EventKey) : null;
            }
        }

        /// <summary>
        ///     二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }

    /// <summary>
    ///     取消关注事件
    /// </summary>
    public class FromUnsubscribeEvent : FromEventBase
    {
        public FromUnsubscribeEvent()
        {
            Event = FromEventTypes.unsubscribe;
        }
    }

    /// <summary>
    ///     扫描带参数二维码事件
    /// </summary>
    [XmlRoot("xml")]
    public class FromScanEvent : FromEventBase
    {
        public FromScanEvent()
        {
            Event = FromEventTypes.scan;
        }

        /// <summary>
        ///     事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        ///     二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        ///     事件字典值
        /// </summary>
        public Dictionary<string, string> Data
        {
            get
            {
                if (string.IsNullOrWhiteSpace(EventKey))
                {
                    return null;
                }
                return EventKey.StartsWith("{") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(EventKey) : null;
            }
        }
    }

    /// <summary>
    ///     上报地理位置事件
    /// </summary>
    public class FromLocationEvent : FromEventBase
    {
        public FromLocationEvent()
        {
            Event = FromEventTypes.location;
        }

        /// <summary>
        ///     地理位置纬度
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        ///     地理位置经度
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        ///     地理位置精度
        /// </summary>
        public double Precision { get; set; }
    }

    /// <summary>
    ///     点击菜单拉取消息时的事件推送
    ///     用户点击自定义菜单后，微信会把点击事件推送给开发者，请注意，点击菜单弹出子菜单，不会产生上报。
    /// </summary>
    public class FromClickEvent : FromEventBase
    {
        public FromClickEvent()
        {
            Event = FromEventTypes.click;
        }

        /// <summary>
        ///     事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }

    /// <summary>
    ///     点击菜单跳转链接时的事件推送
    /// </summary>
    public class FromViewEvent : FromEventBase
    {
        public FromViewEvent()
        {
            Event = FromEventTypes.view;
        }

        /// <summary>
        ///     事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}