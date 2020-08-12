using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 判断文件的后缀名 从而得到相关的reader
/// </summary>
public class ReaderConfig
{
    private static readonly Dictionary<string, Func<IReader>> readerDic = new Dictionary<string, Func<IReader>>() {
        { ".json",()=>new JsonReader()}
    };

    /// <summary>
    /// 根据文件 获得对应的读取器
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static IReader GetReader(string path)
    {
        foreach (KeyValuePair<string,Func<IReader>> pair in readerDic)
        {
            if (path.Contains(pair.Key)) {
                return pair.Value();
            }
        }

        Debug.LogError("未找到对应文件的读取器，文件路径："+path);
        return null;
    }
}
