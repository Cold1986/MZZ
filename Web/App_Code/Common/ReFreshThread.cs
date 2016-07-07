using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

/// <summary>
///ReFreshThread 的摘要说明
/// </summary>
public class ReFreshThread
{
    public static System.Threading.Thread schedulerThread = null;
	public ReFreshThread()
	{
        Timer t = new Timer(300000);
        t.Elapsed += new ElapsedEventHandler(ReFreshThread2);
        t.AutoReset = true;
        t.Enabled = true;

        //实例化调度配置
        SchedulerConfiguration config = new SchedulerConfiguration(1000 * 60 * 60); //一小时刷新一次

        //添加任务
        config.Jobs.Add(new SchedulerJob());

        Scheduler scheduler = new Scheduler(config);

        //创建 ThreadStart 委托
        System.Threading.ThreadStart myThreadStart = new System.Threading.ThreadStart(scheduler.Start);

        //实例化线程
        schedulerThread = new System.Threading.Thread(myThreadStart);

        //启动线程
        schedulerThread.Start();
	}

    public void ReFreshThread2(object sender,ElapsedEventArgs e)
    {
        //WebHelp.HttpGet("http://www.e-store.hk/", "");
        CHelper.WriteLog("访问www.e-store.hk！","");
    }
}
