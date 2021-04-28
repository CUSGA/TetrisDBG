using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_TroubleMakerKing : Enemy
{
    [Header("����������Enemy���ܵĲ�������Enemy�ĳ�ʼAct�����ԡ�I�����ʼ����˼")]
    [Tooltip("�������Ĳ���")]
    public int actTroubleMakerKingNum_I;
    [Tooltip("������ֵ�Ĳ���")]
    public int actTroubleIncreaseNum_I;

    private new void Start()
    {
        base.Start();

        EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum = actTroubleMakerKingNum_I;
        EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum = actTroubleIncreaseNum_I;

        UIManager.Instance.UpdateUI();
    }
}
