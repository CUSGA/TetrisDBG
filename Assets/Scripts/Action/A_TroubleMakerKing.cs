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
        if (!BattleManager.Instance.isGamePause)
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
        return "每当有一行方块被消除时，\n对对方造成该状态层数 <color=red>（" + EnemyManager.Instance.currentEnemy.actTroubleMakerKingNum + "）</color> 点伤害";
    }
}
