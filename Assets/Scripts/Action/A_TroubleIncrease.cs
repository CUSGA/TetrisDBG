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
        return "每当有一行方块被消除时，获得 <color=red>" + EnemyManager.Instance.currentEnemy.actTroubleIncreaseNum + "</color> 层捣乱王";
    }
}
