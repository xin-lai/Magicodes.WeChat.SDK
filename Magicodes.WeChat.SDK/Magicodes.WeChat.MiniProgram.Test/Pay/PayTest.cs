using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Magicodes.Pay.WeChat;
using Magicodes.Pay.WeChat.Pay.Dto;

namespace Magicodes.WeChat.MiniProgram.Test.Pay
{
    public class PayTest : TestBase
    {
        [Fact]
        public void Pay_Test()
        {
            var result = new WeChatPayApi().MiniProgramPay(new MiniProgramPayInput()
            {
                Body = "Test",
                OpenId = "oBVdJ5Os4Wkdard-6DmT5BcGWhEg",
                SpbillCreateIp = "8.8.8.8",
                TotalFee = 1
            });
            result.ShouldNotBeNull();
            //result.IsSuccess().ShouldBe(expected: true);
        }
    }
}
