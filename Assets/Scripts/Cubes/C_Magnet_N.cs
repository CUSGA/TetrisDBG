using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Magnet_N : Cube
{
    public override void ClearAction()
    {
        //获取坐标，也就是在Cube在Grid二维数组中的位置
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        for (int x = posX; x < BattleManager.width; x++)
        {
            if (BattleManager.Instance.grid[x, posY] != null && BattleManager.Instance.grid[x, posY].GetComponent<CubeHolder>().cube.cubeData.cubeEnName == "Magnet_S")
            {
                Debug.Log("磁石南触发");
                BattleManager.Instance.effectAttack += 3;
                return;
            }
        }
        Debug.Log("磁石南触发失败");
        BattleManager.Instance.effectAttack += 1;
    }
}
