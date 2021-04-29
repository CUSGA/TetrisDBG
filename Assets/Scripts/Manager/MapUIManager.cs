using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager>
{
    public GameObject shopButton;
    public int curLevel;
    public new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        if ((curLevel + 1) % 3 == 0)
        {
            shopButton.SetActive(true);
        }
        else
        {
            shopButton.SetActive(false);
        }
    }
}
