// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ApiTestBase.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using Magicodes.Logger.DebugLogger;
using Magicodes.WeChat.SDK.Builder;

namespace Magicodes.WeChat.SDK.Test
{
    [TestClass]
    public class ApiTestBase
    {
        protected string TestOpenId = "";
        protected List<string> TestOpenIdList = new List<string>();

        static ApiTestBase()
        {
            //配置构造器
            WeChatSDKBuilder.Create()
                .WithApiLogger(new DebugLogger("Api"))
                .WithPayLogger(new DebugLogger("Pay"))
                .Build();

            //注册Key。这里用于单元测试，写死。在实际开发中，可以考虑使用Sesstion来存储
            WeChatFrameworkFuncsManager.Current.Register(WeChatFrameworkFuncTypes.GetKey,
                model => "wxa6eecd3e040a2d1e");

            //注册获取配置函数：根据Key获取微信配置（加载一次后续将缓存）
            WeChatFrameworkFuncsManager.Current.Register(WeChatFrameworkFuncTypes.Config_GetWeChatConfigByKey,
                model =>
                {
                    var arg = model as WeChatApiCallbackFuncArgInfo;
                    return new WeChatConfig()
                    {
                        AppId = "wxe753e9de3a7ebfc2",
                        AppSecret = "7cc4b4ef1daf99791d9a4f64b8f94648"
                        //AppId= "wxaf360c577178e6f5",
                        //AppSecret= "42b16416635613b8ca4dd30faaf21362"
                    };
                });
        }

        public static Stream GetInputFile(string filename)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            string path = "Magicodes.WeChat.SDK.Test.Resource";
            return thisAssembly.GetManifestResourceStream(path + "." + filename);
        }

        /// <summary>
        ///     获取或设置测试上下文，该上下文提供
        ///     有关当前测试运行及其功能的信息。
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        ///     在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
        }

        /// <summary>
        ///     在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        /// </summary>
        [ClassCleanup]
        public static void Cleanup()
        {
        }

        /// <summary>
        ///     在运行每个测试之前，使用 TestInitialize 来运行代码
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
        }

        /// <summary>
        ///     在每个测试运行完之后，使用 TestCleanup 来运行代码
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
        }
    }
}