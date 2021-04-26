using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BomberAirShip : Enemy
{
    [Header("在这里设置Enemy技能的参数，即Enemy_Basic的初始Act的属性。I代表初始的意思")]
    [Tooltip("空袭炸弹的层数")]
    public int actAirRaidNum_I;
    [Tooltip("空袭炸弹的触发时间")]
    public int actAirRaidTime_I;

    private new void Start()
    {
        base.Start();

        EnemyManager.Instance.currentEnemy.actAirRaidNum = actAirRaidNum_I;
        EnemyManager.Instance.currentEnemy.actAirRaidTime = actAirRaidTime_I;

        UIManager.Instance.UpdateUI();
    }
}
