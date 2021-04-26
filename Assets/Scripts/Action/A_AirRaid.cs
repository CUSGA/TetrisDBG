using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_AirRaid : Act
{
    [Header("����Ԥ����")]
    [Tooltip("��Act����ʱ������ҿ������Ⱦ�ը��Cube")]
    public GameObject pollutant_Bomb;

    public override void TriggerAction()
    {
        PlayerManager.Instance.tempDeck.Add(pollutant_Bomb);
    }

    public override string GetInfo()
    {
        return "ÿ�� <color=red>" + triggerTime + "</color> �봥��һ�Σ�ÿ������ҿ����м��� <color=red>" + EnemyManager.Instance.currentEnemy.actAirRaidNum + "</color> ����ը�������顣\n" +
            "ը�����鱻����ʱ����������3���˺�";
    }
}
