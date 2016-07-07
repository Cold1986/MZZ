using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Card
{
    public class GetCardListResult:ReturnCode
    {
        /// <summary>
        /// 该商户名下card_id 总数
        /// </summary>
        public int total_num { get; set; }

        /// <summary>
        /// 卡id 列表
        /// </summary>
        public List<string> card_id_list { get; set; }
    }
}
