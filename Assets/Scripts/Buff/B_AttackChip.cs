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
        return "����Buff���� <color=red>" + 3 + "</color> ������ʱ�Żᴥ��\n" +
            "ÿ�δ������� <color=red>" + 1 + "</color> �㹥��Action\n";
    }
}
