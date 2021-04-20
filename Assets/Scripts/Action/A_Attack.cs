using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是最基础的攻击动作例子，说白了就是测试用的
public class A_Attack : Act
{
    //因为Attack这个动作比较特殊，有两个参数来描述它，所以修改Start
    private void Start()
    {
        triggerTime = EnemyManager.Instance.currentEnemy.actAttackTime;
        lastTriggerTime = triggerTime;
    }

    public override void TriggerAction()
    {
        if (belong == 0)
        {
            EnemyManager.Instance.currentEnemy.BeAttack(PlayerManager.Instance.actAttack);
        }
        else if (belong == 1)
        {
            PlayerManager.Instance.BeAttack(EnemyManager.Instance.currentEnemy.actAttack);
        }
        //这里的UpdateUI在BeAttack中执行了，不用在这里调用。
    }
}
