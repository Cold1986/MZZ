using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_article
	/// </summary>
	public partial class tb_article
	{
		public tb_article()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("article_id", "tb_article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int article_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_article");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_id", MySqlDbType.Int32)
			};
			parameters[0].Value = article_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_article(");
			strSql.Append("article_type,article_content,article_imgs,article_barrage,article_user_id,article_time,article_statu)");
			strSql.Append(" values (");
			strSql.Append("@article_type,@article_content,@article_imgs,@article_barrage,@article_user_id,@article_time,@article_statu)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_type", MySqlDbType.Int32,4),
					new MySqlParameter("@article_content", MySqlDbType.VarChar,255),
					new MySqlParameter("@article_imgs", MySqlDbType.VarChar,2048),
					new MySqlParameter("@article_barrage", MySqlDbType.Int32,1),
					new MySqlParameter("@article_user_id", MySqlDbType.Int32,10),
					new MySqlParameter("@article_time", MySqlDbType.Int32,10),
					new MySqlParameter("@article_statu", MySqlDbType.Int32,3)};
			parameters[0].Value = model.article_type;
			parameters[1].Value = model.article_content;
			parameters[2].Value = model.article_imgs;
			parameters[3].Value = model.article_barrage;
			parameters[4].Value = model.article_user_id;
			parameters[5].Value = model.article_time;
			parameters[6].Value = model.article_statu;

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
		public bool Update(MZZ.Model.tb_article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_article set ");
			strSql.Append("article_type=@article_type,");
			strSql.Append("article_content=@article_content,");
			strSql.Append("article_imgs=@article_imgs,");
			strSql.Append("article_barrage=@article_barrage,");
			strSql.Append("article_user_id=@article_user_id,");
			strSql.Append("article_time=@article_time,");
			strSql.Append("article_statu=@article_statu");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_type", MySqlDbType.Int32,4),
					new MySqlParameter("@article_content", MySqlDbType.VarChar,255),
					new MySqlParameter("@article_imgs", MySqlDbType.VarChar,2048),
					new MySqlParameter("@article_barrage", MySqlDbType.Int32,1),
					new MySqlParameter("@article_user_id", MySqlDbType.Int32,10),
					new MySqlParameter("@article_time", MySqlDbType.Int32,10),
					new MySqlParameter("@article_statu", MySqlDbType.Int32,3),
					new MySqlParameter("@article_id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.article_type;
			parameters[1].Value = model.article_content;
			parameters[2].Value = model.article_imgs;
			parameters[3].Value = model.article_barrage;
			parameters[4].Value = model.article_user_id;
			parameters[5].Value = model.article_time;
			parameters[6].Value = model.article_statu;
			parameters[7].Value = model.article_id;

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
		public bool Delete(int article_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_article ");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_id", MySqlDbType.Int32)
			};
			parameters[0].Value = article_id;

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
		public bool DeleteList(string article_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_article ");
			strSql.Append(" where article_id in ("+article_idlist + ")  ");
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
		public MZZ.Model.tb_article GetModel(int article_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select article_id,article_type,article_content,article_imgs,article_barrage,article_user_id,article_time,article_statu from tb_article ");
			strSql.Append(" where article_id=@article_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@article_id", MySqlDbType.Int32)
			};
			parameters[0].Value = article_id;

			MZZ.Model.tb_article model=new MZZ.Model.tb_article();
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
		public MZZ.Model.tb_article DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_article model=new MZZ.Model.tb_article();
			if (row != null)
			{
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["article_type"]!=null && row["article_type"].ToString()!="")
				{
					model.article_type=int.Parse(row["article_type"].ToString());
				}
				if(row["article_content"]!=null)
				{
					model.article_content=row["article_content"].ToString();
				}
				if(row["article_imgs"]!=null)
				{
					model.article_imgs=row["article_imgs"].ToString();
				}
				if(row["article_barrage"]!=null && row["article_barrage"].ToString()!="")
				{
					model.article_barrage=int.Parse(row["article_barrage"].ToString());
				}
				if(row["article_user_id"]!=null && row["article_user_id"].ToString()!="")
				{
					model.article_user_id=int.Parse(row["article_user_id"].ToString());
				}
				if(row["article_time"]!=null && row["article_time"].ToString()!="")
				{
					model.article_time=int.Parse(row["article_time"].ToString());
				}
				if(row["article_statu"]!=null && row["article_statu"].ToString()!="")
				{
					model.article_statu=int.Parse(row["article_statu"].ToString());
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
			strSql.Append("select article_id,article_type,article_content,article_imgs,article_barrage,article_user_id,article_time,article_statu ");
			strSql.Append(" FROM tb_article ");
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
			strSql.Append("select count(1) FROM tb_article ");
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
				strSql.Append("order by T.article_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_article T ");
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
			parameters[0].Value = "tb_article";
			parameters[1].Value = "article_id";
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

