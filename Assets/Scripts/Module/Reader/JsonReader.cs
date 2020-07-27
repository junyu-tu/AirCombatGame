using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class JsonReader : IReader
{
    private JsonData _data;
    //缓存当前获取的JsonData
    private JsonData _tempData;

    public IReader this[string key]
    {
        get {
            _tempData = _tempData[key];
            return this;
        }
    }

    public IReader this[int key]
    {
        get
        {
            _tempData = _tempData[key];
            return this;
        }
    }

    /// <summary>
    /// 当调用这个方法 也就表示数据获取到“底”了，就得重置数据了
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="callBack"></param>
    public void Get<T>(Action<T> callBack)
    {
        if (callBack == null) {
            Debug.LogWarning("当前回调方法为空，不返回数据");
            ResetData();
            return;
        }

        T dataX = GetValue<T>(_tempData);
        callBack(dataX);
        ResetData();
    }

    /// <summary>
    /// 数据重置
    /// </summary>
    private void ResetData() {
        _tempData = _data;
    }

    /// <summary>
    /// 数据具体类型的转换
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <returns></returns>
    private T GetValue<T>(JsonData data) {
        //涉及到泛型类型的转换  需要使用转换器
        //这样会生成一个T类型的转换器
        var converter =  TypeDescriptor.GetConverter(typeof(T));
        return (T)converter.ConvertTo(data.ToJson(),typeof(T));
    }

    public void SetData(object data)
    {
        //确保data数据是string类型
        if (data is string)
        {
            _data = JsonMapper.ToObject((string)data);
            ResetData();
        }
        else {
            Debug.LogError("当前传入数据类型错误，当前类只能解析Json");
        }
       
    }
}
