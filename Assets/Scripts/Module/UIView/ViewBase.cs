using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewBase : MonoBehaviour, IView
{
    private UiUtil _uiutil;
    protected UiUtil UIUtil {
        get {
            if (_uiutil == null) {
                _uiutil = gameObject.AddComponent<UiUtil>();
                _uiutil.Init();
            }
            return _uiutil;
        }
    }

    public virtual void Init()
    {
        
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }


    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }


   
}
