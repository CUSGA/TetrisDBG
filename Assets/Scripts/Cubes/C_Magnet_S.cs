using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Magnet_S : Cube
{
    public override void ClearAction()
    {
        //��ȡ���꣬Ҳ������Cube��Grid��ά�����е�λ��
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        for (int x = posX; x >= 0; x--)
        {
            if (BattleManager.Instance.grid[x, posY] != null && BattleManager.Instance.grid[x, posY].GetComponent<CubeHolder>().cube.cubeData.cubeEnName == "Magnet_N")
            {
                Debug.Log("��ʯ������");
                BattleManager.Instance.effectAttack += 3;
                return;
            }
        }
        Debug.Log("��ʯ������ʧ��");
        BattleManager.Instance.effectAttack += 1;
    }
}
