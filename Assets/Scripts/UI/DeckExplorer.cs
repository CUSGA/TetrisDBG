using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckExplorer : MonoBehaviour
{
    [Tooltip("展示所持有方块的位置")]
    public Transform desktop;

    [Tooltip("显示当前鼠标悬停方块数据的Tooltip")]
    public GameObject deckExplorerTooltip;

    [Tooltip("DeckCube预制体")]
    public GameObject deckCube;

    //根据PlayerManager中的数据更新显示
    private void OnEnable()
    {
        //先清空Desk下的所有子物体
        while(desktop.childCount > 0)
        {
            DestroyImmediate(desktop.GetChild(0).gameObject);
            Debug.Log("Destroy");
        }

        //然后从PlayerManager中读取数据放置方块
        foreach (GameObject item in PlayerManager.Instance.tempDeck)
        {
            int n = item.GetComponent<Cube>().cubeData.cubeCode;
            DeckCube dc = Instantiate(deckCube, desktop).GetComponent<DeckCube>();
            dc.SetCube(item);
        }
        MapUIManager.Instance.UpdateDeskTopHeight();
    }

    public void CloseExplorer()
    {
        gameObject.SetActive(false);
    }
}
