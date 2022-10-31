using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 无需挂载在游戏物体上的单例模式
/// </summary>
/// <typeparam name="T">类</typeparam>
public class Singleton<T>where T:new()
{
    private static T instance;
    public static T _instance
    {
        get
        {
            if (instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
