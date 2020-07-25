using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BindPrefab(Paths.SELECTED_HERO_VIEW)]
public class SelectedHeroView : ViewBase
{
    public override void Init()
    {
        UIUtil.Get("Heros").Go.AddComponent<SelectHero>();

        UIUtil.Get("OK/Start").AddListener(() => {
            //TODO:切换到选择关卡界面
        });

        UIUtil.Get("Exit").AddListener(() => {
            Application.Quit();
        });

        UIUtil.Get("Strengthen").AddListener(() => {
            //TODO:切换到强化界面
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
