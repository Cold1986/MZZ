using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_prizes
	/// </summary>
	public partial class tb_prizes
	{
		public tb_prizes()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("prizes_id", "tb_prizes"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int prizes_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_prizes");
			strSql.Append(" where prizes_id=@prizes_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@prizes_id", MySqlDbType.Int32)
			};
			parameters[0].Value = prizes_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_prizes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_prizes(");
			strSql.Append("prizes_prize_name,prizes_quantity,prizes_main_img,prizes_angle,prizes_probability,prizes_remark,prizes_create_time,prizes_status)");
			strSql.Append(" values (");
			strSql.Append("@prizes_prize_name,@prizes_quantity,@prizes_main_img,@prizes_angle,@prizes_probability,@prizes_remark,@prizes_create_time,@prizes_status)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@prizes_prize_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_quantity", MySqlDbType.Int32,11),
					new MySqlParameter("@prizes_main_img", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_angle", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_probability", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_remark", MySqlDbType.Text),
					new MySqlParameter("@prizes_create_time", MySqlDbType.DateTime),
					new MySqlParameter("@prizes_status", MySqlDbType.Int32,11)};
			parameters[0].Value = model.prizes_prize_name;
			parameters[1].Value = model.prizes_quantity;
			parameters[2].Value = model.prizes_main_img;
			parameters[3].Value = model.prizes_angle;
			parameters[4].Value = model.prizes_probability;
			parameters[5].Value = model.prizes_remark;
			parameters[6].Value = model.prizes_create_time;
			parameters[7].Value = model.prizes_status;

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
		public bool Update(MZZ.Model.tb_prizes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_prizes set ");
			strSql.Append("prizes_prize_name=@prizes_prize_name,");
			strSql.Append("prizes_quantity=@prizes_quantity,");
			strSql.Append("prizes_main_img=@prizes_main_img,");
			strSql.Append("prizes_angle=@prizes_angle,");
			strSql.Append("prizes_probability=@prizes_probability,");
			strSql.Append("prizes_remark=@prizes_remark,");
			strSql.Append("prizes_create_time=@prizes_create_time,");
			strSql.Append("prizes_status=@prizes_status");
			strSql.Append(" where prizes_id=@prizes_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@prizes_prize_name", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_quantity", MySqlDbType.Int32,11),
					new MySqlParameter("@prizes_main_img", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_angle", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_probability", MySqlDbType.VarChar,50),
					new MySqlParameter("@prizes_remark", MySqlDbType.Text),
					new MySqlParameter("@prizes_create_time", MySqlDbType.DateTime),
					new MySqlParameter("@prizes_status", MySqlDbType.Int32,11),
					new MySqlParameter("@prizes_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.prizes_prize_name;
			parameters[1].Value = model.prizes_quantity;
			parameters[2].Value = model.prizes_main_img;
			parameters[3].Value = model.prizes_angle;
			parameters[4].Value = model.prizes_probability;
			parameters[5].Value = model.prizes_remark;
			parameters[6].Value = model.prizes_create_time;
			parameters[7].Value = model.prizes_status;
			parameters[8].Value = model.prizes_id;

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
		public bool Delete(int prizes_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_prizes ");
			strSql.Append(" where prizes_id=@prizes_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@prizes_id", MySqlDbType.Int32)
			};
			parameters[0].Value = prizes_id;

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
		public bool DeleteList(string prizes_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_prizes ");
			strSql.Append(" where prizes_id in ("+prizes_idlist + ")  ");
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
		public MZZ.Model.tb_prizes GetModel(int prizes_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select prizes_id,prizes_prize_name,prizes_quantity,prizes_main_img,prizes_angle,prizes_probability,prizes_remark,prizes_create_time,prizes_status from tb_prizes ");
			strSql.Append(" where prizes_id=@prizes_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@prizes_id", MySqlDbType.Int32)
			};
			parameters[0].Value = prizes_id;

			MZZ.Model.tb_prizes model=new MZZ.Model.tb_prizes();
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
		public MZZ.Model.tb_prizes DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_prizes model=new MZZ.Model.tb_prizes();
			if (row != null)
			{
				if(row["prizes_id"]!=null && row["prizes_id"].ToString()!="")
				{
					model.prizes_id=int.Parse(row["prizes_id"].ToString());
				}
				if(row["prizes_prize_name"]!=null)
				{
					model.prizes_prize_name=row["prizes_prize_name"].ToString();
				}
				if(row["prizes_quantity"]!=null && row["prizes_quantity"].ToString()!="")
				{
					model.prizes_quantity=int.Parse(row["prizes_quantity"].ToString());
				}
				if(row["prizes_main_img"]!=null)
				{
					model.prizes_main_img=row["prizes_main_img"].ToString();
				}
				if(row["prizes_angle"]!=null)
				{
					model.prizes_angle=row["prizes_angle"].ToString();
				}
				if(row["prizes_probability"]!=null)
				{
					model.prizes_probability=row["prizes_probability"].ToString();
				}
				if(row["prizes_remark"]!=null)
				{
					model.prizes_remark=row["prizes_remark"].ToString();
				}
				if(row["prizes_create_time"]!=null && row["prizes_create_time"].ToString()!="")
				{
					model.prizes_create_time=DateTime.Parse(row["prizes_create_time"].ToString());
				}
				if(row["prizes_status"]!=null && row["prizes_status"].ToString()!="")
				{
					model.prizes_status=int.Parse(row["prizes_status"].ToString());
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
			strSql.Append("select prizes_id,prizes_prize_name,prizes_quantity,prizes_main_img,prizes_angle,prizes_probability,prizes_remark,prizes_create_time,prizes_status ");
			strSql.Append(" FROM tb_prizes ");
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
			strSql.Append("select count(1) FROM tb_prizes ");
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
				strSql.Append("order by T.prizes_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_prizes T ");
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
			parameters[0].Value = "tb_prizes";
			parameters[1].Value = "prizes_id";
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

