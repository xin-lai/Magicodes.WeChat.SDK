using System;
using Magicodes.WeChat.SDK.Builder;

namespace Magicodes.WeChat.MiniProgram.Test
{
    public class TestBase
    {
        static TestBase() => MiniProgramSDKBuilder.Create()
                //设置日志记录
                .WithLoggerAction((tag, message) =>
                {
                    Console.WriteLine(string.Format("Tag:{0}\tMessage:{1}", tag, message));
                }).RegisterGetKeyFunc(() =>
                {
                    //推荐使用APPID作为Key
                    return "1";
                }).RegisterGetConfigByKeyFunc((key) =>
                {
                    //如果是一个项目多个配置,请使用key来获取相关配置
                    return new MiniProgramConfig(){
                        AppId = "wx0512042fa43a459d",
                        AppSecret = "65a6adccfd14adf95a49504ce94fa510"
                    };
                }).Build();
    }
}
