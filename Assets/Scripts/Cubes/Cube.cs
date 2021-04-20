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
        //���Լ����������ҵ�ͼƬ�������¼Ϊ����ͼƬ��
        background = transform.parent.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetData();
    }

    /// <summary>
    /// �������������ʾ����������ͼƬ������ɶ��
    /// </summary>
    private void SetData()
    {
        //���ñ�����ɫ��iconͼƬ
        background.color = cubeData.bgColor;
        icon.sprite = cubeData.cubeIcon;
    }

    /// <summary>
    /// �÷��鱻����ʱ������Ч����
    /// </summary>
    public abstract void ClearAction();
}
