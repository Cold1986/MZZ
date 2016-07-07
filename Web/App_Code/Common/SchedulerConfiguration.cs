using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

/// <summary>
/// SchedulerConfiguration 的摘要说明
/// </summary>

public class SchedulerConfiguration
{
    //时间间隔
    private int sleepInterval;
    //任务列表
    private ArrayList jobs = new ArrayList();

    public int SleepInterval { get { return sleepInterval; } }
    public ArrayList Jobs { get { return jobs; } }

    //调度配置类的构造函数
    public SchedulerConfiguration(int newSleepInterval)
    {
        sleepInterval = newSleepInterval;
    }
}

public interface ISchedulerJob
{
    void Execute();
}

//定时刷新
public class SchedulerJob : ISchedulerJob
{
    public void Execute()
    {
        //new wxProduct().GetProductList();//产品
        //new wxOrder().GetOrderList();//订单
        //new wxHongBao().GetFaHongBaoList();//红包
    }
}

//调度引擎，定时执行配置对象的任务
public class Scheduler
{
    private SchedulerConfiguration configuration = null;

    public Scheduler(SchedulerConfiguration config)
    {
        configuration = config;
    }

    public void Start()
    {
        while (true)
        {
            //执行每一个任务
            foreach (ISchedulerJob job in configuration.Jobs)
            {
                ThreadStart myThreadDelegate = new ThreadStart(job.Execute);
                Thread myThread = new Thread(myThreadDelegate);
                myThread.Start();
                Thread.Sleep(configuration.SleepInterval);
            }
        }
    }
}
