using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//û�����Ǹ�Buffһģһ���Ľű�������Ϊ������Buff��Action���Ƿֳ�����д��������һ�Ժ�Ҫ�ֱ���Action��Buff�أ�
//������Action����ű�����CleanGUI��Դ���г�ͻ�����Ը�����Act
public abstract class Act : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
    [Tooltip("��Act�೤ʱ�䴥������Ϊ0��������ʱ�䴥��������Ч����һ����Ч������������Ч����")]
    public float triggerTime;
    protected float lastTriggerTime;//��ʱʱ�������

    [Tooltip("��¼��Buff�Ĺ�����0������ң�1������ˡ�")]
    public int belong;//��Buff�ĳ����ߣ��ǵ��˻������

    protected void Start()
    {
        lastTriggerTime = triggerTime;
    }

    private void Update()
    {
        if (!BattleManager.Instance.isGamePause)
            Trigger();//�ж϶�ʱ��Act����ʱ������Ч����������ʾ��
    }

    public void Trigger()
    {
        if (triggerTime > 0)//�൱���жϸ�Act�ǲ��Ƕ�ʱ��Act������
        {
            lastTriggerTime -= Time.deltaTime;

            if (lastTriggerTime <= 0)//��Act�Ķ���ʱ�䵽�ˣ�������ʱ����������lastFadeTime
            {
                TriggerAction();
                lastTriggerTime = triggerTime;
            }
            triggerCover.fillAmount = 1 - lastTriggerTime / triggerTime;
        }
    }

    /// <summary>
    /// �ڸ�Act����ʱ���ж��������BAct������ʾ�ĸ���
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
