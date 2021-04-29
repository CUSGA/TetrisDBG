using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DemonLeader : Enemy
{
    [Header("����������Enemy���ܵĲ�������Enemy�ĳ�ʼAct�����ԡ�I�����ʼ����˼")]
    [Tooltip("��ħ�����Ĳ���")]
    public int actCallOfDemonNum_I;
    [Tooltip("��ħ�����Ĵ���ʱ��")]
    public int actCallOfDemonTime_I;

    private new void Start()
    {
        base.Start();

        EnemyManager.Instance.currentEnemy.actCallOfDemonNum = actCallOfDemonNum_I;
        EnemyManager.Instance.currentEnemy.actCallOfDemonTime = actCallOfDemonTime_I;

        UIManager.Instance.UpdateUI();
    }
}
