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
        return "����״̬���� <color=red>" + 4 + "</color> ������ʱ�Żᴥ��\n" +
            "ÿ�δ������� <color=red>" + 1 + "</color> �� <color=red>������ǿ����</color> ״̬\n" +
            "ÿ�� <color=red>������ǿ����</color> ������ <color=red>10%</color> �Ļ���״̬���ʱ�ı��ʡ�";
    }
}
