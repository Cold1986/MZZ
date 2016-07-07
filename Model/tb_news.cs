using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_news:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_news
	{
		public tb_news()
		{}
		#region Model
		private int _news_id;
		private string _news_category;
		private string _news_title;
		private string _news_introduce;
		private string _news_text;
		private string _news_relative_path;
		private string _news_absolute_path;
		private int _news_recom;
		private int _news_top;
		private DateTime _news_time;
		private string _news_remarks;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int news_id
		{
			set{ _news_id=value;}
			get{return _news_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_category
		{
			set{ _news_category=value;}
			get{return _news_category;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_title
		{
			set{ _news_title=value;}
			get{return _news_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_introduce
		{
			set{ _news_introduce=value;}
			get{return _news_introduce;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_text
		{
			set{ _news_text=value;}
			get{return _news_text;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_relative_path
		{
			set{ _news_relative_path=value;}
			get{return _news_relative_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_absolute_path
		{
			set{ _news_absolute_path=value;}
			get{return _news_absolute_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int news_recom
		{
			set{ _news_recom=value;}
			get{return _news_recom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int news_top
		{
			set{ _news_top=value;}
			get{return _news_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime news_time
		{
			set{ _news_time=value;}
			get{return _news_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string news_remarks
		{
			set{ _news_remarks=value;}
			get{return _news_remarks;}
		}
		#endregion Model

	}
}

