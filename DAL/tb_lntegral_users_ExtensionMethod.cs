using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MZZ.DAL
{
    public partial class tb_lntegral_users
    {
        public DataSet GetExchangeNum()
        {
            return DbHelperMySQL.Query("SELECT prizeid,count(prizeid) as num FROM moeotaku.tb_lntegral_users group by prizeid");
        }
    }
}
