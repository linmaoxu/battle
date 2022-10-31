using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///挂载在游戏物体上的单例模式
/// </summary>
/// <typeparam name="T">类</typeparam>
public class SingletonMono<T>:MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    public static T _instance => instance;

    private void Awake()
    {
        instance = this as T;
    }
}
