// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : PicPhotoOrAlbumButton.cs
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
    ///     弹出拍照或者相册发图
    ///     用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。
    /// </summary>
    public class PicPhotoOrAlbumButton : MenuButtonBase
    {
        public PicPhotoOrAlbumButton()
        {
            Type = MenuButtonTypes.pic_photo_or_album;
        }

        /// <summary>
        ///     菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        [JsonProperty(PropertyName = "key", Required = Required.Always)]
        public string Key { get; set; }
    }
}