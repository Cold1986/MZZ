using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_article
	{
		public tb_article()
		{}
		#region Model
		private int _article_id;
        private int _article_type = 0;
        private string _article_content = "";
        private string _article_imgs = "";
		private int _article_barrage=1;
        private int _article_user_id = 0;
        private int _article_time = 0;
		private int _article_statu=1;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int article_id
		{
			set{ _article_id=value;}
			get{return _article_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int article_type
		{
			set{ _article_type=value;}
			get{return _article_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_content
		{
			set{ _article_content=value;}
			get{return _article_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string article_imgs
		{
			set{ _article_imgs=value;}
			get{return _article_imgs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int article_barrage
		{
			set{ _article_barrage=value;}
			get{return _article_barrage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int article_user_id
		{
			set{ _article_user_id=value;}
			get{return _article_user_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int article_time
		{
			set{ _article_time=value;}
			get{return _article_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int article_statu
		{
			set{ _article_statu=value;}
			get{return _article_statu;}
		}
		#endregion Model

	}
}

