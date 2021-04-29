using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DemonLeader : Enemy
{
    [Header("在这里设置Enemy技能的参数，即Enemy的初始Act的属性。I代表初始的意思")]
    [Tooltip("恶魔呼唤的层数")]
    public int actCallOfDemonNum_I;
    [Tooltip("恶魔呼唤的触发时间")]
    public int actCallOfDemonTime_I;

    private new void Start()
    {
        base.Start();

        EnemyManager.Instance.currentEnemy.actCallOfDemonNum = actCallOfDemonNum_I;
        EnemyManager.Instance.currentEnemy.actCallOfDemonTime = actCallOfDemonTime_I;

        UIManager.Instance.UpdateUI();
    }
}
