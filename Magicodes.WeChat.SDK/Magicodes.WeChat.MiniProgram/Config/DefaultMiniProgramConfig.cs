namespace Magicodes.WeChat.MiniProgram.Config
{
    /// <inheritdoc />
    public class DefaultMiniProgramConfig : IMiniProgramConfig
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        public string MiniProgramAppId { get; set; }

        /// <summary>
        /// 小程序密钥
        /// </summary>
        public string MiniProgramAppSecret { get; set; }
    }
}
