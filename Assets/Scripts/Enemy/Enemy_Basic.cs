using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basic : Enemy
{
    [Header("Enemy_Basic�ĳ�ʼAct������")]
    [Tooltip("�����Ĳ���")]
    public int actAtkNum;
    [Tooltip("�����ļ�������ǹ�����Ĭ�ϼ��")]
    public float actAtkTime;
    [Tooltip("ս����װ�Ĳ���")]
    public int actArmorUpNum;
    /*[Tooltip("���ӻ��ܼ��")]
    public float actArmorUpTime;
    float lastArmorUpTime;*/

    private new void Start()
    {
        base.Start();

        //lastArmorUpTime = actArmorUpTime;

        //������ͨ������������ = 5���������� = 5��
        EnemyManager.Instance.currentEnemy.actAttack = actAtkNum;
        EnemyManager.Instance.currentEnemy.actAttackTime = actAtkTime;

        //����ս����װ������ = 3
        EnemyManager.Instance.currentEnemy.actArmorUp = actArmorUpNum;

        UIManager.Instance.UpdateUI();
    }
}
