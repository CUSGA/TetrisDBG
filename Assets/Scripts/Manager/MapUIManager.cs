using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager>
{
    public GameObject deckExplorer;

    public void OpenDeckExplorer()
    {
        deckExplorer.SetActive(true);
    }
}
