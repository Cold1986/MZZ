using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_signin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_signin
	{
		public tb_signin()
		{}
		#region Model
		private int _id;
		private string _openid;
		private string _type;
		private DateTime? _createdtime;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createdtime
		{
			set{ _createdtime=value;}
			get{return _createdtime;}
		}
		#endregion Model

	}
}

