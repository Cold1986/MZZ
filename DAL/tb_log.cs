using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
    /// <summary>
    /// 数据访问类:tb_log
    /// </summary>
    public partial class tb_log
    {
        public tb_log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int log_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_log");
            strSql.Append(" where log_id=@log_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@log_id", MySqlDbType.Int32)
			};
            parameters[0].Value = log_id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MZZ.Model.tb_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_log(");
            strSql.Append("log_userid,log_openid,log_operation,log_event,log_remarks,log_ip,log_time,log_state)");
            strSql.Append(" values (");
            strSql.Append("@log_userid,@log_openid,@log_operation,@log_event,@log_remarks,@log_ip,@log_time,@log_state)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@log_userid", MySqlDbType.Int32,11),
					new MySqlParameter("@log_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@log_operation", MySqlDbType.VarChar,50),
					new MySqlParameter("@log_event", MySqlDbType.Text),
					new MySqlParameter("@log_remarks", MySqlDbType.VarChar,255),
					new MySqlParameter("@log_ip", MySqlDbType.VarChar,20),
					new MySqlParameter("@log_time", MySqlDbType.DateTime),
					new MySqlParameter("@log_state", MySqlDbType.Int32,5)};
            parameters[0].Value = model.log_userid;
            parameters[1].Value = model.log_openid;
            parameters[2].Value = model.log_operation;
            parameters[3].Value = model.log_event;
            parameters[4].Value = model.log_remarks;
            parameters[5].Value = model.log_ip;
            parameters[6].Value = model.log_time;
            parameters[7].Value = model.log_state;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MZZ.Model.tb_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_log set ");
            strSql.Append("log_userid=@log_userid,");
            strSql.Append("log_openid=@log_openid,");
            strSql.Append("log_operation=@log_operation,");
            strSql.Append("log_event=@log_event,");
            strSql.Append("log_remarks=@log_remarks,");
            strSql.Append("log_ip=@log_ip,");
            strSql.Append("log_time=@log_time,");
            strSql.Append("log_state=@log_state");
            strSql.Append(" where log_id=@log_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@log_userid", MySqlDbType.Int32,11),
					new MySqlParameter("@log_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@log_operation", MySqlDbType.VarChar,50),
					new MySqlParameter("@log_event", MySqlDbType.Text),
					new MySqlParameter("@log_remarks", MySqlDbType.VarChar,255),
					new MySqlParameter("@log_ip", MySqlDbType.VarChar,20),
					new MySqlParameter("@log_time", MySqlDbType.DateTime),
					new MySqlParameter("@log_state", MySqlDbType.Int32,5),
					new MySqlParameter("@log_id", MySqlDbType.Int32,10)};
            parameters[0].Value = model.log_userid;
            parameters[1].Value = model.log_openid;
            parameters[2].Value = model.log_operation;
            parameters[3].Value = model.log_event;
            parameters[4].Value = model.log_remarks;
            parameters[5].Value = model.log_ip;
            parameters[6].Value = model.log_time;
            parameters[7].Value = model.log_state;
            parameters[8].Value = model.log_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_log ");
            strSql.Append(" where log_id=@log_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@log_id", MySqlDbType.Int32)
			};
            parameters[0].Value = log_id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string log_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_log ");
            strSql.Append(" where log_id in (" + log_idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MZZ.Model.tb_log GetModel(int log_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select log_id,log_userid,log_openid,log_operation,log_event,log_remarks,log_ip,log_time,log_state from tb_log ");
            strSql.Append(" where log_id=@log_id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@log_id", MySqlDbType.Int32)
			};
            parameters[0].Value = log_id;

            MZZ.Model.tb_log model = new MZZ.Model.tb_log();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MZZ.Model.tb_log DataRowToModel(DataRow row)
        {
            MZZ.Model.tb_log model = new MZZ.Model.tb_log();
            if (row != null)
            {
                if (row["log_id"] != null && row["log_id"].ToString() != "")
                {
                    model.log_id = int.Parse(row["log_id"].ToString());
                }
                if (row["log_userid"] != null && row["log_userid"].ToString() != "")
                {
                    model.log_userid = int.Parse(row["log_userid"].ToString());
                }
                if (row["log_openid"] != null)
                {
                    model.log_openid = row["log_openid"].ToString();
                }
                if (row["log_operation"] != null)
                {
                    model.log_operation = row["log_operation"].ToString();
                }
                if (row["log_event"] != null)
                {
                    model.log_event = row["log_event"].ToString();
                }
                if (row["log_remarks"] != null)
                {
                    model.log_remarks = row["log_remarks"].ToString();
                }
                if (row["log_ip"] != null)
                {
                    model.log_ip = row["log_ip"].ToString();
                }
                if (row["log_time"] != null && row["log_time"].ToString() != "")
                {
                    model.log_time = DateTime.Parse(row["log_time"].ToString());
                }
                if (row["log_state"] != null && row["log_state"].ToString() != "")
                {
                    model.log_state = int.Parse(row["log_state"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select log_id,log_userid,log_openid,log_operation,log_event,log_remarks,log_ip,log_time,log_state ");
            strSql.Append(" FROM tb_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM tb_log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.log_id desc");
            }
            strSql.Append(")AS Row, T.*  from tb_log T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "tb_log";
            parameters[1].Value = "log_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

