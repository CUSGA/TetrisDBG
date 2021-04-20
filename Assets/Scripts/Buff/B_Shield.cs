using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Shield : Buff
{
    //每次触发，所有者护盾-1；
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
            Debug.LogError("你Buff的归属搞错了");
        }
        UIManager.Instance.UpdateUI();
    }
}
