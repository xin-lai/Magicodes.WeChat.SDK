// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : TemplateMessageApi.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Magicodes.WeChat.SDK.Apis.TemplateMessage
{
    /// <summary>
    ///     模板消息
    /// </summary>
    public class TemplateMessageApi : ApiBase
    {
        private const string APIName = "message/template";

        /// <summary>
        ///     根据模板库中模板的编号将该模板添加到自己的模板库
        /// </summary>
        /// <param name="shortId">模板库中模板的编号，有“TM**”和“OPENTMTM**”等形式</param>
        /// <returns></returns>
        public TemplateMessageAddTemplateAPIResult AddTemplate(string shortId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("api_add_template", "template");
            var model = new {template_id_short = shortId};
            return Post<TemplateMessageAddTemplateAPIResult>(url, model);
        }

        /// <summary>
        ///     获取帐号下所有模板信息
        /// </summary>
        /// <returns></returns>
        public TemplateMessageGetAPIResult Get()
        {
            //获取api请求url
            var url = GetAccessApiUrl("get_all_private_template", "template");
            return Get<TemplateMessageGetAPIResult>(url);
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="templatId"></param>
        /// <returns></returns>
        public ApiResult Delete(string templatId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("del_private_template", "template");
            var model = new {template_id = templatId};
            return Post<ApiResult>(url, model);
        }

        /// <summary>
        ///     创建模板消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Guid Create(TemplateMessageCreateModel model)
        {
            var batchNumber = Guid.NewGuid();
            //获取api请求url
            var url = GetAccessApiUrl("send", APIName);

            #region JSON示例

            //{
            //    "touser":"OPENID",
            //    "template_id":"ngqIpbwh8bUfcSsECmogfXcV14J0tQlEpBO27izEYtY",
            //    "url":"http://weixin.qq.com/download",            
            //    "data":{
            //            "first": {
            //                "value":"恭喜你购买成功！",
            //                "color":"#173177"
            //            },
            //            "keynote1":{
            //                "value":"巧克力",
            //                "color":"#173177"
            //            },
            //            "keynote2": {
            //                "value":"39.8元",
            //                "color":"#173177"
            //            },
            //            "keynote3": {
            //                "value":"2014年9月22日",
            //                "color":"#173177"
            //            },
            //            "remark":{
            //                "value":"欢迎再次购买！",
            //                "color":"#173177"
            //            }
            //    }
            //} 

            #endregion

            var dataTpl = @"{{
               ""touser"":""{0}"",
               ""template_id"":""{1}"",
               ""url"":""{2}"",            
               ""data"":{3}
            }}";
            var dataSb = new StringBuilder();
            dataSb.Append("{");
            var i = 0;
            foreach (var item in model.Data)
            {
                dataSb.AppendFormat(@"""{0}"":{{""value"":""{1}"",""color"":""{2}""}}", item.Key, item.Value.Value,
                    item.Value.Color);
                if (i != model.Data.Count - 1)
                    dataSb.Append(",");
                i++;
            }
            dataSb.Append("}");
            var dataStr = dataSb.ToString();
            var list = new List<MessagesTemplateLogFuncModel>();
            var receiverIds = model.ReceiverIds.Split(';');
            foreach (var receiverId in receiverIds)
            {
                var data = string.Format(dataTpl, receiverId, model.MessagesTemplateNo, model.Url, dataStr);
                var log = new MessagesTemplateLogFuncModel
                {
                    CreateTime = DateTime.Now,
                    BatchNumber = batchNumber,
                    Content = data,
                    MessagesTemplateNo = model.MessagesTemplateNo,
                    ReceiverId = receiverId,
                    TopColor = model.TopColor,
                    Url = model.Url
                };
                var obj = Post<TemplateApiResult>(url, data);
                log.Result = obj.DetailResult;
                log.IsSuccess = obj.IsSuccess();
                list.Add(log);
            }

            WeChatFrameworkFuncsManager.Current.InvokeFunc(
                WeChatFrameworkFuncTypes.APIFunc_TemplateMessageApi_Create, new WeChatApiCallbackFuncArgInfo
                {
                    Api = this,
                    Data = list
                });
            return batchNumber;
        }
    }
}