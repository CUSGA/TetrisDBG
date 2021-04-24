using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ArmorUp : Act
{
    private void Start()
    {
        if (EnemyManager.Instance.currentEnemy.actArmorUpTime > 0)
        {
            triggerTime = EnemyManager.Instance.currentEnemy.actArmorUpTime;
        }
        lastTriggerTime = triggerTime;
    }

    //ÿ�δ����������߻���+������
    public override void TriggerAction()
    {
        if (belong == 0)
        {
            Debug.LogWarning("������ҵķ���");
            PlayerManager.Instance.buffShield += PlayerManager.Instance.actArmorUp;
        }else if (belong == 1)
        {
            Debug.LogWarning("���ӵ��˵ķ���" + EnemyManager.Instance.currentEnemy.actArmorUpNum);
            EnemyManager.Instance.currentEnemy.buffShield += EnemyManager.Instance.currentEnemy.actArmorUpNum;
        }
        else
        {
            Debug.LogError("��Buff�Ĺ��������");
        }
        UIManager.Instance.UpdateUI();
    }

    public override string GetInfo()
    {
        return "ÿ <color=red>" + triggerTime + "</color> ���Ӵ���һ�Σ�ÿ������ <color=red>" + EnemyManager.Instance.currentEnemy.actArmorUpNum + "</color> �㻤�ס�";
    }
}
