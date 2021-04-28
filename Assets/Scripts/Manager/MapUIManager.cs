using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIManager : Singleton<MapUIManager>
{
    public GameObject deckExplorer;
    public GameObject deskTop;

    private float count;
    private float eachHeight;

    public void Start()
    {
        count = deskTop.GetComponent<GridLayoutGroup>().constraintCount;
        eachHeight = deskTop.GetComponent<GridLayoutGroup>().cellSize.y + deskTop.GetComponent<GridLayoutGroup>().spacing.y;
    }

    public void OpenDeckExplorer()
    {
        deckExplorer.SetActive(true);
    }

    public void UpdateDeskTopHeight() 
    {
        float childHeight;
        childHeight = eachHeight * Mathf.Ceil((float)(deskTop.transform.childCount / count));
        if(deskTop.transform.childCount > 2)
            Debug.Log(deskTop.transform.childCount);
        float parHeight;
        parHeight = deskTop.GetComponent<RectTransform>().rect.height;
        float newHeight;
        newHeight = parHeight > childHeight ? parHeight : childHeight;
        deskTop.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
    }
}
