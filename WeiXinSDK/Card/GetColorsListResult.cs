using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXinSDK;


namespace WeiXinSDK.Card
{
    /// <summary>
    ///GetColorsListResult 的摘要说明
    /// </summary>
    public class GetColorsListResult : ReturnCode
    {
        /// <summary>
        /// 颜色列表
        /// </summary>
        public List<CardColor> colors { get; set; }

        public class CardColor
        {
            /// <summary>
            /// 颜色名称
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 颜色值
            /// </summary>
            public string value { get; set; }
        }
    }
}