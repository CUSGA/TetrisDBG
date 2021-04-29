using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//�������Buff�ĸ��ֻ�����Ϣ
public abstract class Buff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("�������")]
    [Tooltip("��Ϊname��GameObject��name������ͻ�ˣ�����ֻ�ܽ�title����ʵ�������Ƶ���˼")]
    public string title;
    [TextArea]
    [Tooltip("����")]
    public string info;

    [Header("��������Ļ�ȡ")]
    public Image img;
    public Text numText;
    public Image triggerCover;
    [Tooltip("��Buff�೤ʱ�䴥������Ϊ0��������������Ч����")]
    public float triggerTime;
    float lastTriggerTime;//��ʱʱ�������

    /// <summary>
    /// ��¼��Buff�Ĺ�����0������ң�1������ˡ�
    /// </summary>
    public int belong;//��Buff�ĳ����ߣ��ǵ��˻������

    private void Start()
    {
        lastTriggerTime = triggerTime;
    }

    private void Update()
    {
        if (!BattleManager.Instance.isGamePause)
            Trigger();//�ж϶�ʱ��Buff����ʱ������Ч����������ʾ��
    }

    public void Trigger()
    {
        if (triggerTime > 0)//�൱���жϸ�Buff�ǲ��Ƕ�ʱ��Buff������
        {
            lastTriggerTime -= Time.deltaTime;

            if (lastTriggerTime <= 0)//��Buff�Ķ���ʱ�䵽�ˣ�������ʱ����������lastFadeTime
            {
                TriggerAction();
                lastTriggerTime = triggerTime;
            }
            triggerCover.fillAmount = 1 - lastTriggerTime / triggerTime;
        }
    }

    /// <summary>
    /// �ڸ�Buff����ʱ���ж��������Buff������ʾ�ĸ���
    /// </summary>
    public abstract void TriggerAction();

    //��������ʱ����ʾ��ʾ
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.tooltip.gameObject.SetActive(true);
        UIManager.Instance.tooltip.SetupTooltip(title, GetInfo());
    }

    public virtual string GetInfo()
    {
        return info;
    }

    //������뿪ʱ���ر���ʾ
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.tooltip.gameObject.SetActive(false);
    }
}
