using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_code
	/// </summary>
	public partial class tb_code
	{
		public tb_code()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("code_id", "tb_code"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int code_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_code");
			strSql.Append(" where code_id=@code_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code_id", MySqlDbType.Int32)
			};
			parameters[0].Value = code_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_code model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_code(");
			strSql.Append("code_code,code_userid,code_openid,code_prizeid,code_prize_name,code_main_img,code_remark,code_create_time,code_status)");
			strSql.Append(" values (");
			strSql.Append("@code_code,@code_userid,@code_openid,@code_prizeid,@code_prize_name,@code_main_img,@code_remark,@code_create_time,@code_status)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code_code", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_userid", MySqlDbType.Int32,11),
					new MySqlParameter("@code_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_prizeid", MySqlDbType.Int32,11),
					new MySqlParameter("@code_prize_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_main_img", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@code_create_time", MySqlDbType.DateTime),
					new MySqlParameter("@code_status", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code_code;
			parameters[1].Value = model.code_userid;
			parameters[2].Value = model.code_openid;
			parameters[3].Value = model.code_prizeid;
			parameters[4].Value = model.code_prize_name;
			parameters[5].Value = model.code_main_img;
			parameters[6].Value = model.code_remark;
			parameters[7].Value = model.code_create_time;
			parameters[8].Value = model.code_status;

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
		public bool Update(MZZ.Model.tb_code model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_code set ");
			strSql.Append("code_code=@code_code,");
			strSql.Append("code_userid=@code_userid,");
			strSql.Append("code_openid=@code_openid,");
			strSql.Append("code_prizeid=@code_prizeid,");
			strSql.Append("code_prize_name=@code_prize_name,");
			strSql.Append("code_main_img=@code_main_img,");
			strSql.Append("code_remark=@code_remark,");
			strSql.Append("code_create_time=@code_create_time,");
			strSql.Append("code_status=@code_status");
			strSql.Append(" where code_id=@code_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code_code", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_userid", MySqlDbType.Int32,11),
					new MySqlParameter("@code_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_prizeid", MySqlDbType.Int32,11),
					new MySqlParameter("@code_prize_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_main_img", MySqlDbType.VarChar,50),
					new MySqlParameter("@code_remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@code_create_time", MySqlDbType.DateTime),
					new MySqlParameter("@code_status", MySqlDbType.Int32,11),
					new MySqlParameter("@code_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code_code;
			parameters[1].Value = model.code_userid;
			parameters[2].Value = model.code_openid;
			parameters[3].Value = model.code_prizeid;
			parameters[4].Value = model.code_prize_name;
			parameters[5].Value = model.code_main_img;
			parameters[6].Value = model.code_remark;
			parameters[7].Value = model.code_create_time;
			parameters[8].Value = model.code_status;
			parameters[9].Value = model.code_id;

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
		public bool Delete(int code_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_code ");
			strSql.Append(" where code_id=@code_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code_id", MySqlDbType.Int32)
			};
			parameters[0].Value = code_id;

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
		public bool DeleteList(string code_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_code ");
			strSql.Append(" where code_id in ("+code_idlist + ")  ");
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
		public MZZ.Model.tb_code GetModel(int code_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select code_id,code_code,code_userid,code_openid,code_prizeid,code_prize_name,code_main_img,code_remark,code_create_time,code_status from tb_code ");
			strSql.Append(" where code_id=@code_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code_id", MySqlDbType.Int32)
			};
			parameters[0].Value = code_id;

			MZZ.Model.tb_code model=new MZZ.Model.tb_code();
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
		public MZZ.Model.tb_code DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_code model=new MZZ.Model.tb_code();
			if (row != null)
			{
				if(row["code_id"]!=null && row["code_id"].ToString()!="")
				{
					model.code_id=int.Parse(row["code_id"].ToString());
				}
				if(row["code_code"]!=null)
				{
					model.code_code=row["code_code"].ToString();
				}
				if(row["code_userid"]!=null && row["code_userid"].ToString()!="")
				{
					model.code_userid=int.Parse(row["code_userid"].ToString());
				}
				if(row["code_openid"]!=null)
				{
					model.code_openid=row["code_openid"].ToString();
				}
				if(row["code_prizeid"]!=null && row["code_prizeid"].ToString()!="")
				{
					model.code_prizeid=int.Parse(row["code_prizeid"].ToString());
				}
				if(row["code_prize_name"]!=null)
				{
					model.code_prize_name=row["code_prize_name"].ToString();
				}
				if(row["code_main_img"]!=null)
				{
					model.code_main_img=row["code_main_img"].ToString();
				}
				if(row["code_remark"]!=null)
				{
					model.code_remark=row["code_remark"].ToString();
				}
				if(row["code_create_time"]!=null && row["code_create_time"].ToString()!="")
				{
					model.code_create_time=DateTime.Parse(row["code_create_time"].ToString());
				}
				if(row["code_status"]!=null && row["code_status"].ToString()!="")
				{
					model.code_status=int.Parse(row["code_status"].ToString());
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
			strSql.Append("select code_id,code_code,code_userid,code_openid,code_prizeid,code_prize_name,code_main_img,code_remark,code_create_time,code_status ");
			strSql.Append(" FROM tb_code ");
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
			strSql.Append("select count(1) FROM tb_code ");
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
				strSql.Append("order by T.code_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_code T ");
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
			parameters[0].Value = "tb_code";
			parameters[1].Value = "code_id";
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

