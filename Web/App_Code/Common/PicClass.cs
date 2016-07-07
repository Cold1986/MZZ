using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
///PicClass 的摘要说明
/// </summary>
public class PicClass
{
	public PicClass()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    public static string Pic(string Message)
    {
        string path = HttpContext.Current.Server.MapPath("./") + "upload\\"; //获取当前目录下upfile文件夹在服务器上的绝对地址，作为图片保存地址。
        StringBuilder strbder = new StringBuilder(); //定义可变字符字符串变量，实现字符的动态重组
        string FullFileName = Message; //获得客户浏览器选择文件的全部路径以及文件名
        string UpFileName = FullFileName.Substring(FullFileName.LastIndexOf("\\") + 1); //以"\"为索引，截取文件名,来用获取文件格式
        string FileType = UpFileName.Substring(UpFileName.LastIndexOf(".") + 1);  //以"."为索引，截取文件扩展名

        //以下操作是为了避免在同一时间有多人同时上传,造成文件名相同而发生覆盖现象,
        //这里以长时间加随机数来尽量避免,可以加大随机数而继续降低重名几率
        System.DateTime currentTime = new System.DateTime();  //创建时间对象
        currentTime = System.DateTime.Now;        //设置当前时间
        strbder.Append(currentTime.Year.ToString());    //获取当前年份字符串，并追加到strbder变量的结尾
        strbder.Append(currentTime.Month.ToString());   //获取当前月份字符串，并追加到strbder变量的结尾
        strbder.Append(currentTime.Day.ToString());     //获取当前日期字符串，并追加到strbder变量的结尾
        strbder.Append(currentTime.Hour.ToString());    //获取当前时针数字符串，并追加到strbder变量的结尾
        strbder.Append(currentTime.Minute.ToString());  //获取当前分针数字符串，并追加到strbder变量的结尾
        strbder.Append(currentTime.Second.ToString());  //获取当前秒针数字符串，并追加到strbder变量的结尾
        Random objRdm = new Random();        //创建随机对象
        strbder.Append(objRdm.Next(1, 200).ToString());  //生成一个1～200之间的随机数，并追加到strbder变量的结尾

        UpFileName = strbder.ToString() + "." + FileType;    //重新组合上传文件的名称
        UpFileName = UpFileName.ToLower();  //全部设置为小写,避免带来的不方便
        FileType = FileType.ToLower();  //设置为小写,主要用来判断
        if (FileType == "bmp" || FileType == "jpg" || FileType == "gif" || FileType == "png")  //判断上传文件类型,这样可以屏蔽用户扩展名的大小写不统一
        {
            return UpFileName;
        }
        else
        {
            return "格式不正确";
        }

    }
}