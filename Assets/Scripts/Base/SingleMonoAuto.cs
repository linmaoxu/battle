using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����������Ϸ�����ϵĵ���
/// �����ڸ�ģ��ű��Ĺ���
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleMonoAuto<T>:MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    public static T _instance
    {
        get
        {
            if (instance==null)
            {
                GameObject go = new GameObject(typeof(T).ToString());
                instance = go.AddComponent<T>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
}
