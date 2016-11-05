// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TenPayV3.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Magicodes.WeChat.SDK.Helper;
using Magicodes.WeChat.SDK.Pays.Refund;
using System.Web.Hosting;
using System.Security.Cryptography.X509Certificates;
using Magicodes.Logger;
using Magicodes.WeChat.SDK.Pays.MicroPay;
using Magicodes.WeChat.SDK.Pays.OrderQuery;

namespace Magicodes.WeChat.SDK.Pays.TenPayV3
{
    /// <summary>
    ///     微信支付接口，官方API：https://mp.weixin.qq.com/paymch/readtemplate?t=mp/business/course2_tmpl&lang=zh_CN&token=25857919#4
    /// </summary>
    public class TenPayV3 : PayBase
    {
        public UnifiedorderResult Unifiedorder(UnifiedorderRequest model)
        {
            var url = "https://api.mch.weixin.qq.com/pay/unifiedorder";
            UnifiedorderResult result = null;

            model.AppId = WeChatConfig.AppId;
            model.MchId = PayConfig.MchId;
            model.NonceStr = PayUtil.GetNoncestr();
            if (model.NotifyUrl == null)
                model.NotifyUrl = PayConfig.Notify;
            var dictionary = PayUtil.GetAuthors(model);
            model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign
            result = PostXML<UnifiedorderResult>(url, model);
            return result;
        }

        /// <summary>
        ///     Native
        /// </summary>
        /// <param name="appId">开放平台账户的唯一标识</param>
        /// <param name="timesTamp">时间戳</param>
        /// <param name="mchId">商户Id</param>
        /// <param name="nonceStr">32 位内的随机串，防重发</param>
        /// <param name="productId">商品唯一id</param>
        /// <param name="sign">签名</param>
        public static string NativePay(string appId, string timesTamp, string mchId, string nonceStr, string productId,
            string sign)
        {
            var urlFormat =
                "weixin://wxpay/bizpayurl?sign={0}&appid={1}&mch_id={2}&product_id={3}&time_stamp={4}&nonce_str={5}";
            return string.Format(urlFormat, sign, appId, mchId, productId, timesTamp, nonceStr);
        }

        /// <summary>
        ///     订单查询接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string OrderQuery(string data)
        {
            var urlFormat = "https://api.mch.weixin.qq.com/pay/orderquery";

            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            using (var ms = new MemoryStream())
            {
                ms.Write(formDataBytes, 0, formDataBytes.Length);
                ms.Seek(0, SeekOrigin.Begin); //设置指针读取位置
                return RequestUtility.HttpPost(urlFormat, null, ms);
            }
        }

        /// <summary>
        ///     订单查询接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public  QueryResult OrderQuery(QueryRequest model)
        {
            var url = "https://api.mch.weixin.qq.com/pay/orderquery";
            QueryResult result = null;

            model.Appid = WeChatConfig.AppId;
            model.Mch_id = PayConfig.MchId;
            model.Nonce_str = PayUtil.GetNoncestr();
            var dictionary = PayUtil.GetAuthors(model);
            model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign
            result = PostXML<QueryResult>(url, model);
            return result;
        }

        /// <summary>
        ///     关闭订单接口
        /// </summary>
        /// <param name="data">关闭订单需要post的xml数据</param>
        /// <returns></returns>
        public static string CloseOrder(string data)
        {
            var urlFormat = "https://api.mch.weixin.qq.com/pay/closeorder";

            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            using (var ms = new MemoryStream())
            {
                ms.Write(formDataBytes, 0, formDataBytes.Length);
                ms.Seek(0, SeekOrigin.Begin); //设置指针读取位置
                return RequestUtility.HttpPost(urlFormat, null, ms);
            }
        }

        //退款申请请直接参考Senparc.Weixin.MP.Sample中的退款demo
        ///// <summary>
        ///// 退款申请接口
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public static string Refund(string data)
        //{
        //    var urlFormat = "https://api.mch.weixin.qq.com/secapi/pay/refund";

        //    var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
        //    MemoryStream ms = new MemoryStream();
        //    ms.Write(formDataBytes, 0, formDataBytes.Length);
        //    ms.Seek(0, SeekOrigin.Begin);//设置指针读取位置
        //    return Senparc.Weixin.HttpUtility.RequestUtility.HttpPost(urlFormat, null, ms);
        //}

        /// <summary>
        ///     退款查询接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RefundQuery(string data)
        {
            var urlFormat = "https://api.mch.weixin.qq.com/pay/refundquery";

            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            using (var ms = new MemoryStream())
            {
                ms.Write(formDataBytes, 0, formDataBytes.Length);
                ms.Seek(0, SeekOrigin.Begin); //设置指针读取位置
                return RequestUtility.HttpPost(urlFormat, null, ms);
            }
        }

