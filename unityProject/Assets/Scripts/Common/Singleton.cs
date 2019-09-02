using System;
using UnityEngine;

/// <summary>
/// 常规单例
/// </summary>
public class SingletonPersistent<T> where T:new()
{
    protected static T _instance;//受保护的实例，不对外
    public static T instance//对外开放的实例，保证单例
    {
        get {
            if (_instance==null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}

/// <summary>
/// Mono的单例，使用时需要指定instance！！
/// </summary>
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance
    {
        protected set
        {
            if (_instance)
            {
                throw new Exception(typeof(T).Name + "must be singleton");
            }
            _instance = value;
        }
        get
        {
            return _instance;
        }
    }
}

