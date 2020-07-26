using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsMemory : IDataMemory
{
    /// <summary>
    /// 数据获取器
    /// </summary>
    private Dictionary<Type, Func<string, object>> dataGetter = new Dictionary<Type, Func<string, object>>()
    {
        { typeof(int),(key)=>PlayerPrefs.GetInt(key,0)},
        { typeof(string),(key)=>PlayerPrefs.GetString(key,"")},
        { typeof(float),(key)=>PlayerPrefs.GetFloat(key,0f)},
    };

    /// <summary>
    /// 数据存储器
    /// </summary>
    private Dictionary<Type, Action<string, object>> dataSetter = new Dictionary<Type, Action<string, object>>()
    {
        { typeof(int),(key,value)=>PlayerPrefs.SetInt(key,(int)value)},
        { typeof(string),(key,value)=>PlayerPrefs.SetString(key,(string)value)},
        { typeof(float),(key,value)=>PlayerPrefs.SetFloat(key,(float)value)},
    };

    public T Get<T>(string key)
    {
        
        Type type = typeof(T);
        var converter = TypeDescriptor.GetConverter(type);//类型转换器

        if (dataGetter.ContainsKey(type))
        {
            return (T)converter.ConvertTo(dataGetter[type](key), type);
        }
        else {
            Debug.LogError("当前数据存储中无此类型数据，类型名：" + typeof(T).Name);
            //返回当前你传入类型的默认值
            return default;
        }
        

    }

    public void Set<T>(string key, T value)
    {
        Type type = typeof(T);
        if (dataSetter.ContainsKey(type))
        {
            dataSetter[type](key,value);
        }
        else
        {
            Debug.LogError("当前数据存储中无此类型数据，类型为Key:"+key+" value: "+ value);
        }
    }


    public void Clear(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }

}
