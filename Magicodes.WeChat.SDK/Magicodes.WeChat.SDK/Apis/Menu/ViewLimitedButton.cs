// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ViewLimitedButton.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Newtonsoft.Json;

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    ///     跳转图文消息URL
    ///     用户点击view_limited类型按钮后，微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
    /// </summary>
    public class ViewLimitedButton : MenuButtonBase
    {
        public ViewLimitedButton()
        {
            Type = MenuButtonTypes.view_limited;
        }

        /// <summary>
        ///     调用新增永久素材接口返回的合法media_id
        /// </summary>
        [JsonProperty(PropertyName = "media_id", Required = Required.Always)]
        public string MediaId { get; set; }
    }
}