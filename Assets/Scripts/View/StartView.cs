using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BindPrefab(Paths.START_VIEW)] //这个特性 相当于给这个类多添加了一份存储信息
public class StartView : ViewBase
{
    public override void Init()
    {
        UIUtil.Get("startbtn").AddListener(()=> {
            Debug.Log("hello");
            UIMgr.Single.Show(Paths.SELECTED_HERO_VIEW);
        });
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
