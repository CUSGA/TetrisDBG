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
        return "����Buff���� <color=red>" + 4 + "</color> ������ʱ�Żᴥ��\n" +
            "ÿ�δ������� <color=red>" + 1 + "</color> �����ǿ��Buff\n" +
            "ÿ�����ǿ�������� <color=red>10%</color> �Ļ���Buff���ʡ�";
    }
}
