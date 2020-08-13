using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制流程的接口
/// </summary>
public class CoroutineController : MonoBehaviour
{
    public enum CoroutineState{ 
        WAITTING,
        RUNNING,
        PAUSED,
        STOP
    }

    public CoroutineState State { get; set; }

    public IEnumerator Body(IEnumerator routine) {

        yield return null; //等待一帧  返回某个值
    }

}
