using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Attack : Cube
{
    public override void ClearAction()
    {
        GameManager.Instance.effectAttack += 1;
    }
}
