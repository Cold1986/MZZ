using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///TypeEntity 的摘要说明
/// </summary>
public class TypeEntity
{
    public TypeEntity()
    {

    }

    /// <summary>
    /// 卡券使用时间的类型
    /// </summary>
    public enum CardDateInfoType
    {
        /// <summary>
        /// 固定日期区间
        /// </summary>
        固定日期区间 = 1,
        /// <summary>
        /// 固定时长（自领取后按天算）
        /// </summary>
        固定时长 = 10,
        /// <summary>
        /// 永久有效
        /// </summary>
        永久有效 = 20
    }

    /// <summary>
    /// 卡券类别
    /// </summary>
    public enum CardType
    {
        中餐厅代金券 = 1,
        客房代金券 = 10,
    }

    /// <summary>
    /// 微信菜单类型
    /// </summary>
    public enum WxMenuType
    {
        /// <summary>
        /// 一级菜单
        /// </summary>
        Multiple,
        /// <summary>
        /// 超链接
        /// </summary>
        View,
        /// <summary>
        /// 点击事件
        /// </summary>
        Click
    }
}