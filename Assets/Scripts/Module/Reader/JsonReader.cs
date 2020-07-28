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

    private KeyQueue _keys;
    private Queue<KeyQueue> _keyQueues = new Queue<KeyQueue>();

    public IReader this[string key]
    {
        get {
            if (!SetKey(key)) {
                _tempData = _tempData[key];
            }       
            return this;
        }
    }

    public IReader this[int key]
    {
        get
        {
            if (!SetKey(key))
            {
                _tempData = _tempData[key];
            }
            return this;
        }
    }

    private bool SetKey<T>(T key) {
        if (_data == null || _keys != null)
        {
            if (_keys == null)
            {
                _keys = new KeyQueue();
            }
            IKey keyData = new Key();
            keyData.Set(key);
            _keys.Enqueue(keyData);
            return true;
        }        
        return false;
    }

    /// <summary>
    /// 当调用这个方法 也就表示数据获取到“底”了，就得重置数据了
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="callBack"></param>
    public void Get<T>(Action<T> callBack)
    {
        //这一段是  结束一组数据  缓存下来并进行清空
        if (_keys != null) {
            _keys.OnComplete((dataTemp)=> {
                T value = GetValue<T>(dataTemp);
                callBack(value);
                ResetData();
            });
            _keyQueues.Enqueue(_keys);
            _keys = null;
            ExecuteKeysQueue();
            return;
        }

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
    /// 检查data是否为空 如果不是空 则只需缓存部分的逻辑
    /// </summary>
    private void ExecuteKeysQueue() {
        if (_data == null) {
            return;
        }

        IReader reader = null;

        //不为空 执行所有的缓存队列
        foreach (KeyQueue keyQueue in _keyQueues)
        {
            foreach (object item in keyQueue) {

                if (item is string)
                {
                    reader = this[(string)item];
                }
                else if (item is int)
                {
                    reader = this[(int)item];
                }
                else {
                    Debug.Log("当前键值类型错误！");
                }

                keyQueue.Complete(_tempData);
            }
        }
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

/// <summary>
/// Key值队列类
/// </summary>
public class KeyQueue:IEnumerable
{
    //存储相关命令
    private Queue<IKey> _keys = new Queue<IKey>();

    private Action<JsonData> _complete;

    public void Enqueue(IKey key) {
        _keys.Enqueue(key);
    }

    public void Dequeue()
    {
        _keys.Dequeue();
    }

    public void Clear() {
        _keys.Clear();
    }

    public void Complete(JsonData data) {
        if (_complete != null) {
            _complete(data);
        }
    }

    public void OnComplete(Action<JsonData> complete) {
        _complete = complete;
    }

    //实现IEnumerable接口，当在外部对KeyQueue类进行foreach遍历的时候  这个方法会将一个一个的key返回出去
    public IEnumerator GetEnumerator()
    {
        foreach (IKey key in _keys)
        {
            yield return key.Get();
        }
    }
}


public interface IKey {
    void Set<T>(T key);
    object Get();
    //要让子类实现一个只读属性，那么在接口中只需要写get 不需要写set
    Type KeyType { get; }
}

public class Key: IKey
{
    //最开始的想法  因为不想在IKey里面接入泛型 那么这个方式就不行
    //private T _key;
    //public T1 Get<T1>() where T1 : T
    //{
    //    return (T1)_key;
    //}
    ////泛型约束：T是T1的父类
    //public void Set<T1>(T1 key) where T1 : T
    //{
    //    _key = key;
    //}

    private object _key;
    public Type KeyType { get; private set; }

    public object Get()
    {
        return _key;
    }

    //泛型约束：T是T1的父类
    public void Set<T1>(T1 key)
    {
        _key = key;
    }
}