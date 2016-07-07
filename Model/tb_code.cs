using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_code:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_code
	{
		public tb_code()
		{}
		#region Model
		private int _code_id;
		private string _code_code;
		private int _code_userid=0;
		private string _code_openid;
		private int _code_prizeid=0;
		private string _code_prize_name;
		private string _code_main_img;
		private string _code_remark;
		private DateTime _code_create_time;
		private int _code_status=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int code_id
		{
			set{ _code_id=value;}
			get{return _code_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code_code
		{
			set{ _code_code=value;}
			get{return _code_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int code_userid
		{
			set{ _code_userid=value;}
			get{return _code_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code_openid
		{
			set{ _code_openid=value;}
			get{return _code_openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int code_prizeid
		{
			set{ _code_prizeid=value;}
			get{return _code_prizeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code_prize_name
		{
			set{ _code_prize_name=value;}
			get{return _code_prize_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code_main_img
		{
			set{ _code_main_img=value;}
			get{return _code_main_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code_remark
		{
			set{ _code_remark=value;}
			get{return _code_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime code_create_time
		{
			set{ _code_create_time=value;}
			get{return _code_create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int code_status
		{
			set{ _code_status=value;}
			get{return _code_status;}
		}
		#endregion Model

	}
}

