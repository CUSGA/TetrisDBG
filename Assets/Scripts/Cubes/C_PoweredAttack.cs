using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PoweredAttack : Cube
{
    public override void ClearAction()
    {
        BattleManager.Instance.effectAttack += 3;
    }
}
