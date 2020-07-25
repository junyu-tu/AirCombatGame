using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMgr : NormalSingleton<LoadMgr>
{
    private ILoader _loader;

    public LoadMgr() {
        _loader = new ResourceLoader();
    }

    public GameObject LoadPrefab(string path,Transform parent = null)
    {
        //通过类型名挂载脚本
        //GameObject temp = _loader.LoadPrefab(path, parent);
        //Type type =  Type.GetType(temp.name.Remove(temp.name.Length-7));
        //temp.AddComponent(type);

        //通过特性来绑定脚本和prefab
        GameObject temp = _loader.LoadPrefab(path, parent);
        //Type type = BindUtil.GetType(path);
        //temp.AddComponent(type);
        return temp;
    }
}
