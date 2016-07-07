using System;
using System.Collections.Generic;
using System.Text;

namespace WeiXinSDK.Shop
{
    public class GetDeliveryTemplateResult:ReturnCode
    {
        public DeliveryTemplate template_info { get; set; }
    }
}
