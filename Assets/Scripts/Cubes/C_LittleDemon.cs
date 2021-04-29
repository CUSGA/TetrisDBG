using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LittleDemon : Cube
{
    public override void ClearAction()
    {
    }

    protected new void Start()
    {
        base.Start();
        EnemyManager.Instance.currentEnemy.actAttackNum += 1;
        UIManager.Instance.UpdateUI();
    }

    private void OnDisable()
    {
        EnemyManager.Instance.currentEnemy.actAttackNum -= 1;
        UIManager.Instance.UpdateUI();
    }
}
