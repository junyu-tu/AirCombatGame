using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//C# 特性（attribute）是被指定给某一声明的一则附加的声明性信息

/// <summary>
/// 自定义特性：用于绑定类和prefab
/// 特性的作用：实际上就是存储相关的信息；然后通过反射将特性里面的信息映射出来
/// </summary>
[AttributeUsage(AttributeTargets.Class)]  //说明当前特性用于什么
public class BindPrefabAttribute : Attribute
{
    public string Path { get; private set; }

    public BindPrefabAttribute(string path) {
        this.Path = path;
    }
}
