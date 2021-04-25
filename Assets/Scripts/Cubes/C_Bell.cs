using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Bell : Cube
{
    public override void ClearAction()
    {
        //��ȡ���꣬Ҳ������Cube��Grid��ά�����е�λ��
        int posX = Mathf.RoundToInt(transform.position.x);
        int posY = Mathf.RoundToInt(transform.position.y);

        Debug.Log("���ǣ�" + name + "���ҵ������ǣ�(" + posX + ", " + posY + ")");

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
                
                //BREAKPOINT: ��⵱ǰ�������Cube�ǲ���Bell�������ǲŴ�������Ч����
                if (BattleManager.Instance.grid[ffX, ffY] != null && BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.name != "Cube_Bell(Clone)")
                {
                    BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.ClearAction();
                    Debug.Log("����Ϊ��" + ffX + ", " + ffY + ")��" + BattleManager.Instance.grid[ffX, ffY].GetComponent<CubeHolder>().cube.name + "����Ч��");
                }else
                {
                    Debug.Log("����Ϊ��" + ffX + ", " + ffY + ")�Ĳ�����Ч����");
                }
            }
        }
    }
}
