using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_activity
	/// </summary>
	public partial class tb_activity
	{
		public tb_activity()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("activity_id", "tb_activity"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int activity_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_activity");
			strSql.Append(" where activity_id=@activity_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@activity_id", MySqlDbType.Int32)
			};
			parameters[0].Value = activity_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_activity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_activity(");
			strSql.Append("activity_hyid,activity_openid,activity_reason,activity_num,activity_calculate,activity_state,activity_times)");
			strSql.Append(" values (");
			strSql.Append("@activity_hyid,@activity_openid,@activity_reason,@activity_num,@activity_calculate,@activity_state,@activity_times)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@activity_hyid", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@activity_reason", MySqlDbType.VarChar,50),
					new MySqlParameter("@activity_num", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_calculate", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_state", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_times", MySqlDbType.DateTime)};
			parameters[0].Value = model.activity_hyid;
			parameters[1].Value = model.activity_openid;
			parameters[2].Value = model.activity_reason;
			parameters[3].Value = model.activity_num;
			parameters[4].Value = model.activity_calculate;
			parameters[5].Value = model.activity_state;
			parameters[6].Value = model.activity_times;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(MZZ.Model.tb_activity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_activity set ");
			strSql.Append("activity_hyid=@activity_hyid,");
			strSql.Append("activity_openid=@activity_openid,");
			strSql.Append("activity_reason=@activity_reason,");
			strSql.Append("activity_num=@activity_num,");
			strSql.Append("activity_calculate=@activity_calculate,");
			strSql.Append("activity_state=@activity_state,");
			strSql.Append("activity_times=@activity_times");
			strSql.Append(" where activity_id=@activity_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@activity_hyid", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@activity_reason", MySqlDbType.VarChar,50),
					new MySqlParameter("@activity_num", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_calculate", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_state", MySqlDbType.Int32,11),
					new MySqlParameter("@activity_times", MySqlDbType.DateTime),
					new MySqlParameter("@activity_id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.activity_hyid;
			parameters[1].Value = model.activity_openid;
			parameters[2].Value = model.activity_reason;
			parameters[3].Value = model.activity_num;
			parameters[4].Value = model.activity_calculate;
			parameters[5].Value = model.activity_state;
			parameters[6].Value = model.activity_times;
			parameters[7].Value = model.activity_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int activity_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_activity ");
			strSql.Append(" where activity_id=@activity_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@activity_id", MySqlDbType.Int32)
			};
			parameters[0].Value = activity_id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string activity_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_activity ");
			strSql.Append(" where activity_id in ("+activity_idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public MZZ.Model.tb_activity GetModel(int activity_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select activity_id,activity_hyid,activity_openid,activity_reason,activity_num,activity_calculate,activity_state,activity_times from tb_activity ");
			strSql.Append(" where activity_id=@activity_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@activity_id", MySqlDbType.Int32)
			};
			parameters[0].Value = activity_id;

			MZZ.Model.tb_activity model=new MZZ.Model.tb_activity();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public MZZ.Model.tb_activity DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_activity model=new MZZ.Model.tb_activity();
			if (row != null)
			{
				if(row["activity_id"]!=null && row["activity_id"].ToString()!="")
				{
					model.activity_id=int.Parse(row["activity_id"].ToString());
				}
				if(row["activity_hyid"]!=null && row["activity_hyid"].ToString()!="")
				{
					model.activity_hyid=int.Parse(row["activity_hyid"].ToString());
				}
				if(row["activity_openid"]!=null)
				{
					model.activity_openid=row["activity_openid"].ToString();
				}
				if(row["activity_reason"]!=null)
				{
					model.activity_reason=row["activity_reason"].ToString();
				}
				if(row["activity_num"]!=null && row["activity_num"].ToString()!="")
				{
					model.activity_num=int.Parse(row["activity_num"].ToString());
				}
				if(row["activity_calculate"]!=null && row["activity_calculate"].ToString()!="")
				{
					model.activity_calculate=int.Parse(row["activity_calculate"].ToString());
				}
				if(row["activity_state"]!=null && row["activity_state"].ToString()!="")
				{
					model.activity_state=int.Parse(row["activity_state"].ToString());
				}
				if(row["activity_times"]!=null && row["activity_times"].ToString()!="")
				{
					model.activity_times=DateTime.Parse(row["activity_times"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select activity_id,activity_hyid,activity_openid,activity_reason,activity_num,activity_calculate,activity_state,activity_times ");
			strSql.Append(" FROM tb_activity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_activity ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.activity_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_activity T ");
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
			parameters[0].Value = "tb_activity";
			parameters[1].Value = "activity_id";
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

