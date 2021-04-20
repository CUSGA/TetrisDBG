using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������Ĺ����������ӣ�˵���˾��ǲ����õ�
public class A_Attack : Act
{
    //��ΪAttack��������Ƚ����⣬�������������������������޸�Start
    private void Start()
    {
        triggerTime = EnemyManager.Instance.currentEnemy.actAttackTime;
        lastTriggerTime = triggerTime;
    }

    public override void TriggerAction()
    {
        if (belong == 0)
        {
            EnemyManager.Instance.currentEnemy.BeAttack(PlayerManager.Instance.actAttack);
        }
        else if (belong == 1)
        {
            PlayerManager.Instance.BeAttack(EnemyManager.Instance.currentEnemy.actAttack);
        }
        //�����UpdateUI��BeAttack��ִ���ˣ�������������á�
    }
}
