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

    //�¼��洢�ֵ�
    public Dictionary<string, Delegate> eventDic = new Dictionary<string, Delegate>();

    //��ⷽ�������Ƿ�һ��
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

    #region ����¼���������

    /// <summary>
    /// ����¼�����
    /// </summary>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
    public void AddEventListenning(string eventName, EventFunc callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            //�����ӵĺ��������Ƿ�һ��
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
    /// ����¼�����(��һ������)
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
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
    /// ����¼�����(����������)
    /// </summary>
    /// <typeparam name="T1">����1����</typeparam>
    /// <typeparam name="T2">����2����</typeparam>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
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
    /// ����¼�����(����������)
    /// </summary>
    /// <typeparam name="T1">����1����</typeparam>
    /// <typeparam name="T2">����2����</typeparam>
    /// <typeparam name="T3">����3����</typeparam>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
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

    #region �Ƴ�������������
    /// <summary>
    /// �Ƴ���������
    /// </summary>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
    public void RemoveEventListenning(string eventName, EventFunc callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc - callback;
            return;
        }
    }

    /// <summary>
    /// �Ƴ���������(��һ������)
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
    public void RemoveEventListenning<T>(string eventName, EventFunc<T> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T> - callback;
            return;
        }
    }

    /// <summary>
    /// �Ƴ���������(����������)
    /// </summary>
    /// <typeparam name="T1">����1����</typeparam>
    /// <typeparam name="T2">����2����</typeparam>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
    public void RemoveEventListenning<T1, T2>(string eventName, EventFunc<T1, T2> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] = eventDic[eventName] as EventFunc<T1, T2> - callback;
            return;
        }
    }

    /// <summary>
    /// �Ƴ���������(����������)
    /// </summary>
    /// <typeparam name="T1">����1����</typeparam>
    /// <typeparam name="T2">����2����</typeparam>
    /// <typeparam name="T3">����3����</typeparam>
    /// <param name="eventName">�¼�����</param>
    /// <param name="callback">�ص�����</param>
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

