using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : Enemy
{
    [Header("Enemy_Basic的初始Act的属性")]
    [Tooltip("攻击的层数")]
    public int actAtkNum;
    [Tooltip("攻击的间隔。覆盖攻击的默认间隔")]
    public float actAtkTime;
    [Tooltip("战斗武装的层数")]
    public int actArmorUpNum;
    /*[Tooltip("增加护盾间隔")]
    public float actArmorUpTime;
    float lastArmorUpTime;*/

    private new void Start()
    {
        base.Start();

        //lastArmorUpTime = actArmorUpTime;

        //设置普通攻击，攻击力 = 5，攻击周期 = 5；
        EnemyManager.Instance.currentEnemy.actAttack = actAtkNum;
        EnemyManager.Instance.currentEnemy.actAttackTime = actAtkTime;

        //设置战斗武装，层数 = 3
        EnemyManager.Instance.currentEnemy.actArmorUp = actArmorUpNum;

        UIManager.Instance.UpdateUI();
    }
}
