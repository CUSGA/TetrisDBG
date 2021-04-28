using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : Singleton<ShopUIManager>
{
    public GameObject deckExplorer;
    public Tooltip tooltip;

    [Header("三个商品陈列")]
    public Button goodHolder_1;
    public Button goodHolder_2;
    public Button goodHolder_3;

    public void OpenDeckExplorer()
    {
        deckExplorer.SetActive(true);
    }

    public void CloseAllGoodHolder()
    {
        goodHolder_1.interactable = false;
        goodHolder_2.interactable = false;
        goodHolder_3.interactable = false;
    }
}
