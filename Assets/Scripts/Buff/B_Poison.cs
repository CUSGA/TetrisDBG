using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Poison : Buff
{
    public override void TriggerAction()
    {
        EnemyManager.Instance.currentEnemy.BeAttack(EnemyManager.Instance.currentEnemy.buffPoisonNum);
        EnemyManager.Instance.currentEnemy.buffPoisonNum = Mathf.FloorToInt(EnemyManager.Instance.currentEnemy.buffPoisonNum / 2);

        UIManager.Instance.UpdateUI();
    }

    public override string GetInfo()
    {
        return "ÿ�� <color=red>" + triggerTime + "</color> �봥��һ�Σ�\nÿ����ɲ����� <color=red>" + EnemyManager.Instance.currentEnemy.buffPoisonNum + "</color> �����˺�\n" +
            "ÿ�δ�����״̬�������롣";
    }
}
