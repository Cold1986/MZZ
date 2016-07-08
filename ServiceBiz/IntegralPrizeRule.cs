using CommonLibs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBiz
{
    public class IntegralPrizeRule
    {

        private static MZZ.BLL.tb_lntegral_prize integralPrize = new MZZ.BLL.tb_lntegral_prize();
        private static MZZ.BLL.tb_lntegral_users integralUsers = new MZZ.BLL.tb_lntegral_users();
        /// <summary>
        /// 根据批次获取奖品列表
        /// </summary>
        /// <param name="batch"></param>
        /// <returns></returns>
        public static DataTable GetPirzeDataTableByBatch(int batch)
        {
            DataTable dt = null;
            var res = CacheHelper.GetCache("IntegralPrize" + batch.ToString());
            if (res != null)
            {
                dt = (DataTable)res;
            }
            else
            {
                var list = integralPrize.GetList("lntegral_prize_status='1' and lntegral_prize_batch='" + batch + "'");
                dt = list.Tables[0];
                CacheHelper.SetCache("IntegralPrize" + batch.ToString(), dt, new TimeSpan(1, 0, 0, 0));
            }
            return dt;

        }

        /// <summary>
        /// 获取奖品剩余量
        /// </summary>
        /// <param name="prizeId">奖品id</param>
        /// <param name="prizeNum">奖品预发数量</param>
        /// <returns></returns>
        public static string GetRemainderNum(string prizeId, string prizeNum)
        {
            int intPrizeNum = ConvertHelper.ToInt(prizeNum);
            int intExchangeNum = Convert.ToInt32(DictionaryHelper.Get(GetExchangeNum(), FormatType.GetValue, prizeId));

            int intRemainderNum = intPrizeNum - intExchangeNum;
            //return intRemainderNum <= 0 ? "已兑完" : "剩余" + intRemainderNum.ToString();
            return intRemainderNum <= 0 ? "0" : intRemainderNum.ToString();
        }

        /// <summary>
        /// 获取已兑换数量
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetExchangeNum()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var res = CacheHelper.GetCache("GetExchangeNum");
            if (res != null)
            {
                dic = (Dictionary<string, string>)res;
            }
            else
            {
                var ds = integralUsers.GetExchangeNum();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dic.Add(dr[0].ToString(), dr[1].ToString());
                }

                CacheHelper.SetCache("GetExchangeNum", dic, new TimeSpan(0, 0, 30, 0));
            }

            return dic;
        }


    }
}
