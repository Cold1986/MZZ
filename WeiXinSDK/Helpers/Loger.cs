using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WeiXinSDK.Helpers
{
    public class Loger
    {
        static string filepath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log\\";
        /// <summary>
        /// 写日志(用于跟踪)
        /// </summary>
        public static void WriteLog(string LogName, string LogMsg)
        {
            string filename = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            string temp = filepath + filename;
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);
            StreamWriter sr = null;
            try
            {
                if (!File.Exists(temp))
                {
                    sr = File.CreateText(temp);
                }
                else
                {
                    sr = File.AppendText(temp);
                }
                sr.WriteLine(DateTime.Now + "\t" + LogName + ":\t" + LogMsg + "\n");
            }
            catch
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

    }
}
