// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : EnterprisePayApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Hosting;
using Magicodes.Logger;

namespace Magicodes.WeChat.SDK.Pays.EnterprisePay
{
    /// <summary>
    ///     企业支付
    /// </summary>
    public class EnterprisePayApi : PayBase
    {
        public EnterpriseResult EnterprisePayment(EnterpriseRequest model)
        {
            //发红包接口地址
            var url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";

            EnterpriseResult result = null;
            try
            {
                var wechatConfig = WeChatConfig;
                model.MchAppId = wechatConfig.AppId;
                model.MchId = PayConfig.MchId;
                //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
                var cert = HostingEnvironment.ApplicationPhysicalPath + PayConfig.PayCertPath;
                //私钥（在安装证书时设置）
                var password = PayConfig.CertPassword;

                //调用证书
                var cer = new X509Certificate2(cert, password,
                    X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);

                var dictionary = PayUtil.GetAuthors(model);
                model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign

                result = PostXML<EnterpriseResult>(url, model, cer);
            }
            catch (Exception ex)
            {
                WeChatHelper.PayLogger.Log(LoggerLevels.Error, ex);
            }
            return result;
        }
    }
}