        /// <summary>
        ///     对账单接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string DownloadBill(string data)
        {
            var urlFormat = "https://api.mch.weixin.qq.com/pay/downloadbill";

            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            using (var ms = new MemoryStream())
            {
                ms.Write(formDataBytes, 0, formDataBytes.Length);
                ms.Seek(0, SeekOrigin.Begin); //设置指针读取位置
                return RequestUtility.HttpPost(urlFormat, null, ms);
            }
        }

        /// <summary>
        ///     短链接转换接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ShortUrl(string data)
        {
            var urlFormat = "https://api.mch.weixin.qq.com/tools/shorturl";

            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            using (var ms = new MemoryStream())
            {
                ms.Write(formDataBytes, 0, formDataBytes.Length);
                ms.Seek(0, SeekOrigin.Begin); //设置指针读取位置
                return RequestUtility.HttpPost(urlFormat, null, ms);
            }
        }

        /// <summary>
        ///     刷卡支付
        ///     提交被扫支付
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string MicroPay(string data)
        {
            var urlFormat = "https://api.mch.weixin.qq.com/pay/micropay";

            var formDataBytes = data == null ? new byte[0] : Encoding.UTF8.GetBytes(data);
            var ms = new MemoryStream();
            ms.Write(formDataBytes, 0, formDataBytes.Length);
            ms.Seek(0, SeekOrigin.Begin); //设置指针读取位置
            return RequestUtility.HttpPost(urlFormat, null, ms);
        }

        /// <summary>
        ///     刷卡支付
        ///     提交被扫支付
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public MicropayResult MicroPay(MicropayRequest model)
        {
            var url = "https://api.mch.weixin.qq.com/pay/micropay";

            MicropayResult result = null;
            model.Appid = WeChatConfig.AppId;
            model.Mch_id = PayConfig.MchId;
            model.Nonce_str = PayUtil.GetNoncestr();
            var dictionary = PayUtil.GetAuthors(model);
            model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign
            result = PostXML<MicropayResult>(url, model);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="page"></param>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public NotifyResult Notify(Stream inputStream)
        {
            NotifyResult result = null;
            var data = PayUtil.PostInput(inputStream);
            result = XmlHelper.DeserializeObject<NotifyResult>(data);
            return result;
        }

        /// <summary>
        ///     通知并返回处理XML
        /// </summary>
        /// <param name="inputStream">输入流</param>
        /// <param name="successAction">成功处理逻辑回调函数</param>
        /// <param name="failAction">失败处理逻辑回调函数</param>
        /// <param name="successMsg">成功返回消息</param>
        /// <param name="errorMsg">失败返回消息</param>
        /// <param name="isSync">是否异步执行相关处理逻辑</param>
        /// <returns></returns>
        public string NotifyAndReurnResult(Stream inputStream, Action<NotifyResult> successAction,
            Action<NotifyResult> failAction, string successMsg = "OK", string errorMsg = "FAIL", bool isSync = true)
        {
            var result = Notify(inputStream);
            var request = new NotifyRequest();
            request.ReturnCode = "FAIL";
            if (result.IsSuccess())
            {
                if (isSync)
                    Task.Run(() => successAction(result));
                else
                    successAction.Invoke(result);
                //交易成功
                request.ReturnCode = "SUCCESS";
                request.ReturnMsg = successMsg;
                return XmlHelper.SerializeObject(request);
            }
            if (isSync)
                Task.Run(() => failAction(result));
            else
                failAction.Invoke(result);
            request.ReturnMsg = errorMsg;
            return XmlHelper.SerializeObject(request);
        }

        /// <summary>
        /// 退款申请接口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public RefundResult Refund(RefundRequest model)
        {
            var url = "https://api.mch.weixin.qq.com/secapi/pay/refund";

            RefundResult result = null;
            try
            {
                var wechatConfig = WeChatConfig;
                model.AppId = wechatConfig.AppId;
                model.Mch_Id = PayConfig.MchId;
                model.NonceStr = PayUtil.GetNoncestr();
                model.Op_user_id = PayConfig.MchId;

                //本地或者服务器的证书位置（证书在微信支付申请成功发来的通知邮件中）
                var cert = HostingEnvironment.ApplicationPhysicalPath + PayConfig.PayCertPath;
                //私钥（在安装证书时设置）
                var password = PayConfig.CertPassword;

                //调用证书
                var cer = new X509Certificate2(cert, password,
                    X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);

                var dictionary = PayUtil.GetAuthors(model);
                WeChatHelper.PayLogger.Log(LoggerLevels.Error, model.Total_fee);
                model.Sign = PayUtil.CreateMd5Sign(dictionary, PayConfig.TenPayKey); //生成Sign
                result = PostXML<RefundResult>(url, model, cer);
            }
            catch (Exception ex)
            {
                WeChatHelper.PayLogger.Log(LoggerLevels.Error, ex);
            }
            return result;
        }

    }
}