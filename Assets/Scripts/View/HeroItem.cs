using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour
{
    private Color defaultColor = Color.gray;
    private Color selectColor = Color.white;
    private float time = 0.5f;
    private Image img;
    //使用一个委托 来重置三个按钮的颜色
    private Action callBack;

    // Start is called before the first frame update
    void Start()
    {
        img = transform.GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(SelectButton);
        UnSelectButton();
    }

    private void SelectButton()
    {
        callBack?.Invoke();
        //在执行颜色变化的时候 需要执行这一句 不然颜色的变化会有问题
        img.DOKill();
        img.DOColor(selectColor, time);
    }

    public void UnSelectButton()
    {
        img.DOKill();
        img.DOColor(defaultColor, time);
    }

    public void AddResetListener(Action action) {
        callBack = action;
    }
}
