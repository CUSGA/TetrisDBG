using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text nameText;
    public Text infoText;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupTooltip(string name, string info)
    {
        nameText.text = name;
        infoText.text = info;
    }

    private void OnEnable()
    {
        //每次tooltip启动时都切换一下坐标，不然每次生成会有闪烁。
        UpdatePosition();
    }

    private void Update()
    {
        UpdatePosition();
    }

    //追踪鼠标的位置
    public void UpdatePosition()
    {
        Vector3 mousePos = Input.mousePosition;//获取当前鼠标坐标

        //获取Tooltip的四个顶点坐标
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        //获取tooltip的宽和高
        float width = corners[3].x - corners[0].x;
        float height = corners[1].y - corners[0].y;

        //若鼠标位置过低，tooltip就要生成在鼠标上方以免超出屏幕。其他几个if都是一个意思
        if (mousePos.y < height)
        {
            rectTransform.position = mousePos + Vector3.up * height * 0.6f;
        }else
        {
            rectTransform.position = mousePos + Vector3.down * height * 0.6f;
        }

        if (!(mousePos.x > width / 2 && (Screen.width - mousePos.x) > width / 2))
        {
            if (Screen.width - mousePos.x > width)
            {
                rectTransform.position = mousePos + Vector3.right * width * 0.6f;
            }
            else
            {
                rectTransform.position = mousePos + Vector3.left * width * 0.6f;
            }
        }
    }
}

