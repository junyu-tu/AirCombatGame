using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根据读取配置 创建不同文件格式的reader
/// </summary>
public class ReaderMgr : NormalSingleton<ReaderMgr>
{
    private Dictionary<string, IReader> _readersDic = new Dictionary<string, IReader>();

    public IReader GetReader(string path) 
    {
        IReader reader = null;
        if (_readersDic.ContainsKey(path))
        {
            reader =  _readersDic[path];
        }
        else {
            //从当前的配置中，获取一个新的reader
            reader = ReaderConfig.GetReader(path);
            if (reader != null)
            {
                //读取当前路径配置数据，赋值给reader
                _readersDic[path] = reader;
            }
            else {
                Debug.LogError("未获取到对应的reader,路径："+path);
            }
        }
        return reader;
    }
}
