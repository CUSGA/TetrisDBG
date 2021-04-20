using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//用来存放Buff的各种基本信息
public abstract class Buff : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("相关描述")]
    [Tooltip("因为name跟GameObject的name变量冲突了，所以只能叫title。其实就是名称的意思")]
    public string title;
    [TextArea]
    [Tooltip("描述")]
    public string info;

    [Header("其他组件的获取")]
    public Image img;
    public Text numText;
    public Image triggerCover;
    [Tooltip("该Buff多长时间触发，若为0代表不触发（被动效果）")]
    public float triggerTime;
    float lastTriggerTime;//定时时间计数器

    /// <summary>
    /// 记录该Buff的归属。0代表玩家，1代表敌人。
    /// </summary>
    public int belong;//该Buff的持有者，是敌人还是玩家

    private void Start()
    {
        lastTriggerTime = triggerTime;
    }

    private void Update()
    {
        Trigger();//判断定时性Buff并计时、触发效果、更改显示等
    }

    public void Trigger()
    {
        if (triggerTime > 0)//相当于判断该Buff是不是定时型Buff，若是
        {
            lastTriggerTime -= Time.deltaTime;

            if (lastTriggerTime <= 0)//该Buff的读条时间到了，触发定时方法，重置lastFadeTime
            {
                TriggerAction();
                lastTriggerTime = triggerTime;
            }
            triggerCover.fillAmount = 1 - lastTriggerTime / triggerTime;
        }
    }

    /// <summary>
    /// 在该Buff触发时的行动，需包括Buff层数显示的更改
    /// </summary>
    public abstract void TriggerAction();

    //当鼠标进入时，显示提示
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.tooltip.gameObject.SetActive(true);
        UIManager.Instance.tooltip.SetupTooltip(title, info);
    }

    //当鼠标离开时，关闭提示
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.tooltip.gameObject.SetActive(false);
    }
}
