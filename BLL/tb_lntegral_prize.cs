using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using MZZ.Model;
namespace MZZ.BLL
{
	/// <summary>
	/// tb_lntegral_prize
	/// </summary>
	public partial class tb_lntegral_prize
	{
		private readonly MZZ.DAL.tb_lntegral_prize dal=new MZZ.DAL.tb_lntegral_prize();
		public tb_lntegral_prize()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int lntegral_prize_id)
		{
			return dal.Exists(lntegral_prize_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MZZ.Model.tb_lntegral_prize model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MZZ.Model.tb_lntegral_prize model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int lntegral_prize_id)
		{
			
			return dal.Delete(lntegral_prize_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string lntegral_prize_idlist )
		{
			return dal.DeleteList(lntegral_prize_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MZZ.Model.tb_lntegral_prize GetModel(int lntegral_prize_id)
		{
			
			return dal.GetModel(lntegral_prize_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MZZ.Model.tb_lntegral_prize GetModelByCache(int lntegral_prize_id)
		{
			
			string CacheKey = "tb_lntegral_prizeModel-" + lntegral_prize_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(lntegral_prize_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MZZ.Model.tb_lntegral_prize)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MZZ.Model.tb_lntegral_prize> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MZZ.Model.tb_lntegral_prize> DataTableToList(DataTable dt)
		{
			List<MZZ.Model.tb_lntegral_prize> modelList = new List<MZZ.Model.tb_lntegral_prize>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MZZ.Model.tb_lntegral_prize model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

