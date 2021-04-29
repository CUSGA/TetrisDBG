using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Feather : Cube
{
    public override void ClearAction()
    {
        int dmg = 0;//�ܹ�����ɵ��˺���

        //��ȡ���꣬Ҳ������Cube��Grid��ά�����е�λ��
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
        Debug.Log("���ǣ�" + name + "���ҵ������ǣ�(" + posX + ", " + posY + ")���������" + dmg + "���˺�");
    }
}
