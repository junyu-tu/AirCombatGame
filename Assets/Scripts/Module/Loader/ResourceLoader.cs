using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : ILoader
{
    public GameObject LoadPrefab(string path,Transform parent = null)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject temp = Object.Instantiate(prefab,parent);
        return temp;
    }
}
