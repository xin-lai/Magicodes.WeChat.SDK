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
            //登录凭证校验Code请自己从小程序界面授权获取
            var result = MiniProgramApisContext.Current.SnsApi.GetSnsInfoByCode("071XJWzy035lcg1rdZCy0KrZzy0XJWzL");
            result.IsSuccess().ShouldBe(expected: true);
            result.OpenId.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
