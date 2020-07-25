﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T _single;
    public static T Single
    {
        get
        {
            if (_single == null)
            {
                _single = FindObjectOfType<T>();
                if (_single == null)
                {
                    Debug.LogError(message: "场景中未找到类的对象，类名为："+typeof(T).Name);
                }
            }
            return _single;
        }
    }

    private void Awake()
    {
        if (_single == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
