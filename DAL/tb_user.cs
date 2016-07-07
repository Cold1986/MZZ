using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_user
	/// </summary>
	public partial class tb_user
	{
		public tb_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("user_id", "tb_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_user");
			strSql.Append(" where user_id=@user_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32)
			};
			parameters[0].Value = user_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_user(");
			strSql.Append("user_phone,user_pass,user_integral,user_level,user_data,user_login_time,user_login_ip,user_create_time,user_create_ip,user_openid,user_nick_name,user_sex,user_city,user_country,user_province,user_language,user_head_img_url,user_sub_time,user_sub_scribe,user_up_openid,user_uopenid_time,user_status,user_hy_status,user_qr_code)");
			strSql.Append(" values (");
			strSql.Append("@user_phone,@user_pass,@user_integral,@user_level,@user_data,@user_login_time,@user_login_ip,@user_create_time,@user_create_ip,@user_openid,@user_nick_name,@user_sex,@user_city,@user_country,@user_province,@user_language,@user_head_img_url,@user_sub_time,@user_sub_scribe,@user_up_openid,@user_uopenid_time,@user_status,@user_hy_status,@user_qr_code)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_phone", MySqlDbType.VarChar,11),
					new MySqlParameter("@user_pass", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_integral", MySqlDbType.Int32,10),
					new MySqlParameter("@user_level", MySqlDbType.Int32,3),
					new MySqlParameter("@user_data", MySqlDbType.Text),
					new MySqlParameter("@user_login_time", MySqlDbType.Int32,10),
					new MySqlParameter("@user_login_ip", MySqlDbType.VarChar,15),
					new MySqlParameter("@user_create_time", MySqlDbType.Int32,11),
					new MySqlParameter("@user_create_ip", MySqlDbType.VarChar,15),
					new MySqlParameter("@user_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_nick_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_sex", MySqlDbType.Int32,11),
					new MySqlParameter("@user_city", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_country", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_province", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_language", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_head_img_url", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_sub_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_sub_scribe", MySqlDbType.Bit),
					new MySqlParameter("@user_up_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_uopenid_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_status", MySqlDbType.Int32,11),
					new MySqlParameter("@user_hy_status", MySqlDbType.Int32,11),
					new MySqlParameter("@user_qr_code", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.user_phone;
			parameters[1].Value = model.user_pass;
			parameters[2].Value = model.user_integral;
			parameters[3].Value = model.user_level;
			parameters[4].Value = model.user_data;
			parameters[5].Value = model.user_login_time;
			parameters[6].Value = model.user_login_ip;
			parameters[7].Value = model.user_create_time;
			parameters[8].Value = model.user_create_ip;
			parameters[9].Value = model.user_openid;
			parameters[10].Value = model.user_nick_name;
			parameters[11].Value = model.user_sex;
			parameters[12].Value = model.user_city;
			parameters[13].Value = model.user_country;
			parameters[14].Value = model.user_province;
			parameters[15].Value = model.user_language;
			parameters[16].Value = model.user_head_img_url;
			parameters[17].Value = model.user_sub_time;
			parameters[18].Value = model.user_sub_scribe;
			parameters[19].Value = model.user_up_openid;
			parameters[20].Value = model.user_uopenid_time;
			parameters[21].Value = model.user_status;
			parameters[22].Value = model.user_hy_status;
			parameters[23].Value = model.user_qr_code;

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
		public bool Update(MZZ.Model.tb_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_user set ");
			strSql.Append("user_phone=@user_phone,");
			strSql.Append("user_pass=@user_pass,");
			strSql.Append("user_integral=@user_integral,");
			strSql.Append("user_level=@user_level,");
			strSql.Append("user_data=@user_data,");
			strSql.Append("user_login_time=@user_login_time,");
			strSql.Append("user_login_ip=@user_login_ip,");
			strSql.Append("user_create_time=@user_create_time,");
			strSql.Append("user_create_ip=@user_create_ip,");
			strSql.Append("user_openid=@user_openid,");
			strSql.Append("user_nick_name=@user_nick_name,");
			strSql.Append("user_sex=@user_sex,");
			strSql.Append("user_city=@user_city,");
			strSql.Append("user_country=@user_country,");
			strSql.Append("user_province=@user_province,");
			strSql.Append("user_language=@user_language,");
			strSql.Append("user_head_img_url=@user_head_img_url,");
			strSql.Append("user_sub_time=@user_sub_time,");
			strSql.Append("user_sub_scribe=@user_sub_scribe,");
			strSql.Append("user_up_openid=@user_up_openid,");
			strSql.Append("user_uopenid_time=@user_uopenid_time,");
			strSql.Append("user_status=@user_status,");
			strSql.Append("user_hy_status=@user_hy_status,");
			strSql.Append("user_qr_code=@user_qr_code");
			strSql.Append(" where user_id=@user_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_phone", MySqlDbType.VarChar,11),
					new MySqlParameter("@user_pass", MySqlDbType.VarChar,32),
					new MySqlParameter("@user_integral", MySqlDbType.Int32,10),
					new MySqlParameter("@user_level", MySqlDbType.Int32,3),
					new MySqlParameter("@user_data", MySqlDbType.Text),
					new MySqlParameter("@user_login_time", MySqlDbType.Int32,10),
					new MySqlParameter("@user_login_ip", MySqlDbType.VarChar,15),
					new MySqlParameter("@user_create_time", MySqlDbType.Int32,11),
					new MySqlParameter("@user_create_ip", MySqlDbType.VarChar,15),
					new MySqlParameter("@user_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_nick_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_sex", MySqlDbType.Int32,11),
					new MySqlParameter("@user_city", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_country", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_province", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_language", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_head_img_url", MySqlDbType.VarChar,20),
					new MySqlParameter("@user_sub_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_sub_scribe", MySqlDbType.Bit),
					new MySqlParameter("@user_up_openid", MySqlDbType.VarChar,50),
					new MySqlParameter("@user_uopenid_time", MySqlDbType.DateTime),
					new MySqlParameter("@user_status", MySqlDbType.Int32,11),
					new MySqlParameter("@user_hy_status", MySqlDbType.Int32,11),
					new MySqlParameter("@user_qr_code", MySqlDbType.VarChar,255),
					new MySqlParameter("@user_id", MySqlDbType.Int32,10)};
			parameters[0].Value = model.user_phone;
			parameters[1].Value = model.user_pass;
			parameters[2].Value = model.user_integral;
			parameters[3].Value = model.user_level;
			parameters[4].Value = model.user_data;
			parameters[5].Value = model.user_login_time;
			parameters[6].Value = model.user_login_ip;
			parameters[7].Value = model.user_create_time;
			parameters[8].Value = model.user_create_ip;
			parameters[9].Value = model.user_openid;
			parameters[10].Value = model.user_nick_name;
			parameters[11].Value = model.user_sex;
			parameters[12].Value = model.user_city;
			parameters[13].Value = model.user_country;
			parameters[14].Value = model.user_province;
			parameters[15].Value = model.user_language;
			parameters[16].Value = model.user_head_img_url;
			parameters[17].Value = model.user_sub_time;
			parameters[18].Value = model.user_sub_scribe;
			parameters[19].Value = model.user_up_openid;
			parameters[20].Value = model.user_uopenid_time;
			parameters[21].Value = model.user_status;
			parameters[22].Value = model.user_hy_status;
			parameters[23].Value = model.user_qr_code;
			parameters[24].Value = model.user_id;

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
		public bool Delete(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user ");
			strSql.Append(" where user_id=@user_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32)
			};
			parameters[0].Value = user_id;

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
		public bool DeleteList(string user_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_user ");
			strSql.Append(" where user_id in ("+user_idlist + ")  ");
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
		public MZZ.Model.tb_user GetModel(int user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select user_id,user_phone,user_pass,user_integral,user_level,user_data,user_login_time,user_login_ip,user_create_time,user_create_ip,user_openid,user_nick_name,user_sex,user_city,user_country,user_province,user_language,user_head_img_url,user_sub_time,user_sub_scribe,user_up_openid,user_uopenid_time,user_status,user_hy_status,user_qr_code from tb_user ");
			strSql.Append(" where user_id=@user_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@user_id", MySqlDbType.Int32)
			};
			parameters[0].Value = user_id;

			MZZ.Model.tb_user model=new MZZ.Model.tb_user();
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
		public MZZ.Model.tb_user DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_user model=new MZZ.Model.tb_user();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=int.Parse(row["user_id"].ToString());
				}
				if(row["user_phone"]!=null)
				{
					model.user_phone=row["user_phone"].ToString();
				}
				if(row["user_pass"]!=null)
				{
					model.user_pass=row["user_pass"].ToString();
				}
				if(row["user_integral"]!=null && row["user_integral"].ToString()!="")
				{
					model.user_integral=int.Parse(row["user_integral"].ToString());
				}
				if(row["user_level"]!=null && row["user_level"].ToString()!="")
				{
					model.user_level=int.Parse(row["user_level"].ToString());
				}
				if(row["user_data"]!=null)
				{
					model.user_data=row["user_data"].ToString();
				}
				if(row["user_login_time"]!=null && row["user_login_time"].ToString()!="")
				{
					model.user_login_time=int.Parse(row["user_login_time"].ToString());
				}
				if(row["user_login_ip"]!=null)
				{
					model.user_login_ip=row["user_login_ip"].ToString();
				}
				if(row["user_create_time"]!=null && row["user_create_time"].ToString()!="")
				{
					model.user_create_time=int.Parse(row["user_create_time"].ToString());
				}
				if(row["user_create_ip"]!=null)
				{
					model.user_create_ip=row["user_create_ip"].ToString();
				}
				if(row["user_openid"]!=null)
				{
					model.user_openid=row["user_openid"].ToString();
				}
				if(row["user_nick_name"]!=null)
				{
					model.user_nick_name=row["user_nick_name"].ToString();
				}
				if(row["user_sex"]!=null && row["user_sex"].ToString()!="")
				{
					model.user_sex=int.Parse(row["user_sex"].ToString());
				}
				if(row["user_city"]!=null)
				{
					model.user_city=row["user_city"].ToString();
				}
				if(row["user_country"]!=null)
				{
					model.user_country=row["user_country"].ToString();
				}
				if(row["user_province"]!=null)
				{
					model.user_province=row["user_province"].ToString();
				}
				if(row["user_language"]!=null)
				{
					model.user_language=row["user_language"].ToString();
				}
				if(row["user_head_img_url"]!=null)
				{
					model.user_head_img_url=row["user_head_img_url"].ToString();
				}
				if(row["user_sub_time"]!=null && row["user_sub_time"].ToString()!="")
				{
					model.user_sub_time=DateTime.Parse(row["user_sub_time"].ToString());
				}
				if(row["user_sub_scribe"]!=null && row["user_sub_scribe"].ToString()!="")
				{
					if((row["user_sub_scribe"].ToString()=="1")||(row["user_sub_scribe"].ToString().ToLower()=="true"))
					{
						model.user_sub_scribe=true;
					}
					else
					{
						model.user_sub_scribe=false;
					}
				}
				if(row["user_up_openid"]!=null)
				{
					model.user_up_openid=row["user_up_openid"].ToString();
				}
				if(row["user_uopenid_time"]!=null && row["user_uopenid_time"].ToString()!="")
				{
					model.user_uopenid_time=DateTime.Parse(row["user_uopenid_time"].ToString());
				}
				if(row["user_status"]!=null && row["user_status"].ToString()!="")
				{
					model.user_status=int.Parse(row["user_status"].ToString());
				}
				if(row["user_hy_status"]!=null && row["user_hy_status"].ToString()!="")
				{
					model.user_hy_status=int.Parse(row["user_hy_status"].ToString());
				}
				if(row["user_qr_code"]!=null)
				{
					model.user_qr_code=row["user_qr_code"].ToString();
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
			strSql.Append("select user_id,user_phone,user_pass,user_integral,user_level,user_data,user_login_time,user_login_ip,user_create_time,user_create_ip,user_openid,user_nick_name,user_sex,user_city,user_country,user_province,user_language,user_head_img_url,user_sub_time,user_sub_scribe,user_up_openid,user_uopenid_time,user_status,user_hy_status,user_qr_code ");
			strSql.Append(" FROM tb_user ");
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
			strSql.Append("select count(1) FROM tb_user ");
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
				strSql.Append("order by T.user_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_user T ");
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
			parameters[0].Value = "tb_user";
			parameters[1].Value = "user_id";
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

