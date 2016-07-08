using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_lntegral_prize:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_lntegral_prize
	{
		public tb_lntegral_prize()
		{}
		#region Model
		private int _lntegral_prize_id;
		private string _lntegral_prize_name;
		private int? _lntegral_prize_cost;
		private string _lntegral_prize_status;
		private string _lntegral_prize_img;
		private int? _lntegral_prize_batch;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int lntegral_prize_id
		{
			set{ _lntegral_prize_id=value;}
			get{return _lntegral_prize_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lntegral_prize_name
		{
			set{ _lntegral_prize_name=value;}
			get{return _lntegral_prize_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lntegral_prize_cost
		{
			set{ _lntegral_prize_cost=value;}
			get{return _lntegral_prize_cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lntegral_prize_status
		{
			set{ _lntegral_prize_status=value;}
			get{return _lntegral_prize_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lntegral_prize_img
		{
			set{ _lntegral_prize_img=value;}
			get{return _lntegral_prize_img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? lntegral_prize_batch
		{
			set{ _lntegral_prize_batch=value;}
			get{return _lntegral_prize_batch;}
		}
		#endregion Model

	}
}

