using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHero : MonoBehaviour
{
    private List<HeroItem> _items = null;

    void Start()
    {
        _items = new List<HeroItem>(transform.childCount);
        HeroItem item = null;
        foreach (Transform Trans in transform)
        {
            item = Trans.gameObject.AddComponent<HeroItem>();
            item.AddResetListener(ResetState);
            _items.Add(item);
        }
    }

    private void ResetState() {
        foreach (var item in _items)
        {
            item.UnSelectButton();
        }
    }

}
