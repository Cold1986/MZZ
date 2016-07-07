using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_imgs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_imgs
	{
		public tb_imgs()
		{}
		#region Model
		private int _imgs_id;
		private string _imgs_path;
		private string _imgs_etag;
		private string _imgs_path_md5;
		private string _imgs_mime;
		private int _imgs_height=0;
		private int _imgs_width=0;
		private int _imgs_size=0;
		private int _imgs_quote=0;
		private int _imgs_score=0;
		private int _imgs_score_tip=0;
		private string _imgs_score_task;
		private int _imgs_time=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int imgs_id
		{
			set{ _imgs_id=value;}
			get{return _imgs_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgs_path
		{
			set{ _imgs_path=value;}
			get{return _imgs_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgs_etag
		{
			set{ _imgs_etag=value;}
			get{return _imgs_etag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgs_path_md5
		{
			set{ _imgs_path_md5=value;}
			get{return _imgs_path_md5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgs_mime
		{
			set{ _imgs_mime=value;}
			get{return _imgs_mime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_height
		{
			set{ _imgs_height=value;}
			get{return _imgs_height;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_width
		{
			set{ _imgs_width=value;}
			get{return _imgs_width;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_size
		{
			set{ _imgs_size=value;}
			get{return _imgs_size;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_quote
		{
			set{ _imgs_quote=value;}
			get{return _imgs_quote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_score
		{
			set{ _imgs_score=value;}
			get{return _imgs_score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_score_tip
		{
			set{ _imgs_score_tip=value;}
			get{return _imgs_score_tip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imgs_score_task
		{
			set{ _imgs_score_task=value;}
			get{return _imgs_score_task;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int imgs_time
		{
			set{ _imgs_time=value;}
			get{return _imgs_time;}
		}
		#endregion Model

	}
}

