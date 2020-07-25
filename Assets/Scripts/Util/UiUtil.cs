using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI工具类：便于查找物体（实际上就是查找Tra下的相关组件）
/// </summary>
public class UiUtil : MonoBehaviour
{
    /// <summary>
    /// 存储子节点的相关组件  key  子节点name  value 子节点上的相关组件
    /// </summary>
    private Dictionary<string, UiUtilData> _datas;

    public void Init() 
    {
        _datas = new Dictionary<string, UiUtilData>();
        RectTransform rect = transform.GetComponent<RectTransform>();
        //这里相当于遍历rect下的子节点
        foreach (RectTransform item in rect)
        {
            _datas.Add(item.name, new UiUtilData(item)) ;
        }
    }

    public UiUtilData Get(string name) 
    {
        if (_datas.ContainsKey(name))
        {
            return _datas[name];
        }
        else {
            //默认name是一个路径 去查找这个物体是否存在
            Transform temp = transform.Find(name);
            if (temp == null)
            {
                Debug.LogError("无法按照路径查找到物体，路径为：" + name);
                return null;
            }
            else {
                _datas.Add(name,new UiUtilData(temp.GetComponent<RectTransform>()));
                return _datas[name];
            }
        }
    }
}

/// <summary>
/// UI 数据类
/// </summary>
public class UiUtilData {
    public GameObject Go { get; private set; }
    public RectTransform RectTrans { get; private set; }
    public Button Btn { get; private set; }
    public Image Img { get; private set; }
    public Text Txt { get; private set; }

    public UiUtilData(RectTransform rectTrans) {
        RectTrans = rectTrans;
        Go = rectTrans.gameObject;
        Btn = rectTrans.GetComponent<Button>();
        Img = rectTrans.GetComponent<Image>();
        Txt = rectTrans.GetComponent<Text>();
    }

    public void AddListener(Action action) {
        if (Btn != null)
        {
            Btn.onClick.AddListener(() => action());
        }
        else {
            Debug.LogError("当前物体上没有Button组件，物体名称为："+Go.name);
        }
    }

    public void SetSprite(Sprite sprite) {
        if (Img != null) {
            Img.sprite = sprite;
        }
        else
        {
            Debug.LogError("当前物体上没有Image组件，物体名称为：" + Go.name);
        }
    }
}