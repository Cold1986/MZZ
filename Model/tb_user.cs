using System;
namespace MZZ.Model
{
    /// <summary>
    /// tb_user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class tb_user
    {
        public tb_user()
        { }
        #region Model
        private int _user_id;
        private string _user_phone = "1";
        private string _user_pass = "";
        private int _user_integral = 0;
        private int _user_level = 5;
        private string _user_data = "";
        private int _user_login_time = 0;
        private string _user_login_ip = "";
        private int _user_create_time = 0;
        private string _user_create_ip = "";
        private string _user_openid = "";
        private string _user_nick_name = "";
        private int _user_sex = 0;
        private string _user_city = "";
        private string _user_country = "";
        private string _user_province = "";
        private string _user_language = "";
        private string _user_head_img_url = "";
        private DateTime _user_sub_time = DateTime.Now;
        private bool _user_sub_scribe = false;
        private string _user_up_openid = "";
        private DateTime _user_uopenid_time = DateTime.Now;
        private int _user_status = 0;
        private int _user_hy_status = 0;
        private string _user_qr_code = "";
        /// <summary>
        /// auto_increment
        /// </summary>
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_phone
        {
            set { _user_phone = value; }
            get { return _user_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_pass
        {
            set { _user_pass = value; }
            get { return _user_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_integral
        {
            set { _user_integral = value; }
            get { return _user_integral; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_level
        {
            set { _user_level = value; }
            get { return _user_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_data
        {
            set { _user_data = value; }
            get { return _user_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_login_time
        {
            set { _user_login_time = value; }
            get { return _user_login_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_login_ip
        {
            set { _user_login_ip = value; }
            get { return _user_login_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_create_time
        {
            set { _user_create_time = value; }
            get { return _user_create_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_create_ip
        {
            set { _user_create_ip = value; }
            get { return _user_create_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_openid
        {
            set { _user_openid = value; }
            get { return _user_openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_nick_name
        {
            set { _user_nick_name = value; }
            get { return _user_nick_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_sex
        {
            set { _user_sex = value; }
            get { return _user_sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_city
        {
            set { _user_city = value; }
            get { return _user_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_country
        {
            set { _user_country = value; }
            get { return _user_country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_province
        {
            set { _user_province = value; }
            get { return _user_province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_language
        {
            set { _user_language = value; }
            get { return _user_language; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_head_img_url
        {
            set { _user_head_img_url = value; }
            get { return _user_head_img_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime user_sub_time
        {
            set { _user_sub_time = value; }
            get { return _user_sub_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool user_sub_scribe
        {
            set { _user_sub_scribe = value; }
            get { return _user_sub_scribe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_up_openid
        {
            set { _user_up_openid = value; }
            get { return _user_up_openid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime user_uopenid_time
        {
            set { _user_uopenid_time = value; }
            get { return _user_uopenid_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_status
        {
            set { _user_status = value; }
            get { return _user_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_hy_status
        {
            set { _user_hy_status = value; }
            get { return _user_hy_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_qr_code
        {
            set { _user_qr_code = value; }
            get { return _user_qr_code; }
        }
        #endregion Model

    }
}

