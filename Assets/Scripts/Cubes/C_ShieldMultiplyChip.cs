using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ShieldMultiplyChip : Cube
{
    public override void ClearAction()
    {
        PlayerManager.Instance.buffShieldMultiplyChip += 1;

        if (PlayerManager.Instance.buffShieldMultiplyChip >= 4)
        {
            PlayerManager.Instance.buffShieldMultiplyChip = 0;
            PlayerManager.Instance.buffShieldMultiply += 1;
        }
    }
}
