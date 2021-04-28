using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PoisonBottle : Cube
{
    public override void ClearAction()
    {
        EnemyManager.Instance.currentEnemy.buffPoisonNum += 2;
    }
}
