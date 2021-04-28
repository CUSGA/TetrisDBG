using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TroubleMakerKing : Enemy
{
    [Header("在这里设置Enemy技能的参数，即Enemy的初始Act的属性。I代表初始的意思")]
    [Tooltip("捣蛋王的层数")]
    public int actTroubleMakerKingNum_I;
    [Tooltip("捣蛋增值的层数")]
    public int actTroubleIncreaseNum_I;

    private new void Start()
    {
        base.Start();

        EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum = actTroubleMakerKingNum_I;
        EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum = actTroubleIncreaseNum_I;

        UIManager.Instance.UpdateUI();
    }
}
