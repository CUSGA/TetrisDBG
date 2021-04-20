using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����洢����Ļ�������
[CreateAssetMenu(fileName = "New Cube", menuName = "Cube/Cube Data")]
public class SO_CubeData : ScriptableObject
{
    public string cubeName;
    public Sprite cubeIcon;
    public Color bgColor;

    /// <summary>
    /// �������������
    /// </summary>
    [TextArea]
    public string description = "";
}
