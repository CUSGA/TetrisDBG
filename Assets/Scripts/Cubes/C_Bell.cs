using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Bell : Cube
{
    public override void ClearAction()
    {
        //获取坐标，也就是在Cube在Grid二维数组中的位置
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        Debug.Log("我是：" + name + "，我的坐标是：(" + posX + ", " + posY + ")");

        int fX = posX - 1;
        int fY = posY - 1;

        int mX = posX + 1;
        int mY = posY + 1;

        for (int ffY = fY; ffY <= mY; ffY++)
        {
            if (ffY < 0 || ffY > BattleManager.height - 1)
            {
                continue;
            }
            for (int ffX = fX; ffX <= mX; ffX++)
            {
                if (ffX < 0 || ffX > BattleManager.width - 1)
                {
                    continue;
                }
                
                //BREAKPOINT: 检测当前检测的这块Cube是不是Bell，若不是才触发它的效果。
                if (BattleManager.Instance.grid[ffX, ffY] != null && BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.name != "Cube_Bell(Clone)")
                {
                    BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.ClearAction();
                    Debug.Log("坐标为（" + ffX + ", " + ffY + ")的" + BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.name + "触发效果");
                }else
                {
                    Debug.Log("坐标为（" + ffX + ", " + ffY + ")的不触发效果。");
                }
            }
        }
    }
}
