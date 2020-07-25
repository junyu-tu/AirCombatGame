using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : NormalSingleton<UIMgr>
{
    /// <summary>
    /// 存储当前界面的路径  
    /// </summary>
    private Stack<string> _uiStack = new Stack<string>();

    /// <summary>
    /// 存储当前界面的路径和对应的View
    /// </summary>
    private Dictionary<string, IView> _views = new Dictionary<string, IView>();

    private Canvas _canvas;
    public Canvas Canvas {
        get {
            if (_canvas == null) {
                _canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
            }

            if (_canvas == null)
            {
                Debug.LogError("场景中没有Canvas");
            }

            return _canvas;
        }
    }

    /// <summary>
    /// 显示新的UI  同时隐藏最上层的UI
    /// 按逻辑仅仅覆盖UI 并没有什么问题；但是会重复绘制，影响性能
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public IView Show(string path) {
        //现将stack里面的最上面的UI View进行隐藏
        if (_uiStack.Count > 0) {
            string name = _uiStack.Peek();
            _views[name].Hide();
        }

        //将最先的UI View进行显示 并入栈
        IView view = InitView(path);
        view.Show();
        _uiStack.Push(path);
        _views[path] = view;

        return view;
    }

    /// <summary>
    /// 实例化UI Prefab
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private IView InitView(string path) {
        if (_views.ContainsKey(path))
        {
            return _views[path];
        }
        else {
            GameObject viewGo = LoadMgr.Single.LoadPrefab(path,Canvas.transform);
            Type type = BindUtil.GetType(path);
            var component = viewGo.AddComponent(type);
            IView view = null;
            //必须得判断下 脚本是否实现了IView接口
            if (component is IView)
            {
                view = component as IView;
                view.Init();
            }
            else {
                Debug.Log("当前添加脚本未继承ViewBase");
            }
            
            return view;
        }
    }

    /// <summary>
    /// 返回方法：退回到上一个UI界面
    /// </summary>
    public void Back() {
        if (_uiStack.Count <=1) {
            return;
        }

        string name = _uiStack.Pop();
        _views[name].Hide();

        name = _uiStack.Peek();
        _views[name].Show();
    }
}
