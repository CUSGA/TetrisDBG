using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Feather : Cube
{
    public override void ClearAction()
    {
        int dmg = 0;//总共能造成的伤害数

        //获取坐标，也就是在Cube在Grid二维数组中的位置
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

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

                if (BattleManager.Instance.grid[ffX, ffY] == null)
                {
                    dmg += 1;
                }
            }
        }

        BattleManager.Instance.effectAttack += dmg;
        Debug.Log("我是：" + name + "，我的坐标是：(" + posX + ", " + posY + ")，我造成了" + dmg + "点伤害");
    }
}
