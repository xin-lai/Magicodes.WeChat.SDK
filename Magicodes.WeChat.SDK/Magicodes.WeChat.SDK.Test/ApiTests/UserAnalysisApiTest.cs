using System;
using Magicodes.WeChat.SDK.Apis.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magicodes.WeChat.SDK.Test.ApiTests
{
    /// <summary>
    /// 用户数据统计API测试
    /// </summary>
    [TestClass]
    public class UserAnalysisApiTest : ApiTestBase
    {
        StatisticsApi api = new StatisticsApi();
        public UserAnalysisApiTest()
        {
        }

        /// <summary>
        /// 获取用户新增数据单元测试
        /// </summary>
        [TestMethod]
        public void UserSummaryApiTest_CURD()
        {

            #region 用户增减数据统计测试
            var beginDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now.AddDays(-1);
            var getSummaryResult = api.GetStatisticsInfo<UserSummaryAnalyisResult> (beginDate, endDate, "getusersummary");

            if (!getSummaryResult.IsSuccess())
            {
                Assert.Fail("获取用户增减数据失败!返回结果如下:" + getSummaryResult.DetailResult);
            }
            #endregion
        }
        /// <summary>
        /// 获取用户累计数单元测试
        /// </summary>
        [TestMethod]
        public void UserCumulateApiTest_CURD()
        {           
            var beginDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now.AddDays(-1);
            var getCumulateResult = api.GetStatisticsInfo<UserCumulateAnalyisResult>(beginDate, endDate, "getusercumulate");
            if (!getCumulateResult.IsSuccess())
            {
                Assert.Fail("获取用户增减数据失败!返回结果如下:" + getCumulateResult.DetailResult);
            } 
        }
        /// <summary>
        /// 图文群发数据统计单元测试
        /// </summary>
        [TestMethod]
        public void ArticlesummaryApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-1);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getartResult= api.GetStatisticsInfo<ArticlesummaryApiResult>(begin_date, end_date, "getarticlesummary");
            if (!getartResult.IsSuccess())
            {
                Assert.Fail("获取图文群发每日数据失败!返回结果如下:" + getartResult.DetailResult);
            }
        }
        /// <summary>
        /// 获取图文群发总数据单元测试
        /// </summary>
        [TestMethod]
        public void ArticletotalApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-1);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getartResult = api.GetStatisticsInfo<ArticletotalApiResult>(begin_date, end_date, "getarticletotal");
            if (!getartResult.IsSuccess())
            {
                Assert.Fail("获取图文群发总数据失败!返回结果如下:" + getartResult.DetailResult);
            }
        }

        /// <summary>
        /// 获取图文统计数据单元测试
        /// </summary>
        [TestMethod]
        public void UserreadApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-3);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getartResult = api.GetStatisticsInfo<UserreadResult>(begin_date, end_date, "getuserread");
            if (!getartResult.IsSuccess())
            {
                Assert.Fail("获取图文统计数据失败!返回结果如下:" + getartResult.DetailResult);
            }  
        }
        [TestMethod]
        /// <summary>
        /// 获取图文统计分时数据单元测试
        /// </summary>
        public void UserreadHourApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-1);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getartResult = api.GetStatisticsInfo<UserreadhourResult>(begin_date, end_date, "getuserreadhour");
            if (!getartResult.IsSuccess())
            {
                Assert.Fail("获取图文统计数据失败!返回结果如下:" + getartResult.DetailResult);
            }
        }

        /// <summary>
        /// 获取图文分享转发数据 单元测试
        /// </summary>
        [TestMethod]
        public void UserShareApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-7);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getusershare= api.GetStatisticsInfo<UsershareResult>(begin_date, end_date, "getusershare");
            if (!getusershare.IsSuccess())
            {
                Assert.Fail("获取图文分享转发数据失败!返回结果如下:" + getusershare.DetailResult);
            }
        }

        /// <summary>
        /// 获取图文分享转发分时数据 单元测试
        /// </summary>
        [TestMethod]
        public void UserShareHourApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-1);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getusersharehour = api.GetStatisticsInfo<UsersharehourResult>(begin_date, end_date, "getusersharehour");
            if (!getusersharehour.IsSuccess())
            {
                Assert.Fail("获取图文分享转发分时数据失败!返回结果如下:" + getusersharehour.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息发送概况数据 单元测试
        /// </summary>
        [TestMethod]
        public void GetUpstreammsgApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-7);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsg = api.GetStatisticsInfo<UpstreammsgResult>(begin_date, end_date, "getupstreammsg");
            if (!getupstreammsg.IsSuccess())
            {
                Assert.Fail("获取消息发送概况数据失败!返回结果如下:" + getupstreammsg.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息分送分时数据 单元测试
        /// </summary>
        [TestMethod]
        public void GetUpstreammsghourApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-1);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsghour = api.GetStatisticsInfo<UpstreammsghourResult>(begin_date, end_date, "getupstreammsghour");
            if (!getupstreammsghour.IsSuccess())
            {
                Assert.Fail("获取消息分送分时数据失败!返回结果如下:" + getupstreammsghour.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息发送周数据 单元测试
        /// </summary>
        [TestMethod]
        public void GetUpstreammsgweekApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-7);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsgweek = api.GetStatisticsInfo<UpstreammsgweekResult>(begin_date, end_date, "getupstreammsgweek");
            if (!getupstreammsgweek.IsSuccess())
            {
                Assert.Fail("获取消息发送周数据失败!返回结果如下:" + getupstreammsgweek.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息发送月数据 单元测试
        /// </summary>
        [TestMethod]
        public void GetUpstreammsgmonthApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-30);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsgmonth = api.GetStatisticsInfo<UpstreammsgmonthResult>(begin_date, end_date, "getupstreammsgmonth");
            if (!getupstreammsgmonth.IsSuccess())
            {
                Assert.Fail("获取消息发送月数据!返回结果如下:" + getupstreammsgmonth.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息发送分布数据 单元测试
        /// </summary>
        public void GetUpstreammsgdistApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-15);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsgdist = api.GetStatisticsInfo<UpstreammsgdistApiResult>(begin_date, end_date, "getupstreammsgdist");
            if (!getupstreammsgdist.IsSuccess())
            {
                Assert.Fail("获取消息发送分布数据失败!返回结果如下:" + getupstreammsgdist.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息发送分布周数据
        /// </summary>
        public void GetUpstreammsgdistweekApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-30);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsgdistweek = api.GetStatisticsInfo<UpstreammsgdistWeekApiResult>(begin_date, end_date, "getupstreammsgdistweek");
            if (!getupstreammsgdistweek.IsSuccess())
            {
                Assert.Fail("获取消息发送分布周数据失败!返回结果如下:" + getupstreammsgdistweek.DetailResult);
            }
        }
        /// <summary>
        /// 获取消息发送分布月数据
        /// </summary>
        public void GetUpstreammsgdistmonthApiTest_CURD()
        {
            DateTime begin_date = DateTime.Now.AddDays(-30);
            DateTime end_date = DateTime.Now.AddDays(-1);
            var getupstreammsgdistmonth = api.GetStatisticsInfo<UpstreammsgdistmonthApiResult>(begin_date, end_date, "getupstreammsgdistmonth");
            if (!getupstreammsgdistmonth.IsSuccess())
            {
                Assert.Fail("获取获取消息发送分布月数据失败!返回结果如下:" + getupstreammsgdistmonth.DetailResult);
            }
        }

    }
}
