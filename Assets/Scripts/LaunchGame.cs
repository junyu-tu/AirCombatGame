using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    private string json = "{'planes':[{'planeId':0,'level':1,'attack':5,'fireRate':0.8,'life':100}]}";

    // Start is called before the first frame update
    void Start()
    {
        InitCustomAttributes initAtt = new InitCustomAttributes();
        initAtt.Init();

        //LoadMgr.Single.LoadPrefab(Paths.START_VIEW, transform);
        UIMgr.Single.Show(Paths.START_VIEW);


        //测试 缓存命令
        //KeyQueue queue = new KeyQueue();
        //Key key = new Key();
        //key.Set(1);
        //queue.Enqueue(key);
        //key = new Key();
        //key.Set("sss");
        //queue.Enqueue(key);

        //foreach (var item in queue)
        //{
        //    Debug.Log(item);
        //}

        //测试  正常读取 json 情况  先加载数据 然后读取 
        //JsonReader reader = new JsonReader();
        //reader.SetData(json);
        //reader["planes"][0]["planeId"].Get<int>((value) => Debug.Log(value));

        //测试 非正常情况 也就是 先去读取数据了 但是数据还在加载过程中  
        //JsonReader reader = new JsonReader();
        //reader["planes"][0]["planeId"].Get<int>((value) => Debug.Log(value));
        //reader.SetData(json);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
