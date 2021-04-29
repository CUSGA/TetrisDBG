using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Dice : Cube
{
    public override void ClearAction()
    {
        int n = Random.Range(1, 5);

        switch(n)
        {
            case 1:BattleManager.Instance.effectAttack += 3;break;
            case 2: BattleManager.Instance.effectAttack += 4; break;
            case 3: BattleManager.Instance.effectAttack += 5; break;
            case 4: BattleManager.Instance.effectBeAttack += 5; break;
        }

    }
}
