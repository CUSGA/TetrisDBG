using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Magnet_S : Cube
{
    public override void ClearAction()
    {
        //获取坐标，也就是在Cube在Grid二维数组中的位置
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        for (int x = posX; x >= 0; x--)
        {
            if (BattleManager.Instance.grid[x, posY] != null && BattleManager.Instance.grid[x, posY].GetComponent<CubeHolder>().cube.cubeData.cubeEnName == "Magnet_N")
            {
                Debug.Log("磁石北触发");
                BattleManager.Instance.effectAttack += 3;
                return;
            }
        }
        Debug.Log("磁石北触发失败");
        BattleManager.Instance.effectAttack += 1;
    }
}
