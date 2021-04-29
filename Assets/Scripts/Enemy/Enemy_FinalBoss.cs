using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FinalBoss : Enemy
{
    [Header("����������Enemy���ܵĲ�������Enemy�ĳ�ʼAct�����ԡ�I�����ʼ����˼")]
    [Tooltip("�����Ĳ���")]
    public int actAttackNum_I;
    [Tooltip("�����Ĵ��������������0����Ḳ�ǹ�����Ĭ�ϴ��������")]
    public float actAttackTime_I;
    [Tooltip("ս����װ�Ĳ���")]
    public int actArmorUpNum_I;
    [Tooltip("ս����װ�Ĵ��������������0����Ḳ��ս����װ��Ĭ�ϴ��������")]
    public float actArmorUpTime_I;
    [Tooltip("��ħ�����Ĳ���")]
    public int actCallOfDemonNum_I;
    [Tooltip("��ħ�����Ĵ���ʱ��")]
    public int actCallOfDemonTime_I;

    private new void Start()
    {
        base.Start();

        //lastArmorUpTime = actArmorUpTime;

        //������ͨ������
        EnemyManager.Instance.currentEnemy.actAttackNum = actAttackNum_I;
        //�������Enemy���ж�����ֵ��Ȼ����Act���Լ���ʵ���ڣ���ʼ��ʱ����������ߵĵ�ǰ������������ѡ��Ĭ�����ݻ����������ߵ����ݡ�
        EnemyManager.Instance.currentEnemy.actAttackTime = actAttackTime_I;

        //����ս����װ��
        EnemyManager.Instance.currentEnemy.actArmorUpNum = actArmorUpNum_I;
        EnemyManager.Instance.currentEnemy.actArmorUpTime = actArmorUpTime_I;

        EnemyManager.Instance.currentEnemy.actCallOfDemonNum = actCallOfDemonNum_I;
        EnemyManager.Instance.currentEnemy.actCallOfDemonTime = actCallOfDemonTime_I;



        UIManager.Instance.UpdateUI();
    }
}
