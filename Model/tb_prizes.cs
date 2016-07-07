using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_prizes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_prizes
	{
		public tb_prizes()
		{}
		#region Model
		private int _prizes_id;
		private string _prizes_prize_name;
		private int _prizes_quantity;
		private string _prizes_main_img;
		private string _prizes_angle;
		private string _prizes_probability;
		private string _prizes_remark;
		private DateTime _prizes_create_time;
		private int _prizes_status;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int prizes_id
		{
			set{ _prizes_id=value;}
			get{return _prizes_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prizes_prize_name
		{
			set{ _prizes_prize_name=value;}
			get{return _prizes_prize_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int prizes_quantity
		{
			set{ _prizes_quantity=value;}
			get{return _prizes_quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prizes_main_img
		{
			set{ _prizes_main_img=value;}
			get{return _prizes_main_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prizes_angle
		{
			set{ _prizes_angle=value;}
			get{return _prizes_angle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prizes_probability
		{
			set{ _prizes_probability=value;}
			get{return _prizes_probability;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string prizes_remark
		{
			set{ _prizes_remark=value;}
			get{return _prizes_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime prizes_create_time
		{
			set{ _prizes_create_time=value;}
			get{return _prizes_create_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int prizes_status
		{
			set{ _prizes_status=value;}
			get{return _prizes_status;}
		}
		#endregion Model

	}
}

