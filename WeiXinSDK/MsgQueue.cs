using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXinSDK.Message;
using System.Xml.Linq;

/// <summary>
///MsgQueue 消息队列， 用于消息排重
/// </summary>
public class MsgQueue
{
    public static List<BaseMsg2> _queue;
    public static string GetNoRepeatMsgByXml(string xml)
    {
        if (string.IsNullOrEmpty(xml))
        {
            return null;
        }
        if (_queue == null)
        {
            _queue = new List<BaseMsg2>();
        }
        else if (_queue.Count >= 50)
        {
            _queue = _queue.Where(q => { return q.CreateTime.AddSeconds(20) > DateTime.Now; }).ToList();//保留20秒内未响应的消息
        }


        var dict = WeiXinSDK.Util.GetDictFromXml(xml);

        string key = string.Empty;
        ReplyBaseMsg replyMsg = ReplyEmptyMsg.Instance;
        if (dict.ContainsKey("Event"))//事件消息
        {
            string CreateTime = dict["CreateTime"];
            string FromUserName = dict["FromUserName"];

            if (_queue.FirstOrDefault(m => { return m.MsgFlag == CreateTime; }) == null)
            {
                _queue.Add(new BaseMsg2
                {
                    CreateTime = DateTime.Now,
                    FromUserName = FromUserName,
                    MsgFlag = CreateTime
                });
            }
            else
            {
                return null;
            }
        }
        else if (dict.ContainsKey("MsgId"))//普通消息
        {
            string MsgId = dict["MsgId"];
            string FromUserName = dict["FromUserName"];

            if (_queue.FirstOrDefault(m => { return m.MsgFlag == MsgId; }) == null)
            {
                _queue.Add(new BaseMsg2
                {
                    CreateTime = DateTime.Now,
                    FromUserName = FromUserName,
                    MsgFlag = MsgId
                });
            }
            else
            {
                return null;
            }
        }
        return xml;
    }
}