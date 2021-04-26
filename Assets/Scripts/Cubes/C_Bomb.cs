using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Bomb : Cube
{
    public override void ClearAction()
    {
        BattleManager.Instance.effectBeAttack += 3;
    }
}
