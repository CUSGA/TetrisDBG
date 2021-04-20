using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cube : MonoBehaviour
{
    public SO_CubeData cubeData;

    public SpriteRenderer background;
    public SpriteRenderer icon;

    private void Awake()
    {
        //从自己父物体那找到图片组件，记录为背景图片。
        background = transform.parent.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetData();
    }

    /// <summary>
    /// 将方块的数据显示出来，包括图片、文字啥的
    /// </summary>
    private void SetData()
    {
        //设置背景颜色，icon图片
        background.color = cubeData.bgColor;
        icon.sprite = cubeData.cubeIcon;
    }

    /// <summary>
    /// 该方块被消除时触发的效果。
    /// </summary>
    public abstract void ClearAction();
}
