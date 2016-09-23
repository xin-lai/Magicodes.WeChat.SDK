// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : MenuButtonTypes.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.Menu
{
    /// <summary>
    ///     菜单类型
    /// </summary>
    public enum MenuButtonTypes
    {
        /// <summary>
        ///     点击推事件
        /// </summary>
        click = 1,

        /// <summary>
        ///     跳转URL
        /// </summary>
        view = 2,

        /// <summary>
        ///     扫码推事件
        /// </summary>
        scancode_push = 3,

        /// <summary>
        ///     扫码推事件且弹出“消息接收中”提示框
        /// </summary>
        scancode_waitmsg = 4,

        /// <summary>
        ///     弹出系统拍照发图
        /// </summary>
        pic_sysphoto = 5,

        /// <summary>
        ///     弹出拍照或者相册发图
        /// </summary>
        pic_photo_or_album = 6,

        /// <summary>
        ///     弹出微信相册发图器
        /// </summary>
        pic_weixin = 7,

        /// <summary>
        ///     弹出地理位置选择器
        /// </summary>
        location_select = 8,

        /// <summary>
        ///     下发消息（除文本消息）
        /// </summary>
        media_id = 9,

        /// <summary>
        ///     跳转图文消息URL
        /// </summary>
        view_limited = 10
    }
}