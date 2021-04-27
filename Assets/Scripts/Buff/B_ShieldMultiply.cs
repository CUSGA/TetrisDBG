using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ShieldMultiply : Buff
{
    public override void TriggerAction()
    {
    }

    public override string GetInfo()
    {
        return "每有一层防御强化，在每次获得护盾时获得的护盾量增加 <color=red>10%</color>";
    }
}
