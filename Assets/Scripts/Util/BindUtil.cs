using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 特性工具类：用于prefab和script的绑定和获取
/// </summary>
public class BindUtil
{
    /// <summary>
    /// prefab路径和对应脚本的映射
    /// </summary>
    private static Dictionary<string, Type> _prefabAndScriptMap = new Dictionary<string, Type>();

    /// <summary>
    /// 绑定当前路径和一个type类型
    /// </summary>
    public static void Bind(string path,Type type) {
        if (!_prefabAndScriptMap.ContainsKey(path))
        {
            _prefabAndScriptMap.Add(path,type);
        }
        else {
            Debug.LogError("当前数据中已存在路径："+path);
        }
    }

    public static Type GetType(string path) {
        if (_prefabAndScriptMap.ContainsKey(path))
        {
            return _prefabAndScriptMap[path];
        }
        else {
            Debug.LogError("当前数据中未包含路径："+path);
            return null;
        }
    }
}
