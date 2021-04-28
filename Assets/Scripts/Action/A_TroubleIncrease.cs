using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TroubleIncrease : Act, ILineClearObserver
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
        EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum += EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum;
    }

    public override void TriggerAction()
    {
    }

    public override string GetInfo()
    {
        return "ÿ����һ�з��鱻����ʱ����� <color=red>" + EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum + "</color> �㵷����";
    }
}
