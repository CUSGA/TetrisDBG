using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_AttackChip : Buff
{
    public override void TriggerAction()
    {
    }

    public override string GetInfo()
    {
        return "当该状态叠到 <color=red>" + 3 + "</color> 层以上时才会触发\n" +
            "每次触发增加 <color=red>" + 1 + "</color> 层 <color=red>“攻击”</color> 状态\n";
    }
}
