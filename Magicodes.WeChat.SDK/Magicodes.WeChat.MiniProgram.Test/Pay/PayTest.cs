using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Magicodes.WeChat.MiniProgram.Apis.Pay.Dto;

namespace Magicodes.WeChat.MiniProgram.Test.Pay
{
    public class PayTest : TestBase
    {
        [Fact]
        public void Pay_Test()
        {
            var result = MiniProgramApisContext.Current.PayApi.Pay(new PayInput()
            {
                Body = "Test",
                OpenId = "oBVdJ5Os4Wkdard-6DmT5BcGWhEg",
                SpbillCreateIp = "8.8.8.8",
                TotalFee = 1
            });
            result.IsSuccess().ShouldBe(expected: true);
        }
    }
}
