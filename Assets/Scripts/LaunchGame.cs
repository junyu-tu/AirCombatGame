using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitCustomAttributes initAtt = new InitCustomAttributes();
        initAtt.Init();

        //LoadMgr.Single.LoadPrefab(Paths.START_VIEW, transform);
        UIMgr.Single.Show(Paths.START_VIEW);


        //test script
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
