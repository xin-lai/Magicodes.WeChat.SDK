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

        #region 根据卡券JSON结构字符串获取卡券信息
        /// <summary>
        ///     根据卡券JSON结构字符串获取卡券信息
        /// </summary>
        /// <returns></returns>
        public CardInfo GetCardInfoByJson(string cardInfoJson)
        {
            return JsonConvert.DeserializeObject<CardInfo>(cardInfoJson, new CardInfoCustomConverter(), new DateInfoCustomConverter());
        }
        #endregion

        #region 卡卷

        #region 添加卡卷

        /// <summary>
        ///     添加卡卷
        /// </summary>
        /// <param name="cardInfo">卡券结构数据</param>
        /// <returns></returns>
        public AddCardApiResult Add(CardInfo cardInfo)
        {
            //获取api请求url
            var url = GetAccessApiUrl("create", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card = cardInfo
            };
            var result = Post<AddCardApiResult>(url, data);
            return result;
        }

        /// <summary>
        ///     添加卡卷
        /// </summary>
        /// <param name="cardInfoJson">卡券JSON结构字符串</param>
        /// <returns></returns>
        public AddCardApiResult AddByJson(string cardInfoJson)
        {
            return Add(GetCardInfoByJson(cardInfoJson));
        }

        #endregion

        #region 核销卡券

        #region 线下核销
        /// <summary>
        /// 查询Code接口
        /// 1.固定时长有效期会根据用户实际领取时间转换，如用户2013年10月1日领取，固定时长有效期为90天，即有效时间为2013年10月1日-12月29日有效。
        /// 2.无论check_consume填写的是true还是false,当code未被添加或者code被转赠领取是统一报错：invalid serial code
        /// </summary>
        /// <param name="cardId">卡券ID代表一类卡券。自定义code卡券必填。</param>
        /// <param name="code">单张卡券的唯一标准。</param>
        /// <param name="checkConsume">是否校验code核销状态，填入true和false时的code异常状态返回数据不同。</param>
        /// <returns></returns>
        public CodeStatusResult GetCodeStatus(string cardId, string code, bool checkConsume)
        {
            //获取api请求url
            var url = GetAccessApiUrl("get", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = code,
                check_consume = checkConsume
            };
            var result = Post<CodeStatusResult>(url, data);
            return result;
        }
        /// <summary>
        /// 核销卡卷
        /// 注：
        /// 1.仅支持核销有效状态的卡券，若卡券处于异常状态，均不可核销。（异常状态包括：卡券删除、未生效、过期、转赠中、转赠退回、失效）
        /// 2.自定义Code码（use_custom_code为true）的优惠券，在code被核销时，必须调用此接口。用于将用户客户端的code状态变更。自定义code的卡券调用接口时， post数据中需包含card_id，否则报invalid serial code，非自定义code不需上报。
        /// </summary>
        /// <returns></returns>
        public ConsumeCardResult ConsumeCard(string code, string cardId)
        {
            //获取api请求url
            var url = GetAccessApiUrl("consume", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = code
            };
            var result = Post<ConsumeCardResult>(url, data);
            return result;
        }

        #endregion


        #endregion

        /// <summary>
        /// 批量查询卡券列表
        /// </summary>
        /// <param name="statusList">卡券状态列表</param>
        /// <param name="offSet">查询卡列表的起始偏移量，从0开始，即offset: 5是指从从列表里的第六个开始读取。</param>
        /// <param name="count">需要查询的卡片的数量（数量最大50）。</param>
        /// <returns></returns>
        public GetBatchCardListResult GetBatchCardList(List<string> statusList = null, int offSet = 0, int count = 50)
        {
            //获取api请求url
            var url = GetAccessApiUrl("batchget", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                offset = offSet,
                count = count,
                status_list = statusList
            };
            var result = Post<GetBatchCardListResult>(url, data);
            return result;
        }

        /// <summary>
        /// 查看卡券详情
        /// 开发者可以调用该接口查询某个card_id的创建信息、审核状态以及库存数量。
        /// </summary>
        /// <returns></returns>
        public CardDetailResult GetCardDetail(string card_id)
        {
            //获取api请求url
            var url = GetAccessApiUrl("get", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                card_id = card_id
            };
            var result = Post<CardDetailResult>(url, data);
            return result;
        }
        /// <summary>
        ///  Code解码接口
        /// </summary>
        /// <param name="encrypt_code">经过加密的Code码。</param>
        /// <returns></returns>
        public DecrCodeApiResult DecryptCode(string encrypt_code)
        {
            //获取api请求url
            var url = GetAccessApiUrl("code/decrypt", ApiName, "https://api.weixin.qq.com");
            var data = new
            {
                encrypt_code = encrypt_code
            };
            var result = Post<DecrCodeApiResult>(url, data);
            return result;
        }

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

        #region 创建会员卡

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
        /// 根据Json结构字符串获取激活会员卡信息
        /// </summary>
        /// <param name="activateInfo"></param>
        /// <returns></returns>
        public ActivateMemberCardRequest GetActivateMemberCardByJson(string activateInfo)
        {
            return JsonConvert.DeserializeObject<ActivateMemberCardRequest>(activateInfo);
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
        /// <summary>
        /// 根据Json结构字符串获取转型一键激活
        /// </summary>
        /// <param name="activateInfo"></param>
        /// <returns></returns>
        public ActivateMemberTempInfoRequest GetActivateMemberTempInfoByJson(string activateMmberInfo)
        {
            return JsonConvert.DeserializeObject<ActivateMemberTempInfoRequest>(activateMmberInfo);
        }

        /// <summary>
        /// 设置开卡字段接口
        /// 开发者在创建时填入wx_activate字段后，需要调用该接口设置用户激活时需要填写的选项，否则一键开卡设置不生效。
        /// </summary>
        /// <returns></returns>
        public ApiResult ActivateUserForm(ActivateMemberUserformRequest setActivateInfo)
        {
            var url = GetAccessApiUrl("activateuserform/set", "card/membercard", "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, setActivateInfo);
            return result;
        }
        /// <summary>
        /// 根据Json结构字符串获取设置开卡字段信息
        /// </summary>
        public ActivateMemberUserformRequest GetActivateUserFormInfoByJson(string userFormInfo)
        {
            return JsonConvert.DeserializeObject<ActivateMemberUserformRequest>(userFormInfo);
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

        /// <summary>
        /// 根据Json结构字符串获取会员信息（积分查询）接口
        /// </summary>
        public GetUserInfoRequest GetUserInfoByJson(string userinfo)
        {
            return JsonConvert.DeserializeObject<GetUserInfoRequest>(userinfo);
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
        /// <summary>
        /// 根据Json结构字符串获取更新会员信息
        /// </summary>
        public UpdateUserRequest GetUpdateUserInfoByJson(string updateuserinfo)
        {
            return JsonConvert.DeserializeObject<UpdateUserRequest>(updateuserinfo);
        }
        #endregion

        #region 更新会员卡信息
        public ApiResult UpdateMemberCard(UpdateCardRequest model)
        {
            var url = GetAccessApiUrl("update", ApiName, "https://api.weixin.qq.com");
            var result = Post<ApiResult>(url, model);
            return result;

        }
        /// <summary>
        /// 根据卡券JSON结构字符串获取更新会员卡信息
        /// </summary>
        /// <returns></returns>
        public UpdateCardRequest GetUpdateMemnberInfoByJson(string updateJson)
        {
            return JsonConvert.DeserializeObject<UpdateCardRequest>(updateJson, new DateInfoCustomConverter());
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

        #endregion

        #region 会员卡管理
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

        /// <summary>
        /// 根据Json结构字符串获取修改卡券库存
        /// </summary>
        public GetUserInfoRequest GetModifyStockInfoByJson(string modifystock)
        {
            return JsonConvert.DeserializeObject<GetUserInfoRequest>(modifystock);
        }

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

        /// <summary>
        /// 为确保转赠后的安全性，微信允许自定义Code的商户对已下发的code进行更改。
        /// 注：为避免用户疑惑，建议仅在发生转赠行为后（发生转赠后，微信会通过事件推送的方式告知商户被转赠的卡券Code）对用户的Code进行更改。
        /// </summary>
        /// <param name="cardId">卡券ID。自定义Code码卡券为必填。</param>
        /// <param name="code">需变更的Code码。</param>
        /// <param name="newCode">变更后的有效Code码。</param>
        /// <returns></returns>
        public ApiResult UpdateCode(string cardId, string code, string newCode)
        {
            var url = GetAccessApiUrl("update", "card/code", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                code = code,
                new_code = newCode
            };
            var result = Post<ApiResult>(url, data);
            return result;
        }


        /// <summary>
        /// 设置卡券失效接口
        /// 为满足改票、退款等异常情况，可调用卡券失效接口将用户的卡券设置为失效状态。 
        /// 1.设置卡券失效的操作不可逆，即无法将设置为失效的卡券调回有效状态，商家须慎重调用该接口。
        /// 2.商户调用失效接口前须与顾客事先告知并取得同意，否则因此带来的顾客投诉，微信将会按照《微信运营处罚规则》进行处罚。
        /// </summary>
        /// <param name="cardId">会员卡编码，非自定义Code可以不填</param>
        /// <param name="code">会员卡Code</param>
        /// <returns></returns>
        public ApiResult Unavailable(string code, string cardId)
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
        /// <summary>
        /// 拉取单张会员卡数据接口
        /// 拉取API创建的会员卡数据情况
        /// </summary>
        /// <param name="begin_date">查询数据的起始时间，格式：2015-06-15</param>
        /// <param name="end_date">查询数据的截至时间，格式：2015-07-15</param>
        /// <param name="card_id">卡券id</param>
        /// <returns></returns>
        public CardBizuinInfoResult GetCardBizuinInfoByCardId(string begin_date, string end_date, string cardId)
        {
            var url = GetAccessApiUrl("getcardmembercarddetail", "datacube", "https://api.weixin.qq.com");
            var data = new
            {
                begin_date = begin_date,
                end_date = end_date,
                card_id = cardId
            };
            var result = Post<CardBizuinInfoResult>(url, data);
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
        /// 根据Json结构字符串获取创建二维码信息
        /// </summary>
        public CreareQRCodeRequest GetCreateQRCodeInfoByJson(string createqrcode)
        {
            return JsonConvert.DeserializeObject<CreareQRCodeRequest>(createqrcode);
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
        /// <summary>
        /// 根据Json结构字符串获取创建二维码信息
        /// </summary>
        public CreateLandingPageResult GetLandingPageInfoByJson(string landingPageInfo)
        {
            return JsonConvert.DeserializeObject<CreateLandingPageResult>(landingPageInfo);
        }
        #endregion

        #region 支付即会员
        /// <summary>
        /// 查询某个商户号是否支持支付即会员功能
        /// </summary>
        public GetPayGiftMemberResult GetPayGiftMember(string mchId)
        {
            var url = GetAccessApiUrl("get", "card/paygiftmembercard", "https://api.weixin.qq.com");
            var data = new
            {
                mchid = mchId
            };
            var result = Post<GetPayGiftMemberResult>(url, data);
            return result;
        }
        /// <summary>
        /// 支持商户设置支付即会员的规则，可以区分时间段和金额区间发会员卡。
        /// </summary>
        public AddPayGiftMemberResult AddPayGiftMember(AddPayGiftMemberRequest model)
        {
            var url = GetAccessApiUrl("add", "card/paygiftmembercard", "https://api.weixin.qq.com");
            var result = Post<AddPayGiftMemberResult>(url, model);
            return result;
        }

        /// <summary>
        /// 根据Json结构字符串获取设置支付即会员的规则
        /// </summary>
        public AddPayGiftMemberResult GetPayGiftMemberByJson(string payGiftMemberInfo)
        {
            return JsonConvert.DeserializeObject<AddPayGiftMemberResult>(payGiftMemberInfo);
        }
        /// <summary>
        /// 删除之前已经设置的支付即会员规则
        /// </summary>
        public AddPayGiftMemberResult DeletePayGiftMember(string cardId, List<string> mchidList)
        {
            var url = GetAccessApiUrl("delete", "card/paygiftmembercard", "https://api.weixin.qq.com");
            var data = new
            {
                card_id = cardId,
                mchid_list = mchidList
            };
            var result = Post<AddPayGiftMemberResult>(url, data);
            return result;
        }
        #endregion
    }
}