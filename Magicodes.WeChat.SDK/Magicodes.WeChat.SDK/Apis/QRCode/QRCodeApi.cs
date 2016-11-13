// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : QRCodeApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System.Web;

namespace Magicodes.WeChat.SDK.Apis.QRCode
{
    /// <summary>
    ///     二维码
    ///     1、临时二维码，是有过期时间的，最长可以设置为在二维码生成后的7天（即604800秒）后过期，但能够生成较多数量。临时二维码主要用于帐号绑定等不要求二维码永久保存的业务场景
    ///     2、永久二维码，是无过期时间的，但数量较少（目前为最多10万个）。永久二维码主要用于适用于帐号绑定、用户来源统计等场景。
    /// </summary>
    public class QRCodeApi : ApiBase
    {
        private const string ApiName = "qrcode";

        /// <summary>
        ///     获取二维码路径
        /// </summary>
        /// <param name="ticket">二维码ticket</param>
        /// <returns>二维码图片地址</returns>
        public string GetQrCodeUrl(string ticket)
        {
            return string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}",
                HttpUtility.UrlEncode(ticket));
        }

        /// <summary>
        ///     创建数值二维码
        ///     1、临时二维码，是有过期时间的，最长可以设置为在二维码生成后的30天（即2592000秒）后过期，但能够生成较多数量。临时二维码主要用于帐号绑定等不要求二维码永久保存的业务场景
        ///     2、永久二维码，是无过期时间的，但数量较少（目前为最多10万个）。永久二维码主要用于适用于帐号绑定、用户来源统计等场景。
        /// </summary>
        /// <param name="value">值（0~2592000）</param>
        /// <param name="expireSeconds">过期时间，默认为30天（为0表示永久）</param>
        /// <returns></returns>
        public QRCodeCreateApiResult CreateByNumberValue(int value, int expireSeconds = 2592000)
        {
            if ((value > 100000) || (value < 1))
                throw new ApiArgumentException("值只支持1~100000", "value");
            if (expireSeconds > 2592000)
                throw new ApiArgumentException("过期时间不得大于2592000秒（即30天）", "expireSeconds");
            //获取api请求url
            var url = GetAccessApiUrl("create", ApiName);
            QRCodeCreateApiResult result = null;
            if (expireSeconds <= 0)
            {
                var model = new
                {
                    action_name = "QR_LIMIT_SCENE",
                    action_info = new
                    {
                        scene = new {scene_id = value}
                    }
                };
                result = Post<QRCodeCreateApiResult>(url, model);
            }
            else
            {
                var model = new
                {
                    expire_seconds = expireSeconds,
                    action_name = "QR_SCENE",
                    action_info = new
                    {
                        scene = new {scene_id = value}
                    }
                };
                result = Post<QRCodeCreateApiResult>(url, model);
            }
            return result;
        }

        /// <summary>
        ///     创建字符串二维码
        ///     永久二维码，是无过期时间的，但数量较少（目前为最多10万个）。永久二维码主要用于适用于帐号绑定、用户来源统计等场景。
        /// </summary>
        /// <param name="value">值（长度为1~64）</param>
        /// <returns></returns>
        public QRCodeCreateApiResult CreateByStringValue(string value)
        {
            if ((value.Length > 64) || (value.Length < 1))
                throw new ApiArgumentException("值长度只支持1~64", "value");
            //获取api请求url
            var url = GetAccessApiUrl("create", ApiName);
            QRCodeCreateApiResult result = null;
            var model = new
            {
                action_name = "QR_LIMIT_STR_SCENE",
                action_info = new
                {
                    scene = new {scene_str = value}
                }
            };
            return Post<QRCodeCreateApiResult>(url, model);
        }
    }
}