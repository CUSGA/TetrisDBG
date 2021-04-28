using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_SpreadPoison : Cube
{
    public override void ClearAction()
    {
        EnemyManager.Instance.currentEnemy.buffPoisonNum += 1;

        //��ȡ���꣬Ҳ������Cube��Grid��ά�����е�λ��
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        Debug.Log("���ǣ�" + name + "���ҵ������ǣ�(" + posX + ", " + posY + ")");

        int fX = posX - 1;
        int fY = posY - 1;

        int mX = posX + 1;
        int mY = posY + 1;

        Infect(fX, fY);
        Infect(mX, fY);
        Infect(fX, mY);
        Infect(mX, mY);
    }

    void Infect(int ffX, int ffY)
    {
        if (ffY < 0 || ffY > BattleManager.height - 1)
        {
            return;
        }
        if (ffX < 0 || ffX > BattleManager.width - 1)
        {
            return;
        }

        if (BattleManager.Instance.grid[ffX, ffY] != null && BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.cubeData.cubeEnName != "SpreadPoison")
        {
            BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().ChangeCube(gameObject);
            Debug.Log("����Ϊ��" + ffX + ", " + ffY + ")�ѱ���ȾΪ" + BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.name);
        }
        else
        {
            Debug.Log("����Ϊ��" + ffX + ", " + ffY + ")�Ĳ�����Ч����");
        }
    }
}
