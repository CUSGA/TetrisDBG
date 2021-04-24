using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����������Ĺ����������ӣ�˵���˾��ǲ����õ�
public class A_Attack : Act
{
    private void Start()
    {
        //TODO: �����ߡ����е�Act��Ҫ�޸����
        //�������ߵĹ��������ĳ�ֵ�����㣬���ø�ֵ����Ĭ��ֵ��
        if (EnemyManager.Instance.currentEnemy.actAttackTime > 0)
        {
            triggerTime = EnemyManager.Instance.currentEnemy.actAttackTime;
        }
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
            PlayerManager.Instance.BeAttack(EnemyManager.Instance.currentEnemy.actAttackNum);
        }
        //�����UpdateUI��BeAttack��ִ���ˣ�������������á�
    }

    public override string GetInfo()
    {
        return "ÿ�� <color=red>" + triggerTime + "</color> �봥��һ�Σ�ÿ�ζԶԷ���� <color=red>" + EnemyManager.Instance.currentEnemy.actAttackNum + "</color> ���˺���";
    }
}
