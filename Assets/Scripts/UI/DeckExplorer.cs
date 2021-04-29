using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckExplorer : MonoBehaviour
{
    [Tooltip("展示所持有方块的位置")]
    public GameObject deskTop;

    [Tooltip("显示当前鼠标悬停方块数据的Tooltip")]
    public GameObject deckExplorerTooltip;

    [Tooltip("DeckCube预制体")]
    public GameObject deckCube;

    private float count;
    private float eachHeight;

    private void Start()
    {
        count = deskTop.GetComponent<GridLayoutGroup>().constraintCount;
        eachHeight = deskTop.GetComponent<GridLayoutGroup>().cellSize.y + deskTop.GetComponent<GridLayoutGroup>().spacing.y;
    }

    //根据PlayerManager中的数据更新显示
    private void OnEnable()
    {
        //先清空Desk下的所有子物体
        while(deskTop.transform.childCount > 0)
        {
            DestroyImmediate(deskTop.transform.GetChild(0).gameObject);
            Debug.Log("Destroy");
        }

        //然后从PlayerManager中读取数据放置方块
        foreach (GameObject item in PlayerManager.Instance.tempDeck)
        {
            int n = item.GetComponent<Cube>().cubeData.cubeCode;
            DeckCube dc = Instantiate(deckCube, deskTop.transform).GetComponent<DeckCube>();
            dc.SetCube(item);
        }
        //DEBUG:
        DeckUIManager.Instance.UpdateDeskTopHeight();
        //MapUIManager.Instance.UpdateDeskTopHeight();
        //UpdateDeskTopHeight();
    }

    //我把MapUIManager中的UpdateDeskTopHeight及其相关内容全部复制过来了
    public void UpdateDeskTopHeight()
    {
        float childHeight;
        childHeight = eachHeight * Mathf.Ceil((float)(deskTop.transform.childCount / count));
        if (deskTop.transform.childCount > 2)
            Debug.Log(deskTop.transform.childCount);
        float parHeight;
        parHeight = deskTop.GetComponent<RectTransform>().rect.height;
        float newHeight;
        newHeight = parHeight > childHeight ? parHeight : childHeight;
        deskTop.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
    }

    public void CloseExplorer()
    {
        gameObject.SetActive(false);
    }
}
