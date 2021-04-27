using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_AttackChip : Cube
{
    public override void ClearAction()
    {
        PlayerManager.Instance.buffAttackChip += 1;

        if (PlayerManager.Instance.buffAttackChip >= 3)
        {
            PlayerManager.Instance.buffAttackChip = 0;
            PlayerManager.Instance.actAttackNum += 1;
        }
    }
}
