// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : SersummaryUserSourceType.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Apis.Statistics
{
    /// <summary>
    ///     用户新增数的用户渠道
    /// </summary>
    public enum SersummaryUserSourceType
    {
        其他合计 = 0,
        公众号搜索 = 1,
        名片分享 = 17,
        扫描二维码 = 30,
        图文页右上角菜单 = 43,
        支付后关注 = 51,
        图文页内公众号名称 = 57,
        公众号文章广告 = 75,
        朋友圈广告 = 78
    }
}