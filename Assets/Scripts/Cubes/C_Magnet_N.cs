using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Magnet_N : Cube
{
    public override void ClearAction()
    {
        //��ȡ���꣬Ҳ������Cube��Grid��ά�����е�λ��
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        for (int x = posX; x < BattleManager.width; x++)
        {
            if (BattleManager.Instance.grid[x, posY] != null && BattleManager.Instance.grid[x, posY].GetComponent<CubeHolder>().cube.cubeData.cubeEnName == "Magnet_S")
            {
                Debug.Log("��ʯ�ϴ���");
                BattleManager.Instance.effectAttack += 3;
                return;
            }
        }
        Debug.Log("��ʯ�ϴ���ʧ��");
        BattleManager.Instance.effectAttack += 1;
    }
}
