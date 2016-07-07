using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_behavior
	/// </summary>
	public partial class tb_behavior
	{
		public tb_behavior()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("behavior_id", "tb_behavior"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int behavior_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_behavior");
			strSql.Append(" where behavior_id=@behavior_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@behavior_id", MySqlDbType.Int32)
			};
			parameters[0].Value = behavior_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_behavior model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_behavior(");
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(")");
			MySqlParameter[] parameters = {
};

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
		public bool Update(MZZ.Model.tb_behavior model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_behavior set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("behavior_id=@behavior_id");
			strSql.Append(" where behavior_id=@behavior_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@behavior_id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.behavior_id;

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
		public bool Delete(int behavior_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_behavior ");
			strSql.Append(" where behavior_id=@behavior_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@behavior_id", MySqlDbType.Int32)
			};
			parameters[0].Value = behavior_id;

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
		public bool DeleteList(string behavior_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_behavior ");
			strSql.Append(" where behavior_id in ("+behavior_idlist + ")  ");
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
		public MZZ.Model.tb_behavior GetModel(int behavior_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select behavior_id from tb_behavior ");
			strSql.Append(" where behavior_id=@behavior_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@behavior_id", MySqlDbType.Int32)
			};
			parameters[0].Value = behavior_id;

			MZZ.Model.tb_behavior model=new MZZ.Model.tb_behavior();
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
		public MZZ.Model.tb_behavior DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_behavior model=new MZZ.Model.tb_behavior();
			if (row != null)
			{
				if(row["behavior_id"]!=null && row["behavior_id"].ToString()!="")
				{
					model.behavior_id=int.Parse(row["behavior_id"].ToString());
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
			strSql.Append("select behavior_id ");
			strSql.Append(" FROM tb_behavior ");
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
			strSql.Append("select count(1) FROM tb_behavior ");
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
				strSql.Append("order by T.behavior_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_behavior T ");
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
			parameters[0].Value = "tb_behavior";
			parameters[1].Value = "behavior_id";
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

