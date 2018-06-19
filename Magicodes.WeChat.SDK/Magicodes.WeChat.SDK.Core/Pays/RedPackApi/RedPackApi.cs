// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : RedPackApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

namespace Magicodes.WeChat.SDK.Pays.RedPackApi
{
    using System;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// 红包发送和查询Api（暂缺裂变红包发送）
    /// </summary>
    public class RedPackApi : PayBase
    {
        /// <summary>
        /// 普通红包发送
        /// </summary>
        /// <param name="model">The model<see cref="NormalRedPackRequest"/></param>
        /// <returns>The <see cref="NormalRedPackResult"/></returns>
        public NormalRedPackResult SendNormalRedPack(NormalRedPackRequest model)
        {
            //发红包接口地址
            var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";

            NormalRedPackResult result = null;

            try
            {
                model.WxAppId = WeChatConfig.AppId;
                model.MchId = PayConfig.MchId;
                //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
                var cert = PayConfig.PayCertPath;
                //私钥（在安装证书时设置）
                var password = PayConfig.CertPassword;

                //调用证书
                var cer = new X509Certificate2(cert, password,
                    X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                //X509Certificate cer = new X509Certificate(cert, password);

                var dictionary = PayUtil.GetAuthors(model);
                model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign
                //var dict = PayUtil.GetAuthors(model);

                result = PostXML<NormalRedPackResult>(url, model, cer);
            }
            catch (Exception ex)
            {
                WeChatHelper.LoggerAction?.Invoke(nameof(RedPackApi), ex.ToString());
            }
            return result;
        }
    }
}
