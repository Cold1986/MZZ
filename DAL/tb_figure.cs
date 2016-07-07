using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_figure
	/// </summary>
	public partial class tb_figure
	{
		public tb_figure()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("figure_id", "tb_figure"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int figure_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_figure");
			strSql.Append(" where figure_id=@figure_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@figure_id", MySqlDbType.Int32)
			};
			parameters[0].Value = figure_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_figure model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_figure(");
			strSql.Append("figure_hyid,figure_openid,figure_title,figure_category,figure_classify,figure_sellprice,figure_introduce,figure_condition,figure_time,figure_state)");
			strSql.Append(" values (");
			strSql.Append("@figure_hyid,@figure_openid,@figure_title,@figure_category,@figure_classify,@figure_sellprice,@figure_introduce,@figure_condition,@figure_time,@figure_state)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@figure_hyid", MySqlDbType.Int32,11),
					new MySqlParameter("@figure_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@figure_title", MySqlDbType.VarChar,100),
					new MySqlParameter("@figure_category", MySqlDbType.VarChar,50),
					new MySqlParameter("@figure_classify", MySqlDbType.VarChar,50),
					new MySqlParameter("@figure_sellprice", MySqlDbType.Float),
					new MySqlParameter("@figure_introduce", MySqlDbType.Text),
					new MySqlParameter("@figure_condition", MySqlDbType.VarChar,10),
					new MySqlParameter("@figure_time", MySqlDbType.DateTime),
					new MySqlParameter("@figure_state", MySqlDbType.Int32,11)};
			parameters[0].Value = model.figure_hyid;
			parameters[1].Value = model.figure_openid;
			parameters[2].Value = model.figure_title;
			parameters[3].Value = model.figure_category;
			parameters[4].Value = model.figure_classify;
			parameters[5].Value = model.figure_sellprice;
			parameters[6].Value = model.figure_introduce;
			parameters[7].Value = model.figure_condition;
			parameters[8].Value = model.figure_time;
			parameters[9].Value = model.figure_state;

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
		public bool Update(MZZ.Model.tb_figure model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_figure set ");
			strSql.Append("figure_hyid=@figure_hyid,");
			strSql.Append("figure_openid=@figure_openid,");
			strSql.Append("figure_title=@figure_title,");
			strSql.Append("figure_category=@figure_category,");
			strSql.Append("figure_classify=@figure_classify,");
			strSql.Append("figure_sellprice=@figure_sellprice,");
			strSql.Append("figure_introduce=@figure_introduce,");
			strSql.Append("figure_condition=@figure_condition,");
			strSql.Append("figure_time=@figure_time,");
			strSql.Append("figure_state=@figure_state");
			strSql.Append(" where figure_id=@figure_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@figure_hyid", MySqlDbType.Int32,11),
					new MySqlParameter("@figure_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@figure_title", MySqlDbType.VarChar,100),
					new MySqlParameter("@figure_category", MySqlDbType.VarChar,50),
					new MySqlParameter("@figure_classify", MySqlDbType.VarChar,50),
					new MySqlParameter("@figure_sellprice", MySqlDbType.Float),
					new MySqlParameter("@figure_introduce", MySqlDbType.Text),
					new MySqlParameter("@figure_condition", MySqlDbType.VarChar,10),
					new MySqlParameter("@figure_time", MySqlDbType.DateTime),
					new MySqlParameter("@figure_state", MySqlDbType.Int32,11),
					new MySqlParameter("@figure_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.figure_hyid;
			parameters[1].Value = model.figure_openid;
			parameters[2].Value = model.figure_title;
			parameters[3].Value = model.figure_category;
			parameters[4].Value = model.figure_classify;
			parameters[5].Value = model.figure_sellprice;
			parameters[6].Value = model.figure_introduce;
			parameters[7].Value = model.figure_condition;
			parameters[8].Value = model.figure_time;
			parameters[9].Value = model.figure_state;
			parameters[10].Value = model.figure_id;

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
		public bool Delete(int figure_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_figure ");
			strSql.Append(" where figure_id=@figure_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@figure_id", MySqlDbType.Int32)
			};
			parameters[0].Value = figure_id;

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
		public bool DeleteList(string figure_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_figure ");
			strSql.Append(" where figure_id in ("+figure_idlist + ")  ");
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
		public MZZ.Model.tb_figure GetModel(int figure_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select figure_id,figure_hyid,figure_openid,figure_title,figure_category,figure_classify,figure_sellprice,figure_introduce,figure_condition,figure_time,figure_state from tb_figure ");
			strSql.Append(" where figure_id=@figure_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@figure_id", MySqlDbType.Int32)
			};
			parameters[0].Value = figure_id;

			MZZ.Model.tb_figure model=new MZZ.Model.tb_figure();
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
		public MZZ.Model.tb_figure DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_figure model=new MZZ.Model.tb_figure();
			if (row != null)
			{
				if(row["figure_id"]!=null && row["figure_id"].ToString()!="")
				{
					model.figure_id=int.Parse(row["figure_id"].ToString());
				}
				if(row["figure_hyid"]!=null && row["figure_hyid"].ToString()!="")
				{
					model.figure_hyid=int.Parse(row["figure_hyid"].ToString());
				}
				if(row["figure_openid"]!=null)
				{
					model.figure_openid=row["figure_openid"].ToString();
				}
				if(row["figure_title"]!=null)
				{
					model.figure_title=row["figure_title"].ToString();
				}
				if(row["figure_category"]!=null)
				{
					model.figure_category=row["figure_category"].ToString();
				}
				if(row["figure_classify"]!=null)
				{
					model.figure_classify=row["figure_classify"].ToString();
				}
				if(row["figure_sellprice"]!=null && row["figure_sellprice"].ToString()!="")
				{
					model.figure_sellprice=decimal.Parse(row["figure_sellprice"].ToString());
				}
				if(row["figure_introduce"]!=null)
				{
					model.figure_introduce=row["figure_introduce"].ToString();
				}
				if(row["figure_condition"]!=null)
				{
					model.figure_condition=row["figure_condition"].ToString();
				}
				if(row["figure_time"]!=null && row["figure_time"].ToString()!="")
				{
					model.figure_time=DateTime.Parse(row["figure_time"].ToString());
				}
				if(row["figure_state"]!=null && row["figure_state"].ToString()!="")
				{
					model.figure_state=int.Parse(row["figure_state"].ToString());
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
			strSql.Append("select figure_id,figure_hyid,figure_openid,figure_title,figure_category,figure_classify,figure_sellprice,figure_introduce,figure_condition,figure_time,figure_state ");
			strSql.Append(" FROM tb_figure ");
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
			strSql.Append("select count(1) FROM tb_figure ");
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
				strSql.Append("order by T.figure_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_figure T ");
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
			parameters[0].Value = "tb_figure";
			parameters[1].Value = "figure_id";
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

