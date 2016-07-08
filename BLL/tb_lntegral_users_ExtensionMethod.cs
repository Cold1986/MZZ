using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MZZ.BLL
{
    public partial class tb_lntegral_users
    {
        public DataSet GetExchangeNum()
        {
            return dal.GetExchangeNum();
        }
    }
}
