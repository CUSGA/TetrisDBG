using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_ArmorUp : Act
{
    protected new void Start()
    {
        if (EnemyManager.Instance.currentEnemy.actArmorUpTime > 0)
        {
            triggerTime = EnemyManager.Instance.currentEnemy.actArmorUpTime;
        }
        base.Start();
    }

    //每次触发，所有者护盾+层数。
    public override void TriggerAction()
    {
        if (belong == 0)
        {
            Debug.LogWarning("增加玩家的防御");
            PlayerManager.Instance.buffShield += PlayerManager.Instance.actArmorUpNum;
        }else if (belong == 1)
        {
            //Debug.LogWarning("增加敌人的防御" + EnemyManager.Instance.currentEnemy.actArmorUpNum);
            EnemyManager.Instance.currentEnemy.buffShieldNum += EnemyManager.Instance.currentEnemy.actArmorUpNum;
        }
        else
        {
            Debug.LogError("你Buff的归属搞错了");
        }
        UIManager.Instance.UpdateUI();
    }

    public override string GetInfo()
    {
        if (belong == 0)
        {
            return "每 <color=red>" + triggerTime + "</color> 秒钟触发一次，每次增加 <color=red>" + PlayerManager.Instance.actArmorUpNum + "</color> 层护甲。";
        }
        else
        {
            return "每 <color=red>" + triggerTime + "</color> 秒钟触发一次，每次增加 <color=red>" + EnemyManager.Instance.currentEnemy.actArmorUpNum + "</color> 层护甲。";
        }
    }
}
