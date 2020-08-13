using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 携程管理类   控制流程：  开始  暂停  继续  停止   重新开始   对应需要创建一个枚举（闭包枚举）
/// 对外的接口
/// </summary>
public class CoroutineMgr : MonoSingleton<CoroutineMgr>
{
    /// <summary>
    /// 重复执行
    /// </summary>
    /// <param name="routine"></param>
    public void Execute(IEnumerator routine,bool autoStart = true) { 
        
    }

    /// <summary>
    /// 加载资源 只执行一次
    /// </summary>
    /// <param name="routine"></param>
    public void ExecuteOnce(IEnumerator routine)
    {

    }
}
