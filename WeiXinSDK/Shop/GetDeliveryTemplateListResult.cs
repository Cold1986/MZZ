using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Shop
{
    public class GetDeliveryTemplateListResult:ReturnCode
    {
        public List<DeliveryTemplate> templates_info { get; set; }
    }
}
