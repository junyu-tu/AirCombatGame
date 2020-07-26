using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class JsonReader : IReader
{
    private JsonData data;
    private JsonData tempData;

    public IReader this[string key]
    {
        get {
            tempData = tempData[key];
            return this;
        }
    }

    public IReader this[int key]
    {
        get
        {
            tempData = tempData[key];
            return this;
        }
    }

    public void Get<T>(Action<T> callBack)
    {
        if (callBack == null) {
            Debug.LogWarning("当前回调方法为空，不返回数据");
            ResetData();
            return;
        }

        T dataX = GetValue<T>(tempData);
        callBack(dataX);
        ResetData();
    }

    /// <summary>
    /// 数据重置
    /// </summary>
    private void ResetData() {
        tempData = data;
    }

    /// <summary>
    /// 数据具体类型的转换
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    private T GetValue<T>(JsonData data) {
        //涉及到泛型类型的转换  需要使用转换器
       var converter =  TypeDescriptor.GetConverter(typeof(T));//这样会生成一个T类型的转换器
        return (T)converter.ConvertTo(data.ToJson(),typeof(T));
    }

    public void SetData(object data)
    {
        if (data is string)
        {
            data = JsonMapper.ToObject((string)data);
            ResetData();
        }
        else {
            Debug.LogError("当前传入数据类型错误，当前类智能解析Json");
        }
       
    }
}
