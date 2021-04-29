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
        return "当该状态叠到 <color=red>" + 4 + "</color> 层以上时才会触发\n" +
            "每次触发叠加 <color=red>" + 1 + "</color> 层 <color=red>“防御强化”</color> 状态\n" +
            "每层 <color=red>“防御强化”</color> 会增加 <color=red>10%</color> 的护盾状态获得时的倍率。";
    }
}
