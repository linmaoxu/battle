using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter : Singleton<EventCenter>
{
    public delegate void EventFunc();
    public delegate void EventFunc<T>(T A);
    public delegate void EventFunc<T1,T2>(T1 A,T2 B);
    public delegate void EventFunc<T1,T2,T3>(T1 A,T2 B,T3 C);

    //事件存储字典
    public Dictionary<string, Delegate> eventDic = new Dictionary<string, Delegate>();

    //检测方法类型是否一致
    private bool CheckFunc(string eventName, Delegate callback)
    {
      if (eventDic[eventName].GetType()== callback.GetType())
      {
          return true;
      }
      else
      {
          return false;
      }
    }

    #region 添加事件监听方法

    /// <summary>
    /// 添加事件监听
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="callback">回调函数</param>
    public void AddEventListenning(string eventName, EventFunc callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            //检测添加的函数类型是否一致
            if (CheckFunc(eventName, callback))
            {
                eventDic[eventName] = eventDic[eventName] as EventFunc + callback;
                return;
            }
            else
            {
                throw new Exception(string.Format("the type of{0} is different from{1}", eventDic[eventName].GetType(), callback.GetType()));
            }          
        }
        eventDic.Add(eventName, callback);
    }

    /// <summary>
    /// 添加事件监听(带一个参数)
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="eventName">事件名称</param>
    /// <param name="callback">回调函数</param>
    public void AddEventListenning<T>(string eventName, EventFunc<T> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T> + callback;
            return;
        }
        eventDic.Add(eventName, callback);
    }

    /// <summary>
    /// 添加事件监听(带两个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <param name="eventName">事件名称</param>
    /// <param name="callback">回调函数</param>
    public void AddEventListenning<T1,T2>(string eventName, EventFunc<T1, T2> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T1, T2> + callback;
            return;
        }
        eventDic.Add(eventName, callback);
    }

    /// <summary>
    /// 添加事件监听(带三个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <typeparam name="T3">参数3类型</typeparam>
    /// <param name="eventName">事件名称</param>
    /// <param name="callback">回调函数</param>
    public void AddEventListenning<T1, T2,T3>(string eventName, EventFunc<T1, T2, T3> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T1, T2, T3> + callback;
            return;
        }
        eventDic.Add(eventName, callback);
    }

    #endregion

    #region 移出监听函数方法
    /// <summary>
    /// 移出监听函数
    /// </summary>
    /// <param name="eventName">事件名字</param>
    /// <param name="callback">回调函数</param>
    public void RemoveEventListenning(string eventName, EventFunc callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc - callback;
            return;
        }
    }

    /// <summary>
    /// 移出监听函数(带一个参数)
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="eventName">事件名字</param>
    /// <param name="callback">回调函数</param>
    public void RemoveEventListenning<T>(string eventName, EventFunc<T> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T> - callback;
            return;
        }
    }

    /// <summary>
    /// 移出监听函数(带两个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <param name="eventName">事件名字</param>
    /// <param name="callback">回调函数</param>
    public void RemoveEventListenning<T1, T2>(string eventName, EventFunc<T1, T2> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T1, T2> - callback;
            return;
        }
    }

    /// <summary>
    /// 移出监听函数(带三个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <typeparam name="T3">参数3类型</typeparam>
    /// <param name="eventName">事件名字</param>
    /// <param name="callback">回调函数</param>
    public void RemoveEventListenning<T1, T2, T3>(string eventName, EventFunc<T1, T2, T3> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T1, T2, T3> - callback;
            return;
        }
    }

    #endregion
}

