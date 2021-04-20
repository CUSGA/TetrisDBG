using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ArmorUp : Act
{
    //每次触发，所有者护盾+层数。
    public override void TriggerAction()
    {
        if (belong == 0)
        {
            Debug.LogWarning("增加玩家的防御");
            PlayerManager.Instance.buffShield += PlayerManager.Instance.actArmorUp;
        }else if (belong == 1)
        {
            Debug.LogWarning("增加敌人的防御" + EnemyManager.Instance.currentEnemy.actArmorUp);
            EnemyManager.Instance.currentEnemy.buffShield += EnemyManager.Instance.currentEnemy.actArmorUp;
        }
        else
        {
            Debug.LogError("你Buff的归属搞错了");
        }
        UIManager.Instance.UpdateUI();
    }
}
