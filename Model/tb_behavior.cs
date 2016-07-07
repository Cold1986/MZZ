using System;
namespace MZZ.Model
{
	/// <summary>
	/// tb_behavior:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_behavior
	{
		public tb_behavior()
		{}
		#region Model
		private int _behavior_id;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int behavior_id
		{
			set{ _behavior_id=value;}
			get{return _behavior_id;}
		}
		#endregion Model

	}
}

