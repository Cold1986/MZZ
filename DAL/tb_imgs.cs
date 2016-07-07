using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_imgs
	/// </summary>
	public partial class tb_imgs
	{
		public tb_imgs()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("imgs_id", "tb_imgs"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int imgs_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_imgs");
			strSql.Append(" where imgs_id=@imgs_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@imgs_id", MySqlDbType.Int32)
			};
			parameters[0].Value = imgs_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_imgs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_imgs(");
			strSql.Append("imgs_path,imgs_etag,imgs_path_md5,imgs_mime,imgs_height,imgs_width,imgs_size,imgs_quote,imgs_score,imgs_score_tip,imgs_score_task,imgs_time)");
			strSql.Append(" values (");
			strSql.Append("@imgs_path,@imgs_etag,@imgs_path_md5,@imgs_mime,@imgs_height,@imgs_width,@imgs_size,@imgs_quote,@imgs_score,@imgs_score_tip,@imgs_score_task,@imgs_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@imgs_path", MySqlDbType.VarChar,255),
					new MySqlParameter("@imgs_etag", MySqlDbType.VarChar,32),
					new MySqlParameter("@imgs_path_md5", MySqlDbType.VarChar,32),
					new MySqlParameter("@imgs_mime", MySqlDbType.VarChar,128),
					new MySqlParameter("@imgs_height", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_width", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_size", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_quote", MySqlDbType.Int32,10),
					new MySqlParameter("@imgs_score", MySqlDbType.Int32,3),
					new MySqlParameter("@imgs_score_tip", MySqlDbType.Int32,3),
					new MySqlParameter("@imgs_score_task", MySqlDbType.VarChar,128),
					new MySqlParameter("@imgs_time", MySqlDbType.Int32,11)};
			parameters[0].Value = model.imgs_path;
			parameters[1].Value = model.imgs_etag;
			parameters[2].Value = model.imgs_path_md5;
			parameters[3].Value = model.imgs_mime;
			parameters[4].Value = model.imgs_height;
			parameters[5].Value = model.imgs_width;
			parameters[6].Value = model.imgs_size;
			parameters[7].Value = model.imgs_quote;
			parameters[8].Value = model.imgs_score;
			parameters[9].Value = model.imgs_score_tip;
			parameters[10].Value = model.imgs_score_task;
			parameters[11].Value = model.imgs_time;

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
		public bool Update(MZZ.Model.tb_imgs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_imgs set ");
			strSql.Append("imgs_path=@imgs_path,");
			strSql.Append("imgs_etag=@imgs_etag,");
			strSql.Append("imgs_path_md5=@imgs_path_md5,");
			strSql.Append("imgs_mime=@imgs_mime,");
			strSql.Append("imgs_height=@imgs_height,");
			strSql.Append("imgs_width=@imgs_width,");
			strSql.Append("imgs_size=@imgs_size,");
			strSql.Append("imgs_quote=@imgs_quote,");
			strSql.Append("imgs_score=@imgs_score,");
			strSql.Append("imgs_score_tip=@imgs_score_tip,");
			strSql.Append("imgs_score_task=@imgs_score_task,");
			strSql.Append("imgs_time=@imgs_time");
			strSql.Append(" where imgs_id=@imgs_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@imgs_path", MySqlDbType.VarChar,255),
					new MySqlParameter("@imgs_etag", MySqlDbType.VarChar,32),
					new MySqlParameter("@imgs_path_md5", MySqlDbType.VarChar,32),
					new MySqlParameter("@imgs_mime", MySqlDbType.VarChar,128),
					new MySqlParameter("@imgs_height", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_width", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_size", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_quote", MySqlDbType.Int32,10),
					new MySqlParameter("@imgs_score", MySqlDbType.Int32,3),
					new MySqlParameter("@imgs_score_tip", MySqlDbType.Int32,3),
					new MySqlParameter("@imgs_score_task", MySqlDbType.VarChar,128),
					new MySqlParameter("@imgs_time", MySqlDbType.Int32,11),
					new MySqlParameter("@imgs_id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.imgs_path;
			parameters[1].Value = model.imgs_etag;
			parameters[2].Value = model.imgs_path_md5;
			parameters[3].Value = model.imgs_mime;
			parameters[4].Value = model.imgs_height;
			parameters[5].Value = model.imgs_width;
			parameters[6].Value = model.imgs_size;
			parameters[7].Value = model.imgs_quote;
			parameters[8].Value = model.imgs_score;
			parameters[9].Value = model.imgs_score_tip;
			parameters[10].Value = model.imgs_score_task;
			parameters[11].Value = model.imgs_time;
			parameters[12].Value = model.imgs_id;

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
		public bool Delete(int imgs_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_imgs ");
			strSql.Append(" where imgs_id=@imgs_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@imgs_id", MySqlDbType.Int32)
			};
			parameters[0].Value = imgs_id;

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
		public bool DeleteList(string imgs_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_imgs ");
			strSql.Append(" where imgs_id in ("+imgs_idlist + ")  ");
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
		public MZZ.Model.tb_imgs GetModel(int imgs_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select imgs_id,imgs_path,imgs_etag,imgs_path_md5,imgs_mime,imgs_height,imgs_width,imgs_size,imgs_quote,imgs_score,imgs_score_tip,imgs_score_task,imgs_time from tb_imgs ");
			strSql.Append(" where imgs_id=@imgs_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@imgs_id", MySqlDbType.Int32)
			};
			parameters[0].Value = imgs_id;

			MZZ.Model.tb_imgs model=new MZZ.Model.tb_imgs();
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
		public MZZ.Model.tb_imgs DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_imgs model=new MZZ.Model.tb_imgs();
			if (row != null)
			{
				if(row["imgs_id"]!=null && row["imgs_id"].ToString()!="")
				{
					model.imgs_id=int.Parse(row["imgs_id"].ToString());
				}
				if(row["imgs_path"]!=null)
				{
					model.imgs_path=row["imgs_path"].ToString();
				}
				if(row["imgs_etag"]!=null)
				{
					model.imgs_etag=row["imgs_etag"].ToString();
				}
				if(row["imgs_path_md5"]!=null)
				{
					model.imgs_path_md5=row["imgs_path_md5"].ToString();
				}
				if(row["imgs_mime"]!=null)
				{
					model.imgs_mime=row["imgs_mime"].ToString();
				}
				if(row["imgs_height"]!=null && row["imgs_height"].ToString()!="")
				{
					model.imgs_height=int.Parse(row["imgs_height"].ToString());
				}
				if(row["imgs_width"]!=null && row["imgs_width"].ToString()!="")
				{
					model.imgs_width=int.Parse(row["imgs_width"].ToString());
				}
				if(row["imgs_size"]!=null && row["imgs_size"].ToString()!="")
				{
					model.imgs_size=int.Parse(row["imgs_size"].ToString());
				}
				if(row["imgs_quote"]!=null && row["imgs_quote"].ToString()!="")
				{
					model.imgs_quote=int.Parse(row["imgs_quote"].ToString());
				}
				if(row["imgs_score"]!=null && row["imgs_score"].ToString()!="")
				{
					model.imgs_score=int.Parse(row["imgs_score"].ToString());
				}
				if(row["imgs_score_tip"]!=null && row["imgs_score_tip"].ToString()!="")
				{
					model.imgs_score_tip=int.Parse(row["imgs_score_tip"].ToString());
				}
				if(row["imgs_score_task"]!=null)
				{
					model.imgs_score_task=row["imgs_score_task"].ToString();
				}
				if(row["imgs_time"]!=null && row["imgs_time"].ToString()!="")
				{
					model.imgs_time=int.Parse(row["imgs_time"].ToString());
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
			strSql.Append("select imgs_id,imgs_path,imgs_etag,imgs_path_md5,imgs_mime,imgs_height,imgs_width,imgs_size,imgs_quote,imgs_score,imgs_score_tip,imgs_score_task,imgs_time ");
			strSql.Append(" FROM tb_imgs ");
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
			strSql.Append("select count(1) FROM tb_imgs ");
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
				strSql.Append("order by T.imgs_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_imgs T ");
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
			parameters[0].Value = "tb_imgs";
			parameters[1].Value = "imgs_id";
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

