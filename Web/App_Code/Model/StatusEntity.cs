using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// StatusEntity 的摘要说明
/// </summary>
public class StatusEntity
{
    public StatusEntity()
    {

    }

    public enum OrderStatus
    {
        已删除 = -1,
        待付款 = 1,
        付款失败 = 10,
        已付款 = 20,
        已入住 = 30,
        已评论 = 40
    }

    public enum CardStatus
    {
        已删除 = -1,
        启用 = 1,
        暂停使用 = 10
    }

    public enum UserCardStatus
    {
        已删除 = -1,
        正常 = 1,
        使用中 = 10,
        已使用 = 20,
        已过期 = 30
    }


    public enum UserMealCardStatus
    {
        正常 = 1,
        已核销 = 10
    }

    public enum VoteSubjectStatus
    {
        已删除 = -1,
        关闭 = 1,
        开启 = 10
    }

    public enum ProductStatus
    {
        已删除 = -1,
        上架 = 1,
        下架 = 10
    }
    public enum CakeStatus
    {
        已删除 = -1,
        上架 = 1,
        下架 = 10
    }
}