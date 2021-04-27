using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是最基础的攻击动作例子，说白了就是测试用的
public class A_Attack : Act
{
    private void Start()
    {
        //TODO: 所有者。所有的Act都要修改这里。
        //若所有者的攻击动作的初值大于零，就用该值覆盖默认值。
        if (belong == 0)
        {
            if (PlayerManager.Instance.actAttackTime > 0)
            {
                triggerTime = PlayerManager.Instance.actAttackTime;
            }
        }
        if (belong == 1)
        {
            if (EnemyManager.Instance.currentEnemy.actAttackTime > 0)
            {
                triggerTime = EnemyManager.Instance.currentEnemy.actAttackTime;
            }
        }
        lastTriggerTime = triggerTime;
    }

    public override void TriggerAction()
    {
        if (belong == 0)
        {
            EnemyManager.Instance.currentEnemy.BeAttack(PlayerManager.Instance.actAttackNum);
        }
        else if (belong == 1)
        {
            PlayerManager.Instance.BeAttack(EnemyManager.Instance.currentEnemy.actAttackNum);
        }
        //这里的UpdateUI在BeAttack中执行了，不用在这里调用。
    }

    public override string GetInfo()
    {
        if (belong == 0)
        {
            return "每隔 <color=red>" + triggerTime + "</color> 秒触发一次，每次对对方造成 <color=red>" + PlayerManager.Instance.actAttackNum + "</color> 点伤害。";
        }
        else
        {
            return "每隔 <color=red>" + triggerTime + "</color> 秒触发一次，每次对对方造成 <color=red>" + EnemyManager.Instance.currentEnemy.actAttackNum + "</color> 点伤害。";
        }
    }
}
