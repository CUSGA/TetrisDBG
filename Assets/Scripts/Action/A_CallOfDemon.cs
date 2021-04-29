using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CallOfDemon : Act
{
    public GameObject littleDemonCube;

    public override void TriggerAction()
    {
        List<GameObject> allCubeOnDesk = new List<GameObject>();

        //�����еķ���ŵ�һ��������
        foreach (Transform cube in BattleManager.Instance.grid)
        {
            if (cube != null)
            {
                allCubeOnDesk.Add(cube.gameObject);
            }
        }

        if (EnemyManager.Instance.currentEnemy.actCallOfDemonNum >= allCubeOnDesk.Count)
        {
            Debug.Log("ֱ�Ӱ�ȫ���ĳ�С��ħ");
            foreach (var item in allCubeOnDesk)
            {
                item.GetComponent<CubeHolder>().ChangeCube(littleDemonCube);
            }
        }else
        {
            int nowL = allCubeOnDesk.Count;
            for (int i = 0; i < EnemyManager.Instance.currentEnemy.actCallOfDemonNum; i++)
            {
                int n = Random.Range(0, nowL);
                Debug.Log("����һ��" + allCubeOnDesk[n].GetComponent<CubeHolder>().cube.cubeData.cubeName);
                allCubeOnDesk[n].GetComponent<CubeHolder>().ChangeCube(littleDemonCube);

                //λ�õ���
                allCubeOnDesk[n] = allCubeOnDesk[nowL - 1];
                nowL--;
            }
        }
    }

    public override string GetInfo()
    {
        return "ÿ�� <color=red>" + triggerTime + "</color> �봥��һ�Σ�\nÿ�ν����ϸ�״̬���� <color=red>��" + EnemyManager.Instance.currentEnemy.actCallOfDemonNum + "��</color> " +
            "���������ת���� <color=red>��С��ħ��</color> ���顣\n����ÿ��һ�� <color=red>��С��ħ��</color> ����״̬�����߻��һ�� <color=red>��������</color> ״̬��";
    }
}
