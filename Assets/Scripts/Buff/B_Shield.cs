using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Shield : Buff
{
    //ÿ�δ����������߻���-1��
    public override void TriggerAction()
    {
        if (belong == 0)
        {
            PlayerManager.Instance.buffShield -= 1;
            int i = PlayerManager.Instance.buffShield;
        }else if (belong == 1)
        {
            EnemyManager.Instance.currentEnemy.buffShield -= 1;
            int i = EnemyManager.Instance.currentEnemy.buffShield;
        }else
        {
            Debug.LogError("��Buff�Ĺ��������");
        }
        UIManager.Instance.UpdateUI();
    }

    public override string GetInfo()
    {
        return "ÿ�㻤�ܿɵ���1���ܵ����˺���\nÿ�� <color=red>" + triggerTime +"</color> �봥��һ�Σ�ÿ�μ���һ�㻤�ܡ�";
    }
}
