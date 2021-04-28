using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������Ĺ����������ӣ�˵���˾��ǲ����õ�
public class A_Attack : Act
{
    protected new void Start()
    {
        //�����ߡ����е�Act��Ҫ�޸����
        //�������ߵĹ��������ĳ�ֵ�����㣬���ø�ֵ����Ĭ��ֵ��
        if (belong == 0)
        {
            if (PlayerManager.Instance.actAttackTime > 0)
            {
                triggerTime = PlayerManager.Instance.actAttackTime;
            }
        }
        if (belong == 1)
        {
            if (EnemyManager.Instance.currentEnemy.actAttackTime > 0)
            {
                triggerTime = EnemyManager.Instance.currentEnemy.actAttackTime;
            }
        }
        base.Start();
    }

    public override void TriggerAction()
    {
        if (belong == 0)
        {
            EnemyManager.Instance.currentEnemy.BeAttack(PlayerManager.Instance.actAttackNum);
        }
        else if (belong == 1)
        {
            PlayerManager.Instance.BeAttack(EnemyManager.Instance.currentEnemy.actAttackNum);
        }
        //�����UpdateUI��BeAttack��ִ���ˣ�������������á�
    }

    public override string GetInfo()
    {
        if (belong == 0)
        {
            return "ÿ�� <color=red>" + triggerTime + "</color> �봥��һ�Σ�ÿ�ζԶԷ���� <color=red>" + PlayerManager.Instance.actAttackNum + "</color> ���˺���";
        }
        else
        {
            return "ÿ�� <color=red>" + triggerTime + "</color> �봥��һ�Σ�ÿ�ζԶԷ���� <color=red>" + EnemyManager.Instance.currentEnemy.actAttackNum + "</color> ���˺���";
        }
    }
}
