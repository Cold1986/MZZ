using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Card
{
    public class SetTestWhiteListResult : ReturnCode
    {
        /// <summary>
        /// 白名单总数
        /// </summary>
        public int white_list_size { get; set; }
    }
}
