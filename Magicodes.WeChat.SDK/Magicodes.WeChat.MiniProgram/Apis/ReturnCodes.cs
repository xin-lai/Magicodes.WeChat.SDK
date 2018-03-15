// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : ReturnCodes.cs
//          description :
//  
//          created by 李文强 at  2018/03/15 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.MiniProgram.Apis
{
    /// <summary>
    ///     公众号返回码（JSON）
    /// </summary>
    public enum ReturnCodes
    {
        请求成功 = 0,
        授权Code不正确= 40029,
        template_id不正确 = 40037,
        form_id不正确或过期 = 41028,
        form_id已被使用 = 41029,
        page不正确 = 41030,
        接口调用超过限额_目前默认每个帐号日调用限额为100万 = 45009
    }
}