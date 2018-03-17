using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Magicodes.WeChat.MiniProgram.Test.Sns
{
    public class SnsTest : TestBase
    {
        [Fact]
        public async Task GetSnsInfoByCode_Test()
        {
            //登录凭证校验Code请自己从小程序开发工具中获取
            //wx.login({
            //    success: function(res) {
            //        if (res.code)
            //        {
            //            console.log(res.code)
            //        }
            //    }
            //})
            var result = MiniProgramApisContext.Current.SnsApi.GetSnsInfoByCode("001p0EE41cBD6L1KWLE41CZGE41p0EEl");
            result.IsSuccess().ShouldBe(expected: true);
            result.OpenId.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
