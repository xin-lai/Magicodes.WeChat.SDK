using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Magicodes.WeChat.MiniProgram.Test.Helper
{
    public class ConfigHelper
    {
        public static TestConfig LoadConfig()
        {
            var miniProgramConfig = new TestConfig();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "app.json");
            if (File.Exists(filePath))
            {
                miniProgramConfig = JsonConvert.DeserializeObject<TestConfig>(File.ReadAllText(filePath));
            }
            else
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(miniProgramConfig));
            }
            return miniProgramConfig;
        }
    }
}
