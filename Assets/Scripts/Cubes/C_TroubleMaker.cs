using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TroubleMaker : Cube, ILineClearObserver
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

    public override void ClearAction()
    {
    }

    public void LineClearNotify()
    {
        BattleManager.Instance.effectAttack += 1;
    }
}
