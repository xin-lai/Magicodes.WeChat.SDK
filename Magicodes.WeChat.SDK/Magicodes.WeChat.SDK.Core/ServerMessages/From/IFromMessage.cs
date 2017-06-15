namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    ///     获取消息
    /// </summary>
    public interface IFromMessage
    {
        string ToUserName { get; set; }
        string FromUserName { get; set; }
    }
}