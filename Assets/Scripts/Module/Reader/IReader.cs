using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReader
{
    IReader this[string key] { get; }
    IReader this[int key] { get; }
    //读取器进行加载 加载好了 调用传入的回调方法告诉 资源加载好了
    void Get<T>(Action<T> callBack);
    void SetData(object data);
}
