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
using Magicodes.WeChat.SDK.Builder;
using System;

namespace Magicodes.WeChat.SDK.Test
{
    [TestClass]
    public class ApiTestBase
    {
        protected string TestOpenId = "";
        protected List<string> TestOpenIdList = new List<string>();

        static ApiTestBase()
        {
            WeChatSDKBuilder.Create()
                //设置日志记录
                .WithLoggerAction((tag, message) =>
                {
                    Console.WriteLine(string.Format("Tag:{0}\tMessage:{1}", tag, message));
                })
                //注册Key。不再需要各个控制注册
                .Register(WeChatFrameworkFuncTypes.GetKey, model =>
                {
                    return "wx9ff101863db7db9c";
                }
                )
                //注册获取配置函数：根据Key获取微信配置（加载一次后续将缓存）
                .Register(WeChatFrameworkFuncTypes.Config_GetWeChatConfigByKey,
                model =>
                {
                    var arg = model as WeChatApiCallbackFuncArgInfo;
                    return new WeChatConfig()
                    {
                        AppId = "wx9ff101863db7db9c",
                        AppSecret = "f97b922e9cf4c1aedb4843f63b7cf6d7"
                        //AppId= "wxaf360c577178e6f5",
                        //AppSecret= "42b16416635613b8ca4dd30faaf21362"
                    };
                })
                .Build();
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