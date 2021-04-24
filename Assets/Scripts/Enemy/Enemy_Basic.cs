using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : Enemy
{
    //����洢���Ǹ�Enemy�ĳ�ʼ����
    [Header("����������Enemy���ܵĲ�������Enemy_Basic�ĳ�ʼAct�����ԡ�I�����ʼ����˼")]
    [Tooltip("�����Ĳ���")]
    public int actAttackNum_I;
    [Tooltip("�����Ĵ��������������0����Ḳ�ǹ�����Ĭ�ϴ��������")]
    public float actAttackTime_I;
    [Tooltip("ս����װ�Ĳ���")]
    public int actArmorUpNum_I;
    [Tooltip("ս����װ�Ĵ��������������0����Ḳ��ս����װ��Ĭ�ϴ��������")]
    public float actArmorUpTime_I;
    float lastArmorUpTime;

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

        UIManager.Instance.UpdateUI();
    }
}
