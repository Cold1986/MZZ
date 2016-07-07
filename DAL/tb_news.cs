using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_news
	/// </summary>
	public partial class tb_news
	{
		public tb_news()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("news_id", "tb_news"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int news_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_news");
			strSql.Append(" where news_id=@news_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@news_id", MySqlDbType.Int32)
			};
			parameters[0].Value = news_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_news model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_news(");
			strSql.Append("news_category,news_title,news_introduce,news_text,news_relative_path,news_absolute_path,news_recom,news_top,news_time,news_remarks)");
			strSql.Append(" values (");
			strSql.Append("@news_category,@news_title,@news_introduce,@news_text,@news_relative_path,@news_absolute_path,@news_recom,@news_top,@news_time,@news_remarks)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@news_category", MySqlDbType.VarChar,50),
					new MySqlParameter("@news_title", MySqlDbType.VarChar,100),
					new MySqlParameter("@news_introduce", MySqlDbType.VarChar,255),
					new MySqlParameter("@news_text", MySqlDbType.Text),
					new MySqlParameter("@news_relative_path", MySqlDbType.VarChar,255),
					new MySqlParameter("@news_absolute_path", MySqlDbType.VarChar,255),
					new MySqlParameter("@news_recom", MySqlDbType.Int32,11),
					new MySqlParameter("@news_top", MySqlDbType.Int32,11),
					new MySqlParameter("@news_time", MySqlDbType.DateTime),
					new MySqlParameter("@news_remarks", MySqlDbType.Text)};
			parameters[0].Value = model.news_category;
			parameters[1].Value = model.news_title;
			parameters[2].Value = model.news_introduce;
			parameters[3].Value = model.news_text;
			parameters[4].Value = model.news_relative_path;
			parameters[5].Value = model.news_absolute_path;
			parameters[6].Value = model.news_recom;
			parameters[7].Value = model.news_top;
			parameters[8].Value = model.news_time;
			parameters[9].Value = model.news_remarks;

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
		public bool Update(MZZ.Model.tb_news model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_news set ");
			strSql.Append("news_category=@news_category,");
			strSql.Append("news_title=@news_title,");
			strSql.Append("news_introduce=@news_introduce,");
			strSql.Append("news_text=@news_text,");
			strSql.Append("news_relative_path=@news_relative_path,");
			strSql.Append("news_absolute_path=@news_absolute_path,");
			strSql.Append("news_recom=@news_recom,");
			strSql.Append("news_top=@news_top,");
			strSql.Append("news_time=@news_time,");
			strSql.Append("news_remarks=@news_remarks");
			strSql.Append(" where news_id=@news_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@news_category", MySqlDbType.VarChar,50),
					new MySqlParameter("@news_title", MySqlDbType.VarChar,100),
					new MySqlParameter("@news_introduce", MySqlDbType.VarChar,255),
					new MySqlParameter("@news_text", MySqlDbType.Text),
					new MySqlParameter("@news_relative_path", MySqlDbType.VarChar,255),
					new MySqlParameter("@news_absolute_path", MySqlDbType.VarChar,255),
					new MySqlParameter("@news_recom", MySqlDbType.Int32,11),
					new MySqlParameter("@news_top", MySqlDbType.Int32,11),
					new MySqlParameter("@news_time", MySqlDbType.DateTime),
					new MySqlParameter("@news_remarks", MySqlDbType.Text),
					new MySqlParameter("@news_id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.news_category;
			parameters[1].Value = model.news_title;
			parameters[2].Value = model.news_introduce;
			parameters[3].Value = model.news_text;
			parameters[4].Value = model.news_relative_path;
			parameters[5].Value = model.news_absolute_path;
			parameters[6].Value = model.news_recom;
			parameters[7].Value = model.news_top;
			parameters[8].Value = model.news_time;
			parameters[9].Value = model.news_remarks;
			parameters[10].Value = model.news_id;

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
		public bool Delete(int news_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_news ");
			strSql.Append(" where news_id=@news_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@news_id", MySqlDbType.Int32)
			};
			parameters[0].Value = news_id;

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
		public bool DeleteList(string news_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_news ");
			strSql.Append(" where news_id in ("+news_idlist + ")  ");
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
		public MZZ.Model.tb_news GetModel(int news_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select news_id,news_category,news_title,news_introduce,news_text,news_relative_path,news_absolute_path,news_recom,news_top,news_time,news_remarks from tb_news ");
			strSql.Append(" where news_id=@news_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@news_id", MySqlDbType.Int32)
			};
			parameters[0].Value = news_id;

			MZZ.Model.tb_news model=new MZZ.Model.tb_news();
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
		public MZZ.Model.tb_news DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_news model=new MZZ.Model.tb_news();
			if (row != null)
			{
				if(row["news_id"]!=null && row["news_id"].ToString()!="")
				{
					model.news_id=int.Parse(row["news_id"].ToString());
				}
				if(row["news_category"]!=null)
				{
					model.news_category=row["news_category"].ToString();
				}
				if(row["news_title"]!=null)
				{
					model.news_title=row["news_title"].ToString();
				}
				if(row["news_introduce"]!=null)
				{
					model.news_introduce=row["news_introduce"].ToString();
				}
				if(row["news_text"]!=null)
				{
					model.news_text=row["news_text"].ToString();
				}
				if(row["news_relative_path"]!=null)
				{
					model.news_relative_path=row["news_relative_path"].ToString();
				}
				if(row["news_absolute_path"]!=null)
				{
					model.news_absolute_path=row["news_absolute_path"].ToString();
				}
				if(row["news_recom"]!=null && row["news_recom"].ToString()!="")
				{
					model.news_recom=int.Parse(row["news_recom"].ToString());
				}
				if(row["news_top"]!=null && row["news_top"].ToString()!="")
				{
					model.news_top=int.Parse(row["news_top"].ToString());
				}
				if(row["news_time"]!=null && row["news_time"].ToString()!="")
				{
					model.news_time=DateTime.Parse(row["news_time"].ToString());
				}
				if(row["news_remarks"]!=null)
				{
					model.news_remarks=row["news_remarks"].ToString();
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
			strSql.Append("select news_id,news_category,news_title,news_introduce,news_text,news_relative_path,news_absolute_path,news_recom,news_top,news_time,news_remarks ");
			strSql.Append(" FROM tb_news ");
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
			strSql.Append("select count(1) FROM tb_news ");
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
				strSql.Append("order by T.news_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_news T ");
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
			parameters[0].Value = "tb_news";
			parameters[1].Value = "news_id";
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

