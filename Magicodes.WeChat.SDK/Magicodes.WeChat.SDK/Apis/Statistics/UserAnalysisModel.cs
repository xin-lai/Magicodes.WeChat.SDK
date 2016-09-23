// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : UserAnalysisModel.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     用户数据统计入参模型 Add by zp 2016-01-05
    /// </summary>
    public class UserAnalysisModel
    {
        /// <summary>
        ///     获取数据的开始日期入参 最大时间跨度为7天 即开始时间和结束时间只差只能小于7
        /// </summary>
        [JsonProperty("begin_date")]
        public string BeginDate { get; set; }

        /// <summary>
        ///     获取数据的结束时间
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }
    }
}