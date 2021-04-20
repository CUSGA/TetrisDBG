using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Shield : Cube
{
    public override void ClearAction()
    {
        GameManager.Instance.effectShield += 1;
    }
}
