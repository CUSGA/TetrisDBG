using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckExplorer : MonoBehaviour
{
    [Tooltip("展示所持有方块的位置")]
    public Transform desktop;

    [Tooltip("显示当前鼠标悬停方块数据的Tooltip")]
    public GameObject deckExplorerTooltip;

    [Tooltip("存储所有方块的数组，注意顺序要跟编号一致")]
    public GameObject[] arrDeckCube;

    //根据PlayerManager中的数据更新显示
    private void OnEnable()
    {
        //先清空Desk下的所有子物体
        for (int i = 0; i < desktop.childCount; i++)
        {
            Destroy(desktop.GetChild(i).gameObject);
        }

        //然后从PlayerManager中读取数据放置方块
        foreach (GameObject item in PlayerManager.Instance.tempDeck)
        {
            int n = item.GetComponent<Cube>().cubeData.cubeCode;
            Instantiate(arrDeckCube[n], desktop);
        }
    }

    public void CloseExplorer()
    {
        gameObject.SetActive(false);
    }
}
