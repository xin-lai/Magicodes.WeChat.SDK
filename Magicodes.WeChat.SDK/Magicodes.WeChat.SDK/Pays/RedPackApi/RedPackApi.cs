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

using System;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Magicodes.Logger;
using System.Web.Hosting;

namespace Magicodes.WeChat.SDK.Pays.RedPackApi
{
    /// <summary>
    ///     红包发送和查询Api（暂缺裂变红包发送）
    /// </summary>
    public class RedPackApi : PayBase
    {
        /// <summary>
        ///     普通红包发送
        /// </summary>
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
                var cert = HostingEnvironment.ApplicationPhysicalPath + PayConfig.PayCertPath;
                //私钥（在安装证书时设置）
                var password = PayConfig.CertPassword;

                //调用证书
                var cer = new X509Certificate2(cert, password,
                    X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                //X509Certificate cer = new X509Certificate(cert, password);

                var dictionary = PayUtil.GetAuthors(model);
                model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign
                var dict = PayUtil.GetAuthors(model);

                result = PostXML<NormalRedPackResult>(url, dict, cer);
            }
            catch (Exception ex)
            {
                Logger.Log(LoggerLevels.Error, ex.Message, ex);
            }
            return result;
        }

        ///// <summary>
        ///// 查询红包(包括普通红包和裂变红包)
        ///// </summary>
        ///// <param name="appId">公众账号AppID</param>
        ///// <param name="mchId">商户MchID</param>
        ///// <param name="tenPayKey">支付密钥，微信商户平台(pay.weixin.qq.com)-->账户设置-->API安全-->密钥设置</param>
        ///// <param name="tenPayCertPath">证书地址（硬盘地址，形如E://cert//apiclient_cert.p12）</param>
        ///// <param name="MchBillNo">商家订单号</param>
        ///// <returns></returns>
        //public static SearchRedPackResult SearchRedPack(string appId, string mchId, string tenPayKey, string tenPayCertPath, string mchBillNo)
        //{
        //    string nonceStr = TenPayV3Util.GetNoncestr();
        //    RequestHandler packageReqHandler = new RequestHandler();

        //    packageReqHandler.SetParameter("nonce_str", nonceStr);              //随机字符串
        //    packageReqHandler.SetParameter("appid", appId);		  //公众账号ID
        //    packageReqHandler.SetParameter("mch_id", mchId);		  //商户号
        //    packageReqHandler.SetParameter("mch_billno", mchBillNo);                 //填入商家订单号
        //    packageReqHandler.SetParameter("bill_type", "MCHT");                 //MCHT:通过商户订单号获取红包信息。 
        //    string sign = packageReqHandler.CreateMd5Sign("key", tenPayKey);
        //    packageReqHandler.SetParameter("sign", sign);	                    //签名
        //    //发红包需要post的数据
        //    string data = packageReqHandler.ParseXML();

        //    //发红包接口地址
        //    string url = "https://api.mch.weixin.qq.com/mmpaymkttransfers/gethbinfo";
        //    //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
        //    string cert = tenPayCertPath;
        //    //私钥（在安装证书时设置）
        //    string password = mchId;

        //    //调用证书
        //    //X509Certificate2 cer = new X509Certificate2(cert, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
        //    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        //    X509Certificate cer = new X509Certificate(cert, password);

        //    #region 发起post请求
        //    HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
        //    webrequest.ClientCertificates.Add(cer);
        //    webrequest.Method = "post";

        //    byte[] postdatabyte = Encoding.UTF8.GetBytes(data);
        //    webrequest.ContentLength = postdatabyte.Length;
        //    Stream stream;
        //    stream = webrequest.GetRequestStream();
        //    stream.Write(postdatabyte, 0, postdatabyte.Length);
        //    stream.Close();

        //    HttpWebResponse httpWebResponse = (HttpWebResponse)webrequest.GetResponse();
        //    StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
        //    string responseContent = streamReader.ReadToEnd();
        //    #endregion

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(responseContent);

