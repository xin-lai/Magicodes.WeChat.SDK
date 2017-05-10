namespace Magicodes.WeChat.SDK.Core.ServerMessages.From
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum FromEventTypes
    {
        /// <summary>
        /// 关注
        /// </summary>
        subscribe = 0,
        /// <summary>
        /// 取消关注
        /// </summary>
        unsubscribe = 1,
        /// <summary>
        /// 扫描带参数二维码
        /// </summary>
        scan = 2,
        /// <summary>
        /// 上报地理位置
        /// </summary>
        location = 3,
        /// <summary>
        /// 点击菜单拉取消息时的事件推送
        /// </summary>
        click = 4,
        /// <summary>
        /// 点击菜单跳转链接时的事件推送
        /// </summary>
        view = 5
    }
}