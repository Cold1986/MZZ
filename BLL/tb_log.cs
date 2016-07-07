﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using MZZ.Model;
namespace MZZ.BLL
{
    /// <summary>
    /// tb_log
    /// </summary>
    public partial class tb_log
    {
        private readonly MZZ.DAL.tb_log dal = new MZZ.DAL.tb_log();
        public tb_log()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int log_id)
        {
            return dal.Exists(log_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MZZ.Model.tb_log model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MZZ.Model.tb_log model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int log_id)
        {

            return dal.Delete(log_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string log_idlist)
        {
            return dal.DeleteList(log_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MZZ.Model.tb_log GetModel(int log_id)
        {

            return dal.GetModel(log_id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public MZZ.Model.tb_log GetModelByCache(int log_id)
        {

            string CacheKey = "tb_logModel-" + log_id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(log_id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (MZZ.Model.tb_log)objModel;
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
        public List<MZZ.Model.tb_log> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MZZ.Model.tb_log> DataTableToList(DataTable dt)
        {
            List<MZZ.Model.tb_log> modelList = new List<MZZ.Model.tb_log>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MZZ.Model.tb_log model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