        //    SearchRedPackResult searchReturn = new SearchRedPackResult
        //    {
        //        err_code = "",
        //        err_code_des = ""
        //    };
        //    if (doc.SelectSingleNode("/xml/return_code") != null)
        //    {
        //        searchReturn.return_code = (doc.SelectSingleNode("/xml/return_code").InnerText.ToUpper() == "SUCCESS");
        //    }
        //    if (doc.SelectSingleNode("/xml/return_msg") != null)
        //    {
        //        searchReturn.return_msg = doc.SelectSingleNode("/xml/return_msg").InnerText;
        //    }

        //    if (searchReturn.return_code == true)
        //    {
        //        //redReturn.sign = doc.SelectSingleNode("/xml/sign").InnerText;
        //        if (doc.SelectSingleNode("/xml/result_code") != null)
        //        {
        //            searchReturn.result_code = (doc.SelectSingleNode("/xml/result_code").InnerText.ToUpper() == "SUCCESS");
        //        }

        //        if (searchReturn.result_code == true)
        //        {
        //            if (doc.SelectSingleNode("/xml/mch_billno") != null)
        //            {
        //                searchReturn.mch_billno = doc.SelectSingleNode("/xml/mch_billno").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/mch_id") != null)
        //            {
        //                searchReturn.mch_id = doc.SelectSingleNode("/xml/mch_id").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/detail_id") != null)
        //            {
        //                searchReturn.detail_id = doc.SelectSingleNode("/xml/detail_id").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/status") != null)
        //            {
        //                searchReturn.status = doc.SelectSingleNode("/xml/status").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/send_type") != null)
        //            {
        //                searchReturn.send_type = doc.SelectSingleNode("/xml/send_type").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/hb_type") != null)
        //            {
        //                searchReturn.hb_type = doc.SelectSingleNode("/xml/hb_type").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/total_num") != null)
        //            {
        //                searchReturn.total_num = doc.SelectSingleNode("/xml/total_num").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/total_amount") != null)
        //            {
        //                searchReturn.total_amount = doc.SelectSingleNode("/xml/total_amount").InnerText;
        //            }

        //            if (doc.SelectSingleNode("/xml/reason") != null)
        //            {
        //                searchReturn.reason = doc.SelectSingleNode("/xml/reason").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/send_time") != null)
        //            {
        //                searchReturn.send_time = doc.SelectSingleNode("/xml/send_time").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/refund_time") != null)
        //            {
        //                searchReturn.refund_time = doc.SelectSingleNode("/xml/refund_time").InnerText;
        //            }

        //            if (doc.SelectSingleNode("/xml/wishing") != null)
        //            {
        //                searchReturn.wishing = doc.SelectSingleNode("/xml/wishing").InnerText;
        //            }

        //            if (doc.SelectSingleNode("/xml/act_name") != null)
        //            {
        //                searchReturn.act_name = doc.SelectSingleNode("/xml/act_name").InnerText;
        //            }

        //            if (doc.SelectSingleNode("/xml/hblist") != null)
        //            {
        //                searchReturn.hblist = new List<RedPackHBInfo>();

        //                foreach (XmlNode hbinfo in doc.SelectNodes("/xml/hblist/hbinfo"))
        //                {
        //                    RedPackHBInfo wechatHBInfo = new RedPackHBInfo();
        //                    wechatHBInfo.openid = hbinfo.SelectSingleNode("openid").InnerText;
        //                    wechatHBInfo.status = hbinfo.SelectSingleNode("status").InnerText;
        //                    wechatHBInfo.amount = hbinfo.SelectSingleNode("amount").InnerText;
        //                    wechatHBInfo.rcv_time = hbinfo.SelectSingleNode("rcv_time").InnerText;

        //                    searchReturn.hblist.Add(wechatHBInfo);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (doc.SelectSingleNode("/xml/err_code") != null)
        //            {
        //                searchReturn.err_code = doc.SelectSingleNode("/xml/err_code").InnerText;
        //            }
        //            if (doc.SelectSingleNode("/xml/err_code_des") != null)
        //            {
        //                searchReturn.err_code_des = doc.SelectSingleNode("/xml/err_code_des").InnerText;
        //            }
        //        }
        //    }

        //    return searchReturn;
        //}


        //private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        //{
        //    if (errors == SslPolicyErrors.None)
        //        return true;
        //    return false;
        //}
    }
}