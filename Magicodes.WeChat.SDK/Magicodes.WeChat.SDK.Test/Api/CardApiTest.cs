// ======================================================================
//  
//          Copyright (C) 2016-2020 湖南心莱信息科技有限公司    
//          All rights reserved
//  
//          filename : CustomerServiceApiTest.cs
//          description :
//  
//          created by 李文强 at  2016/09/23 17:10
//          Blog：http://www.cnblogs.com/codelove/
//          GitHub ： https://github.com/xin-lai
//          Home：http://xin-lai.com
//  
// ======================================================================

using Magicodes.WeChat.SDK.Apis.Card;
using Magicodes.WeChat.SDK.Apis.CustomerService;
using Magicodes.WeChat.SDK.Apis.POI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Magicodes.WeChat.SDK.Test.Api
{
    [TestClass]
    public class CardApiTest : ApiTestBase
    {
        private readonly CardApi _weChatApi = WeChatApisContext.Current.CardApi;

        [TestMethod]
        public void CardApiTest_Add()
        {
            using (var fs = GetInputFile("qrcode.jpg"))
            {
                var result = _weChatApi.UploadImage("qrcode.jpg", fs);
                if (!result.IsSuccess())
                    Assert.Fail("上传图片失败，返回结果如下：" + result.DetailResult + "；Msg:" + result.GetFriendlyMessage());

                CardInfo cardInfo = new Groupon()
                {
                    Groupon_ = new Groupon.GrouponInfo()
                    {
                        BaseInfo = new BaseInfo()
                        {
                            LogoUrl = result.Url,
                            BrandName = "Test",
                            CodeType = CodeTypes.CODE_TYPE_TEXT,
                            Title = "Test套餐",
                            Color = "Color010",
                            Notice = "使用时向服务员出示此券",
                            ServicePhone = "020-88888888",
                            Description = "不可与其他优惠同享\n如需团购券发票，请在消费时向商户提出\n店内均可使用，仅限堂食",
                            DateInfo = new FixTimeRangeDateInfo()
                            {
                                BeginTime = DateTime.Now,
                                EndTime = DateTime.Now.AddMonths(1),
                            },
                            Sku = new Sku()
                            {
                                Quantity = 500000
                            },
                            GetLimit = 3,
                            UseCustomCode = false,
                            BindOpenId = false,
                            CanShare = true,
                            CanGiveFriend = true,
                            LocationIdList = new int[] { 123, 12321, 345345 },
                            CenterTitle = "顶部居中按钮",
                            CenterSubTitle = "按钮下方的wording",
                            CenterUrl = "http://xin-lai.com",
                            CustomUrlName = "立即使用",
                            CustomUrl = "http://xin-lai.com",
                            CustomUrlSubTitle = "6个汉字tips",
                            PromotionUrlName = "更多优惠",
                            PromotionUrl = "http://xin-lai.com",
                            Source = "美团"
                        },
                        AdvancedInfo = new AdvancedInfo()
                        {
                            UseCondition = new UseCondition()
                            {
                                AcceptCategory = "Test类",
                                RejectCategory = "Test",
                                CanUseWithOtherDiscount = true
                            },
                            Abstract = new Abstract()
                            {
                                AbstractInfo = "多种新季菜品，期待您的光临",
                                IconUrlList = new string[] { result.Url }
                            },
                            TextImageList = new TextImageList[]
                            {
                                new TextImageList() { ImageUrl=result.Url,Text="此菜品精选食材，以独特的烹饪方法，最大程度地刺激食 客的味蕾" },
                                new TextImageList() { ImageUrl=result.Url,Text="此菜品迎合大众口味，老少皆宜，营养均衡" },
                            },
                            TimeLimit = new TimeLimit[]{
                                new TimeLimit()
                                {
                                    Type = TimeLimitTypes.MONDAY,
                                    BeginHour = 0,
                                    EndHour = 10,
                                    BeginMinute = 10,
                                    EndMinute = 59
                                },
                                new TimeLimit()
                                {
                                    Type = TimeLimitTypes.HOLIDAY
                                }
                            },
                            BusinessService = new string[] {
                                "BIZ_SERVICE_FREE_WIFI",
                                "BIZ_SERVICE_WITH_PET",
                                "BIZ_SERVICE_FREE_PARK",
                                "BIZ_SERVICE_DELIVER"
                            }
                        },
                        DealDetail = "以下锅底2选1（有菌王锅、麻辣锅、大骨锅、番茄锅、清补 凉锅、酸菜鱼锅可选）：\n大锅1份 12元\n小锅2份 16元"
                    }
                };
                var cardResult = _weChatApi.Add(cardInfo);
                if (!cardResult.IsSuccess())
                    Assert.Fail("创建卡券失败，返回结果如下：" + cardResult.DetailResult + "；Msg:" + cardResult.GetFriendlyMessage());
            }

        }
    }
}