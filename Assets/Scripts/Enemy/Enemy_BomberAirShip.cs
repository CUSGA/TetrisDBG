using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BomberAirShip : Enemy
{
    [Header("����������Enemy���ܵĲ�������Enemy_Basic�ĳ�ʼAct�����ԡ�I�����ʼ����˼")]
    [Tooltip("��Ϯը���Ĳ���")]
    public int actAirRaidNum_I;
    [Tooltip("��Ϯը���Ĵ���ʱ��")]
    public int actAirRaidTime_I;

    private new void Start()
    {
        base.Start();

        EnemyManager.Instance.currentEnemy.actAirRaidNum = actAirRaidNum_I;
        EnemyManager.Instance.currentEnemy.actAirRaidTime = actAirRaidTime_I;

        UIManager.Instance.UpdateUI();
    }
}
