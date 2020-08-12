using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABLoader : ILoader
{
    public void LoadConfig(string path, Action<object> complete)
    {
        throw new NotImplementedException();
    }

    GameObject ILoader.LoadPrefab(string path, Transform parent)
    {
        throw new System.NotImplementedException();
    }
}
