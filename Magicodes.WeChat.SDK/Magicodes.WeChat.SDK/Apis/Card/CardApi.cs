// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CardApi.cs
//          description :
//  
//          created by 李文强 at  2016/10/13 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub：https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.Card.Request;
using Magicodes.WeChat.SDK.Apis.Card.Result;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Magicodes.WeChat.SDK.Apis.Card
{
    /// <summary>
    ///     卡券接口
    /// </summary>
    public class CardApi : ApiBase
    {
        private const string ApiName = "card";

        #region 优惠券

        #region 添加优惠券

        /// <summary>
        ///     添加优惠券
        /// </summary>
        /// <param name="cardInfo">卡券结构数据</param>
        /// <returns></returns>
        public ApiResult Add(CardInfo cardInfo)
        {
            //获取api请求url
            var url = GetAccessApiUrl("create", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card = cardInfo
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }

        /// <summary>
        ///     添加优惠券
        /// </summary>
        /// <param name="cardInfoJson">卡券JSON结构字符串</param>
        /// <returns></returns>
        public ApiResult AddByJson(string cardInfoJson)
        {
            return Add(GetCardInfoByJson(cardInfoJson));
        }

        #endregion

        #region 根据卡券JSON结构字符串获取优惠券信息
        /// <summary>
        ///     根据卡券JSON结构字符串获取优惠券信息
        /// </summary>
        /// <returns></returns>
        public CardInfo GetCardInfoByJson(string cardInfoJson)
        {
            return JsonConvert.DeserializeObject<CardInfo>(cardInfoJson, new CardInfoCustomConverter(), new DateInfoCustomConverter());
        }
        #endregion

        #endregion

        #region 上传图片
        /// <summary>
        ///     上传卡券图片
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="fileStream">文件流</param>
        /// <returns></returns>
        public UploadImageApiResult UploadImage(string fileName, Stream fileStream)
        {
            //获取api请求url
            var url = GetAccessApiUrl("uploadimg", "media");
            return Post<UploadImageApiResult>(url, fileName, fileStream);
        }
        #endregion

        #region 会员卡

        #region 根据卡券JSON结构字符串获取会员卡信息
        /// <summary>
        ///     根据卡券JSON结构字符串获取会员卡信息
        /// </summary>
        /// <returns></returns>
        public MemberCard GetMemberCardByJson(string cardInfoJson)
        {
            return JsonConvert.DeserializeObject<MemberCard>(cardInfoJson, new MemberCardCustomConverter(), new DateInfoCustomConverter());
        }
        #endregion 

        #region 添加会员卡
        /// <summary>
        ///     添加会员卡
        /// </summary>
        /// <param name="cardInfo">卡券结构数据</param>
        /// <returns></returns>
        public ApiResult AddMemberCard(MemberCardInfo cardInfo)
        {
            //获取api请求url
            var url = GetAccessApiUrl("create", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card = cardInfo
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }

        /// <summary>
        ///     添加会员卡
        /// </summary>
        /// <param name="cardInfoJson">卡券JSON结构字符串</param>
        /// <returns></returns>
        public ApiResult AddMemberCardByJson(string cardInfoJson)
        {
            return Add(GetCardInfoByJson(cardInfoJson));
        }
        #endregion

        #region 激活会员卡
        /// <summary>
        /// 接口激活会员卡
        /// 激活方式说明
        /// 接口激活通常需要开发者开发用户填写资料的网页。通常有两种激活流程：
        /// 1. 用户必须在填写资料后才能领卡，领卡后开发者调用激活接口为用户激活会员卡；
        /// 2. 是用户可以先领取会员卡，点击激活会员卡跳转至开发者设置的资料填写页面，填写完成后开发者调用激活接口为用户激活会员卡。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApiResult AcitveMember(ActivateMemberCardRequest model)
        {
            //获取api请求url
            var url = GetAccessApiUrl("activate", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }

        /// <summary>
        /// 普通一键激活会员卡
        /// 步骤一：在创建接口填入wx_activate字段
        /// 步骤二：设置开卡字段接口
        /// 步骤三：接收会员信息事件通知
        /// 步骤四：同步会员数据
        /// 步骤五：拉取会员信息接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApiResult ActivateMemberUserform(ActivateMemberCardRequest model)
        {
            //获取api请求url
            var url = GetAccessApiUrl("activateuserform", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }

        /// <summary>
        /// 跳转型一键激活支持用户在提交会员开卡资料后跳转至商户自定义的网页。
        /// 不同于普通一键激活，跳转型一键激活的激活会员卡动作由商户完成，商户可以在跳转到的网页内做激活、激活奖励、开卡条件判断等逻辑，同时也保证了开卡的实时性，适合使用自定义卡号的商户使用。
        /// 步骤一：在创建/更新接口填入跳转型一键激活相关字段
        /// 步骤二：设置开卡字段接口
        /// 步骤三：获取用户提交资料
        /// 步骤四：调用接口激活会员卡
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActivateMemberTempInfoResult Activatetempinfo(ActivateMemberTempInfoRequest model)
        {
            //获取api请求url
            var url = GetAccessApiUrl("activatetempinfo", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ActivateMemberTempInfoResult>(url, model);
            return result;
        }

        #endregion

        #region 拉取会员信息（积分查询）接口
        /// <summary>
        /// 拉取会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GetUserInfoResult GetUserInfo(GetUserInfoRequest model)
        {
            var url = GetAccessApiUrl("userinfo/get", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<GetUserInfoResult>(url, model);
            return result;
        }
        #endregion

        #region 更新会员信息
        /// <summary>
        ///  当会员持卡消费后，支持开发者调用该接口更新会员信息。会员卡交易后的每次信息变更需通过该接口通知微信，便于后续消息通知及其他扩展功能。
        ///  值得注意的是，如果开发者做不到实时同步积分、余额至微信端，我们强烈建议开发者可以在每天的固定时间点变更积分，一天不超过三次。当传入的积分值与之前无变化时（传入的bonus=原来的bonus），不会有积分变动通知。
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UpdateUserResult UpdateUser(UpdateUserRequest model)
        {
            //获取api请求url
            var url = GetAccessApiUrl("updateuser", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<UpdateUserResult>(url, model);
            return result;
        }
        #endregion

        #region 更新会员卡信息
        public ApiResult UpdateMemberCard(UpdateCardRequest model)
        {
            var url = GetAccessApiUrl("update", ApiName, "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;

        }
        #endregion

        /// <summary>
        /// 设置开卡字段接口
        /// 开发者在创建时填入wx_activate字段后，需要调用该接口设置用户激活时需要填写的选项，否则一键开卡设置不生效。
        /// </summary>
        /// <returns></returns>
        public ApiResult ActivateUserForm()
        {
            var url = GetAccessApiUrl("activateuserform/set", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, "");
            return result;
        }
        /// <summary>
        /// 接口激活
        /// 接口激活通常需要开发者开发用户填写资料的网页。通常有两种激活流程：
        /// 1. 用户必须在填写资料后才能领卡，领卡后开发者调用激活接口为用户激活会员卡；
        /// 2. 是用户可以先领取会员卡，点击激活会员卡跳转至开发者设置的资料填写页面，填写完成后开发者调用激活接口为用户激活会员卡。
        /// </summary>
        /// <returns></returns>
        public ApiResult Activate(ActivateRequest model)
        {
            var url = GetAccessApiUrl("activate", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }
        #endregion

        #region 自定义Code
        /// <summary>
        /// 导入自定义CODE
        /// 1）单次调用接口传入code的数量上限为100个。
        /// 2）每一个 code 均不能为空串。
        /// 3）导入结束后系统会自动判断提供方设置库存与实际导入code的量是否一致。
        /// 4）导入失败支持重复导入，提示成功为止。
        /// </summary>
        /// <param name="cardId">卡卷编码</param>
        /// <param name="codeList">自定义Code列表</param>
        /// <returns></returns>
        public DepositCustomCodeResult DepositCustomCode(string cardId, List<string> codeList)
        {
            var url = GetAccessApiUrl("deposit", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = codeList
            };
            var result = Post<DepositCustomCodeResult>(url, data);
            return result;
        }

        /// <summary>
        /// 查询导入code数目接口,查询code导入微信后台成功的数目。
        /// </summary>
        /// <returns></returns>
        public GetDepositCountResult GetDepositCount(string cardId)
        {
            var url = GetAccessApiUrl("getdepositcount", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
            };
            var result = Post<GetDepositCountResult>(url, data);
            return result;
        }

        /// <summary>
        /// 为了避免出现导入差错，强烈建议开发者在查询完code数目的时候核查code接口校验code导入微信后台的情况。
        /// </summary>
        /// <param name="cardId">进行导入code的卡券ID</param>
        /// <param name="codeList">已经导入微信卡券后台的自定义code，上限为100个。</param>
        /// <returns></returns>
        public CheckCodeResult CheckCode(string cardId, List<string> codeList)
        {
            var url = GetAccessApiUrl("checkcode", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = codeList
            };
            var result = Post<CheckCodeResult>(url, data);
            return result;
        }

        #endregion

        #region 修改卡券库存
        /// <summary>
        /// 修改卡券库存
        /// </summary>
        /// <returns></returns>
        public ApiResult ModifyStock(ModifyStockRequest model)
        {
            var url = GetAccessApiUrl("modifystock", ApiName, "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;
        }
        #endregion

        #region 删除卡券
        /// <summary>
        /// 删除卡券
        /// </summary>
        public ApiResult Delete(string cardId)
        {
            var url = GetAccessApiUrl("delete", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }
        #endregion

        #region 设置卡券失效接口
        /// <summary>
        /// 设置卡券失效接口
        /// 为满足改票、退款等异常情况，可调用卡券失效接口将用户的卡券设置为失效状态。 
        /// 1.设置卡券失效的操作不可逆，即无法将设置为失效的卡券调回有效状态，商家须慎重调用该接口。
        /// 2.商户调用失效接口前须与顾客事先告知并取得同意，否则因此带来的顾客投诉，微信将会按照《微信运营处罚规则》进行处罚。
        /// </summary>
        /// <param name="cardId">会员卡编码，非自定义Code可以不填</param>
        /// <param name="code">会员卡Code</param>
        /// <returns></returns>
        public ApiResult Unavailable(string code, string cardId = null)
        {
            var url = GetAccessApiUrl("unavailable", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = code
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }
        #endregion

        #region 投放卡券
        /// <summary>
        /// 创建二维码接口
        /// </summary>
        public CreateQRCodeResult CreateQRCode(CreareQRCodeRequest model)
        {
            var url = GetAccessApiUrl("create", "card/qrcode", "https://api.weixin.qq.com");
            var result = Post<CreateQRCodeResult>(url, model);
            return result;
        }
        /// <summary>
        /// 卡券货架支持开发者通过调用接口生成一个卡券领取H5页面，并获取页面链接，进行卡券投放动作。
        /// 目前卡券货架仅支持非自定义code的卡券，自定义code的卡券需先调用导入code接口将code导入才能正常使用。
        /// 创建货架时需填写投放路径的场景字段
        /// </summary>
        public CreateLandingPageResult CreateLandingPage(CreateLandingPageRequest model)
        {
            var url = GetAccessApiUrl("create", "card/landingpage", "https://api.weixin.qq.com");
            var result = Post<CreateLandingPageResult>(url, model);
            return result;
        }

        #endregion
    }
}