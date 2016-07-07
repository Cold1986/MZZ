using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_figure:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_figure
	{
		public tb_figure()
		{}
		#region Model
		private int _figure_id;
		private int _figure_hyid;
		private string _figure_openid;
		private string _figure_title;
		private string _figure_category;
		private string _figure_classify;
		private decimal _figure_sellprice;
		private string _figure_introduce;
		private string _figure_condition;
		private DateTime _figure_time;
		private int _figure_state;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int figure_id
		{
			set{ _figure_id=value;}
			get{return _figure_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int figure_hyid
		{
			set{ _figure_hyid=value;}
			get{return _figure_hyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string figure_openid
		{
			set{ _figure_openid=value;}
			get{return _figure_openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string figure_title
		{
			set{ _figure_title=value;}
			get{return _figure_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string figure_category
		{
			set{ _figure_category=value;}
			get{return _figure_category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string figure_classify
		{
			set{ _figure_classify=value;}
			get{return _figure_classify;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal figure_sellprice
		{
			set{ _figure_sellprice=value;}
			get{return _figure_sellprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string figure_introduce
		{
			set{ _figure_introduce=value;}
			get{return _figure_introduce;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string figure_condition
		{
			set{ _figure_condition=value;}
			get{return _figure_condition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime figure_time
		{
			set{ _figure_time=value;}
			get{return _figure_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int figure_state
		{
			set{ _figure_state=value;}
			get{return _figure_state;}
		}
		#endregion Model

	}
}

