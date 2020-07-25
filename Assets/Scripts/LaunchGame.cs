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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
