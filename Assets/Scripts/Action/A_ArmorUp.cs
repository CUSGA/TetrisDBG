using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ArmorUp : Act
{
    //ÿ�δ����������߻���+������
    public override void TriggerAction()
    {
        if (belong == 0)
        {
            Debug.LogWarning("������ҵķ���");
            PlayerManager.Instance.buffShield += PlayerManager.Instance.actArmorUp;
        }else if (belong == 1)
        {
            Debug.LogWarning("���ӵ��˵ķ���" + EnemyManager.Instance.currentEnemy.actArmorUp);
            EnemyManager.Instance.currentEnemy.buffShield += EnemyManager.Instance.currentEnemy.actArmorUp;
        }
        else
        {
            Debug.LogError("��Buff�Ĺ��������");
        }
        UIManager.Instance.UpdateUI();
    }
}
