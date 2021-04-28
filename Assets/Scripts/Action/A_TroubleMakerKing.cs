using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TroubleMakerKing : Act, ILineClearObserver
{
    protected new void Start()
    {
        base.Start();
        BattleManager.Instance.AddLineClearObserver(this);
    }

    private void OnDisable()
    {
        BattleManager.Instance.RemoveLineClearObserver(this);
    }

    public void LineClearNotify()
    {
        PlayerManager.Instance.BeAttack(EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum);
    }

    public override void TriggerAction()
    {
        throw new System.NotImplementedException();
    }

    public override string GetInfo()
    {
        return "ÿ����һ�з��鱻����ʱ����� <color=red>" + EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum + "</color> ���˺�";
    }
}
