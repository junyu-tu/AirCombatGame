using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : ILoader
{

    public GameObject LoadPrefab(string path,Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject temp = UnityEngine.Object.Instantiate(prefab,parent);
        return temp;
    }


    public void LoadConfig(string path, Action<object> complete)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 根据路径去加载StreamingAsset 路径下的文件
    /// </summary>
    /// <param name="path"></param>
    /// <param name="complete"></param>
    /// <returns></returns>
    private IEnumerator Config(string path, Action<object> complete)
    {
        //这个会等文件加载好 再进行返回（携程中使用  异步）
        WWW www = new WWW(path);
        yield return www;

        //普通方法中使用WWW加载数据的方式：不推荐使用，因为会阻塞主线程（也就是程序会一直卡在这里）
        //WWW www = new WWW(path);
        //while(!www.isDone){ 
        //todo...
        //}

    }
}
