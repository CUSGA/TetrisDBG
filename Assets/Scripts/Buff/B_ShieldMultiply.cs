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
        return "每有一层该状态，\n在每次获得 <color=red>“护盾”</color>状态时获得的层数增加 <color=red>10%</color>";
    }
}
