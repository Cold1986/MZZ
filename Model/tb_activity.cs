using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_activity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_activity
	{
		public tb_activity()
		{}
		#region Model
		private int _activity_id;
		private int _activity_hyid=0;
        private string _activity_openid = "";
        private string _activity_reason = "";
		private int _activity_num=0;
		private int _activity_calculate=0;
		private int _activity_state=0;
        private DateTime _activity_times = DateTime.Now;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int activity_id
		{
			set{ _activity_id=value;}
			get{return _activity_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int activity_hyid
		{
			set{ _activity_hyid=value;}
			get{return _activity_hyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activity_openid
		{
			set{ _activity_openid=value;}
			get{return _activity_openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activity_reason
		{
			set{ _activity_reason=value;}
			get{return _activity_reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int activity_num
		{
			set{ _activity_num=value;}
			get{return _activity_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int activity_calculate
		{
			set{ _activity_calculate=value;}
			get{return _activity_calculate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int activity_state
		{
			set{ _activity_state=value;}
			get{return _activity_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime activity_times
		{
			set{ _activity_times=value;}
			get{return _activity_times;}
		}
		#endregion Model

	}
}

