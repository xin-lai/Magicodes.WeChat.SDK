// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : StatisticsApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     数据统计API
    /// </summary>
    public class StatisticsApi : ApiBase
    {
        private const string ApiName = "datacube";
        //因为微信获取数据统计的接口url和其他的url有点不同，在qq.com后面不是cgi-bin 而是datacube
        private const string StatisticsApiRoot = "https://api.weixin.qq.com";


        /// <summary>
        ///     根据微信接口名称获取对应的数据统计
        /// </summary>
        /// <typeparam name="T">ApiResult类型</typeparam>
        /// <param name="begindate">开始统计日期</param>
        /// <param name="enddate">结束统计日期</param>
        /// <param name="funname">微信接口名称</param>
        /// <returns></returns>
        public T GetStatisticsInfo<T>(DateTime begindate, DateTime enddate, string funname) where T : ApiResult
        {
            //获取api请求url
            var url = GetAccessApiUrl(funname, ApiName, StatisticsApiRoot);
            var getSummaryModel = new UserAnalysisModel
            {
                BeginDate = begindate.ToString("yyyy-MM-dd"),
                EndDate = enddate.ToString("yyyy-MM-dd")
            };
            var jsondata = JsonConvert.SerializeObject(getSummaryModel);
            return Post<T>(url, jsondata);
        }

        //protected T Get<T>(string url) where T : ApiResult

        ///// <summary>

        ///// 获取用户增减数据
        ///// </summary>
        ///// <returns>返回结果</returns>
        //public UserSummaryAnalyisResult GetUserSummaryInfo(DateTime begindate,DateTime enddate)
        //{
        //    //获取api请求url
        //    var url = GetAccessApiUrl("getusersummary", APIName, StatisticsAPIRoot);

        //    //添加创建模型
        //    var getSummaryModel = new UserAnalysisModel()
        //    {
        //        BeginDate = begindate.ToString("yyyy-MM-dd"),
        //        EndDate=enddate.ToString("yyyy-MM-dd")
        //    };
        //    string jsondata = JsonConvert.SerializeObject(getSummaryModel);
        //    return Post<UserSummaryAnalyisResult>(url, jsondata);
        //}
    }
}