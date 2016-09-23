using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicodes.Logger;
using Magicodes.Storage;

namespace Magicodes.WeChat.SDK
{
    public class Injection
    {
        private static readonly Lazy<Injection> Lazy = new Lazy<Injection>(() => new Injection());
        public static Injection Current => Lazy.Value;

        /// <summary>
        ///     API日志记录器
        /// </summary>
        public LoggerBase ApiLogger { get; set; }

        /// <summary>
        ///     微信支付相关记录器
        /// </summary>
        public LoggerBase PayLogger { get; set; }

        /// <summary>
        ///     存储提供程序
        /// </summary>
        public IStorageProvider StorageProvider { get; set; }
    }
}
