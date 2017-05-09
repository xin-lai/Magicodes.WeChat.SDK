namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    /// 接受消息类型
    /// </summary>
    public enum FromMessageTypes
    {
        /// <summary>
        /// 文本
        /// </summary>
        text = 0,
        /// <summary>
        /// 图片
        /// </summary>
        image = 1,
        /// <summary>
        /// 语音
        /// </summary>
        voice = 2,
        /// <summary>
        /// 视频
        /// </summary>
        video = 3,
        /// <summary>
        /// 小视频
        /// </summary>
        shortvideo = 4,
        /// <summary>
        /// 位置
        /// </summary>
        location = 5,
        /// <summary>
        /// 链接
        /// </summary>
        link = 6
    }
}