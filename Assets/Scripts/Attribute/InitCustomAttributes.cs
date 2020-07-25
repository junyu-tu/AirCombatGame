using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
/// <summary>
/// 对自定义特性 进行初始化
/// </summary>
public class InitCustomAttributes
{
    public void Init() {

        //获得BindPrefab所在的程序集
        Assembly assembly = Assembly.GetAssembly(typeof(BindPrefabAttribute));
        //获取程序集当中所有的公有类型
        Type[] types = assembly.GetExportedTypes();

        //遍历类型
        foreach (var type in types)
        {
            //遍历Type类型所拥有的特性 找到对应的特性
            foreach (Attribute attr in Attribute.GetCustomAttributes(type,true))
            {
                if (attr is BindPrefabAttribute) {
                    BindPrefabAttribute data = attr as BindPrefabAttribute;
                    BindUtil.Bind(data.Path,type);
                }
            }
        }
    }
}
