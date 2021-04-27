using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIManager : Singleton<ShopUIManager>
{
    public GameObject deckExplorer;

    public void OpenDeckExplorer()
    {
        deckExplorer.SetActive(true);
    }
}
