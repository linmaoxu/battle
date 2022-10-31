using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///��������Ϸ�����ϵĵ���ģʽ
/// </summary>
/// <typeparam name="T">��</typeparam>
public class SingletonMono<T>:MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    public static T _instance => instance;

    private void Awake()
    {
        instance = this as T;
    }
}
