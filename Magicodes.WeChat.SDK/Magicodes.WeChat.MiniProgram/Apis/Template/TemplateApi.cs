using System;
using System.Collections.Generic;
using System.Text;
using Magicodes.WeChat.MiniProgram.Apis.Template.Dto;

namespace Magicodes.WeChat.MiniProgram.Apis.Template
{
    /// <summary>
    /// 模版消息API
    /// </summary>
    public class TemplateApi : ApiBase
    {
        private const string ApiName = "cgi-bin/wxopen/template/library";

        /// <summary>
        /// 获取小程序模板库标题列表
        /// </summary>
        /// <param name="count">offset和count用于分页，表示从offset开始，拉取count条记录，offset从0开始，count最大为20。</param>
        /// <param name="offset">offset和count用于分页，表示从offset开始，拉取count条记录，offset从0开始，count最大为20。</param>
        /// <returns></returns>
        public GetTemplateListOutput GetTemplateList(int offset = 0, int count = 20)
        {
            //获取api请求url
            var url = GetAccessApiUrl("list", ApiName);
            return Post<GetTemplateListOutput>(url, new { offset, count });
        }

        /// <summary>
        /// 获取模板库某个模板标题下关键词库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetTemplateDetailOutput GetTemplateDetail(string id)
        {
            //获取api请求url
            var url = GetAccessApiUrl("get", ApiName);
            return Post<GetTemplateDetailOutput>(url, new
            {
                id
            });
        }

        /// <summary>
        /// 组合模板并添加至帐号下的个人模板库
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keywordIds"></param>
        /// <returns></returns>
        public AddMyTemplateOuput AddMyTemplate(string id, int[] keywordIds)
        {
            //获取api请求url
            var url = GetAccessApiUrl("add", ApiName);
            return Post<AddMyTemplateOuput>(url, new
            {
                id,
                keyword_id_list = keywordIds
            });
        }

        /// <summary>
        /// 获取帐号下已存在的模板列表
        /// </summary>
        /// <param name="count">offset和count用于分页，表示从offset开始，拉取count条记录，offset从0开始，count最大为20。</param>
        /// <param name="offset">offset和count用于分页，表示从offset开始，拉取count条记录，offset从0开始，count最大为20。</param>
        /// <returns></returns>
        public GetMyTemplateListOutput GetMyTemplateList(int offset = 0, int count = 20)
        {
            //获取api请求url
            var url = GetAccessApiUrl("list", ApiName);
            return Post<GetMyTemplateListOutput>(url, new { offset, count });
        }

        //TODO:删除

        //TODO：发送
    }
}
