using System;
namespace MZZ.Model
{
    /// <summary>
    /// tb_log:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_log
    {
        public tb_log()
        { }
        #region Model
        private int _log_id;
        private int _log_userid;
        private string _log_openid;
        private string _log_operation;
        private string _log_event;
        private string _log_remarks;
        private string _log_ip;
        private DateTime _log_time;
        private int _log_state;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int log_id
        {
            set { _log_id = value; }
            get { return _log_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int log_userid
        {
            set { _log_userid = value; }
            get { return _log_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_openid
        {
            set { _log_openid = value; }
            get { return _log_openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_operation
        {
            set { _log_operation = value; }
            get { return _log_operation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_event
        {
            set { _log_event = value; }
            get { return _log_event; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_remarks
        {
            set { _log_remarks = value; }
            get { return _log_remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_ip
        {
            set { _log_ip = value; }
            get { return _log_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime log_time
        {
            set { _log_time = value; }
            get { return _log_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int log_state
        {
            set { _log_state = value; }
            get { return _log_state; }
        }
        #endregion Model

    }
}

