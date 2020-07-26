using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这里可以将DataMgr理解为一个小霸王，PlayerPrefsMemory和JsonMemory理解为游戏卡，你想“玩”哪种存储方式 就用哪种
//LoadMgr那边类似
public class DataMgr : NormalSingleton<DataMgr>,IDataMemory
{
    private IDataMemory dataMenory;

    public DataMgr() {
        
        dataMenory = new PlayerPrefsMemory();
    }

    public T Get<T>(string key)
    {
        return dataMenory.Get<T>(key);
    }

    public void Set<T>(string key, T value)
    {
        dataMenory.Set(key,value);
    }

    public void Clear(string key)
    {
        dataMenory.Clear(key);
    }

    public void ClearAll()
    {
        dataMenory.ClearAll();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
