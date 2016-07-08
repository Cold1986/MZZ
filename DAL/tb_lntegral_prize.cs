using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MZZ.DAL
{
	/// <summary>
	/// 数据访问类:tb_lntegral_prize
	/// </summary>
	public partial class tb_lntegral_prize
	{
		public tb_lntegral_prize()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("lntegral_prize_id", "tb_lntegral_prize"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int lntegral_prize_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_lntegral_prize");
			strSql.Append(" where lntegral_prize_id=@lntegral_prize_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@lntegral_prize_id", MySqlDbType.Int32)
			};
			parameters[0].Value = lntegral_prize_id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_lntegral_prize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_lntegral_prize(");
			strSql.Append("lntegral_prize_name,lntegral_prize_cost,lntegral_prize_status,lntegral_prize_img,lntegral_prize_batch,lntegral_prize_num)");
			strSql.Append(" values (");
			strSql.Append("@lntegral_prize_name,@lntegral_prize_cost,@lntegral_prize_status,@lntegral_prize_img,@lntegral_prize_batch,@lntegral_prize_num)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@lntegral_prize_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@lntegral_prize_cost", MySqlDbType.Int32,11),
					new MySqlParameter("@lntegral_prize_status", MySqlDbType.VarChar,45),
					new MySqlParameter("@lntegral_prize_img", MySqlDbType.VarChar,45),
					new MySqlParameter("@lntegral_prize_batch", MySqlDbType.Int32,3),
					new MySqlParameter("@lntegral_prize_num", MySqlDbType.Int32,5)};
			parameters[0].Value = model.lntegral_prize_name;
			parameters[1].Value = model.lntegral_prize_cost;
			parameters[2].Value = model.lntegral_prize_status;
			parameters[3].Value = model.lntegral_prize_img;
			parameters[4].Value = model.lntegral_prize_batch;
			parameters[5].Value = model.lntegral_prize_num;

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
		public bool Update(MZZ.Model.tb_lntegral_prize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_lntegral_prize set ");
			strSql.Append("lntegral_prize_name=@lntegral_prize_name,");
			strSql.Append("lntegral_prize_cost=@lntegral_prize_cost,");
			strSql.Append("lntegral_prize_status=@lntegral_prize_status,");
			strSql.Append("lntegral_prize_img=@lntegral_prize_img,");
			strSql.Append("lntegral_prize_batch=@lntegral_prize_batch,");
			strSql.Append("lntegral_prize_num=@lntegral_prize_num");
			strSql.Append(" where lntegral_prize_id=@lntegral_prize_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@lntegral_prize_name", MySqlDbType.VarChar,45),
					new MySqlParameter("@lntegral_prize_cost", MySqlDbType.Int32,11),
					new MySqlParameter("@lntegral_prize_status", MySqlDbType.VarChar,45),
					new MySqlParameter("@lntegral_prize_img", MySqlDbType.VarChar,45),
					new MySqlParameter("@lntegral_prize_batch", MySqlDbType.Int32,3),
					new MySqlParameter("@lntegral_prize_num", MySqlDbType.Int32,5),
					new MySqlParameter("@lntegral_prize_id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.lntegral_prize_name;
			parameters[1].Value = model.lntegral_prize_cost;
			parameters[2].Value = model.lntegral_prize_status;
			parameters[3].Value = model.lntegral_prize_img;
			parameters[4].Value = model.lntegral_prize_batch;
			parameters[5].Value = model.lntegral_prize_num;
			parameters[6].Value = model.lntegral_prize_id;

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
		public bool Delete(int lntegral_prize_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_lntegral_prize ");
			strSql.Append(" where lntegral_prize_id=@lntegral_prize_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@lntegral_prize_id", MySqlDbType.Int32)
			};
			parameters[0].Value = lntegral_prize_id;

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
		public bool DeleteList(string lntegral_prize_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_lntegral_prize ");
			strSql.Append(" where lntegral_prize_id in ("+lntegral_prize_idlist + ")  ");
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
		public MZZ.Model.tb_lntegral_prize GetModel(int lntegral_prize_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select lntegral_prize_id,lntegral_prize_name,lntegral_prize_cost,lntegral_prize_status,lntegral_prize_img,lntegral_prize_batch,lntegral_prize_num from tb_lntegral_prize ");
			strSql.Append(" where lntegral_prize_id=@lntegral_prize_id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@lntegral_prize_id", MySqlDbType.Int32)
			};
			parameters[0].Value = lntegral_prize_id;

			MZZ.Model.tb_lntegral_prize model=new MZZ.Model.tb_lntegral_prize();
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
		public MZZ.Model.tb_lntegral_prize DataRowToModel(DataRow row)
		{
			MZZ.Model.tb_lntegral_prize model=new MZZ.Model.tb_lntegral_prize();
			if (row != null)
			{
				if(row["lntegral_prize_id"]!=null && row["lntegral_prize_id"].ToString()!="")
				{
					model.lntegral_prize_id=int.Parse(row["lntegral_prize_id"].ToString());
				}
				if(row["lntegral_prize_name"]!=null)
				{
					model.lntegral_prize_name=row["lntegral_prize_name"].ToString();
				}
				if(row["lntegral_prize_cost"]!=null && row["lntegral_prize_cost"].ToString()!="")
				{
					model.lntegral_prize_cost=int.Parse(row["lntegral_prize_cost"].ToString());
				}
				if(row["lntegral_prize_status"]!=null)
				{
					model.lntegral_prize_status=row["lntegral_prize_status"].ToString();
				}
				if(row["lntegral_prize_img"]!=null)
				{
					model.lntegral_prize_img=row["lntegral_prize_img"].ToString();
				}
				if(row["lntegral_prize_batch"]!=null && row["lntegral_prize_batch"].ToString()!="")
				{
					model.lntegral_prize_batch=int.Parse(row["lntegral_prize_batch"].ToString());
				}
				if(row["lntegral_prize_num"]!=null && row["lntegral_prize_num"].ToString()!="")
				{
					model.lntegral_prize_num=int.Parse(row["lntegral_prize_num"].ToString());
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
			strSql.Append("select lntegral_prize_id,lntegral_prize_name,lntegral_prize_cost,lntegral_prize_status,lntegral_prize_img,lntegral_prize_batch,lntegral_prize_num ");
			strSql.Append(" FROM tb_lntegral_prize ");
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
			strSql.Append("select count(1) FROM tb_lntegral_prize ");
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
				strSql.Append("order by T.lntegral_prize_id desc");
			}
			strSql.Append(")AS Row, T.*  from tb_lntegral_prize T ");
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
			parameters[0].Value = "tb_lntegral_prize";
			parameters[1].Value = "lntegral_prize_id";
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

