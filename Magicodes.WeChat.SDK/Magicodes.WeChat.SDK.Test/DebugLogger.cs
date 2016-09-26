using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.Logger;

namespace Magicodes.WeChat.SDK.Test
{
    public class DebugLogger : LoggerBase
    {
        public DebugLogger(string name) : base(name)
        {
        }

        public override void Log(LoggerLevels loggerLevels, object message)
        {
            Debug.WriteLine("Name:{2};Level:{0};Msg:{1};Ex:{2}", loggerLevels, message, Name);
        }

        public override void Log(LoggerLevels loggerLevels, object message, Exception exception)
        {
            Debug.WriteLine("Name:{3};Level:{0};Msg:{1};Ex:{2}", loggerLevels, message, exception, Name);
        }

        public override void LogFormat(LoggerLevels loggerLevels, string format, params object[] args)
        {
            Debug.WriteLine("Name:{2};Level:{0};Msg:{1}", loggerLevels, string.Format(format, args), Name);
        }

        public override void LogFormat(LoggerLevels loggerLevels, string format, Exception exception, params object[] args)
        {
            Debug.WriteLine("Name:{3};Level:{0};Msg:{1};Ex:{2}", loggerLevels, string.Format(format, args), exception, Name);
        }

        public override void LogFormat(LoggerLevels loggerLevels, IFormatProvider formatProvider, string format, params object[] args)
        {
            var msg = string.Format(formatProvider, format, args);
            Debug.WriteLine("Name:{2};Level:{0};Msg:{1}", loggerLevels, msg, Name);
        }

        public override void LogFormat(LoggerLevels loggerLevels, IFormatProvider formatProvider, string format, Exception exception,
            params object[] args)
        {
            var msg = string.Format(formatProvider, format, args);
            Debug.WriteLine("Name:{3};Level:{0};Msg:{1};Ex:{2}", loggerLevels, msg, exception, Name);
        }
    }
}
