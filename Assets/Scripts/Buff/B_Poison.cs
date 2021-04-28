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
        return "每隔 <color=red>" + triggerTime + "</color> 秒触发一次，每次造成层数（ <color=red>" + EnemyManager.Instance.currentEnemy.buffPoisonNum + "</color> ）的伤害\n" +
            "每次触发层数减半。";
    }
}
