using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckExplorer : MonoBehaviour
{
    [Tooltip("չʾ�����з����λ��")]
    public Transform desktop;

    [Tooltip("��ʾ��ǰ�����ͣ�������ݵ�Tooltip")]
    public GameObject deckExplorerTooltip;

    [Tooltip("DeckCubeԤ����")]
    public GameObject deckCube;

    //����PlayerManager�е����ݸ�����ʾ
    private void OnEnable()
    {
        //�����Desk�µ�����������
        for (int i = 0; i < desktop.childCount; i++)
        {
            Destroy(desktop.GetChild(i).gameObject);
        }

        //Ȼ���PlayerManager�ж�ȡ���ݷ��÷���
        foreach (GameObject item in PlayerManager.Instance.tempDeck)
        {
            int n = item.GetComponent<Cube>().cubeData.cubeCode;
            DeckCube dc = Instantiate(deckCube, desktop).GetComponent<DeckCube>();
            dc.SetCube(item);
        }
    }

    public void CloseExplorer()
    {
        gameObject.SetActive(false);
    }
}
