using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FinalBoss : Enemy
{
    [Header("在这里设置Enemy技能的参数，即Enemy的初始Act的属性。I代表初始的意思")]
    [Tooltip("攻击的层数")]
    public int actAttackNum_I;
    [Tooltip("攻击的触发间隔。若大于0，则会覆盖攻击的默认触发间隔。")]
    public float actAttackTime_I;
    [Tooltip("战斗武装的层数")]
    public int actArmorUpNum_I;
    [Tooltip("战斗武装的触发间隔。若大于0，则会覆盖战斗武装的默认触发间隔。")]
    public float actArmorUpTime_I;
    [Tooltip("恶魔呼唤的层数")]
    public int actCallOfDemonNum_I;
    [Tooltip("恶魔呼唤的触发时间")]
    public int actCallOfDemonTime_I;

    private new void Start()
    {
        base.Start();

        //lastArmorUpTime = actArmorUpTime;

        //设置普通攻击。
        EnemyManager.Instance.currentEnemy.actAttackNum = actAttackNum_I;
        //在这里给Enemy的行动赋初值。然后在Act的自己的实例内，初始化时会根据所有者的当前数据来决定是选用默认数据还是用所有者的数据。
        EnemyManager.Instance.currentEnemy.actAttackTime = actAttackTime_I;

        //设置战斗武装。
        EnemyManager.Instance.currentEnemy.actArmorUpNum = actArmorUpNum_I;
        EnemyManager.Instance.currentEnemy.actArmorUpTime = actArmorUpTime_I;

        EnemyManager.Instance.currentEnemy.actCallOfDemonNum = actCallOfDemonNum_I;
        EnemyManager.Instance.currentEnemy.actCallOfDemonTime = actCallOfDemonTime_I;



        UIManager.Instance.UpdateUI();
    }
}
