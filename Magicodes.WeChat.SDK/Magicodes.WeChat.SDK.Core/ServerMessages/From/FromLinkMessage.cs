namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    ///     链接消息
    /// </summary>
    public class FromLinkMessage : FromMessageBase
    {
        /// <summary>
        ///     消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     消息描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     消息链接
        /// </summary>
        public string Url { get; set; }
    }
}