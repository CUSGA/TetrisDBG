using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ShieldMultiplyChip : Buff
{
    public override void TriggerAction()
    {
    }

    public override string GetInfo()
    {
        //BREAKPOINT: 
        return "当该Buff叠到 <color=red>" + 4 + "</color> 层以上时才会触发\n" +
            "每次触发叠加 <color=red>" + 1 + "</color> 层防御强化Buff\n" +
            "每层防御强化会增加 <color=red>10%</color> 的护盾Buff倍率。";
    }
}
