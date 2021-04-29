using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Cherry : Cube
{

    public override void ClearAction()
    {
        int connectNum = 0;//与之相连的其他樱桃数

        //获取坐标，也就是在Cube在Grid二维数组中的位置
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        //Debug.Log("我是：" + name + "，我的坐标是：(" + posX + ", " + posY + ")");

        int fX = posX - 1;
        int fY = posY - 1;

        int mX = posX + 1;
        int mY = posY + 1;

        if (isCherry(posX, fY))
            connectNum += 1;
        if (isCherry(fX, posY))
            connectNum += 1;
        if (isCherry(mX, posY))
            connectNum += 1;
        if (isCherry(posX, mY))
            connectNum += 1;

        switch (connectNum)
        {
            case 0: BattleManager.Instance.effectAttack += 0;break;
            case 1: BattleManager.Instance.effectAttack += 1;break;
            case 2: BattleManager.Instance.effectAttack += 3; break;
            case 3: BattleManager.Instance.effectAttack += 6; break;
            case 4: BattleManager.Instance.effectAttack += 10; break;
        }
        //Debug.LogWarning("我是：" + name + "，我的坐标是：(" + posX + ", " + posY + ")，我的链接数是：" + connectNum);
    }

    bool isCherry(int ffX, int ffY)
    {
        if (ffY < 0 || ffY > BattleManager.height - 1)
        {
            return false;
        }
        if (ffX < 0 || ffX > BattleManager.width - 1)
        {
            return false;
        }

        if (BattleManager.Instance.grid[ffX, ffY] != null && BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.cubeData.cubeEnName == "Cherry")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
