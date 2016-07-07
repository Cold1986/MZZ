using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Shop
{
    public class GetSubCateListResult:ReturnCode
    {
        public List<ID_Name> cate_list { get; set; }
    }
}
