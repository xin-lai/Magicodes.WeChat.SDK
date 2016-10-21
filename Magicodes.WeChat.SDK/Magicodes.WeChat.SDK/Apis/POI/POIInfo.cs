using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicodes.WeChat.SDK.Apis.POI
{
    /// <summary>
    /// 门店信息
    /// </summary>
    public class POIInfo
    {
        [JsonProperty("sid")]
        public string SID { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        [JsonProperty("business_name")]
        public string Name { get; set; }
        /// <summary>
        /// 分店名
        /// </summary>
        [JsonProperty("branch_name")]
        public string BranchName { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        [JsonProperty("province")]
        public string Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }
        /// <summary>
        /// 详细街道地址
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        /// <summary>
        /// 类别
        /// </summary>
        [JsonProperty("categories")]
        public string[] Categorys { get; set; }
        /// <summary>
        /// 门店所在地理位置的经度
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        /// <summary>
        /// 门店所在地理位置的纬度（经纬度均为火星坐标，最好选用腾讯地图标记的坐标）
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        private int offsetType = 1;
        /// <summary>
        /// 坐标类型，1 为火星坐标（目前只能选1）
        /// </summary>
        [JsonProperty("offset_type")]
        internal int OffsetType
        {
            get { return offsetType; }
            set
            {
                offsetType = value;
            }
        }
        /// <summary>
        /// 推荐
        /// </summary>
        [JsonProperty("recommend")]
        public string Recommend { get; set; }
        /// <summary>
        /// 特色服务
        /// </summary>
        [JsonProperty("special")]
        public string Special { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [JsonProperty("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 营业时间
        /// </summary>
        [JsonProperty("open_time")]
        public string OpenTime { get; set; }

        /// <summary>
        /// 人均价格
        /// </summary>
        [JsonProperty("avg_price")]
        public int AvgPrice { get; set; }

        /// <summary>
        /// 图片列表，url 形式，可以有多张图片，尺寸为640*340px。
        /// 必须为上一接口生成的url。图片内容不允许与门店不相关，不允许为二维码、员工合照（或模特肖像）、营业执照、无门店正门的街景、地图截图、公交地铁站牌、菜单截图等。
        /// 不得超过20张
        /// </summary>
        [JsonProperty("photo_list")]
        public List<POIPhotoInfo> PhotoList { get; set; }
    }
}
