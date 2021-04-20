using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用来存储方块的基本数据
[CreateAssetMenu(fileName = "New Cube", menuName = "Cube/Cube Data")]
public class SO_CubeData : ScriptableObject
{
    public string cubeName;
    public Sprite cubeIcon;
    public Color bgColor;

    /// <summary>
    /// 方块的描述文字
    /// </summary>
    [TextArea]
    public string description = "";
}
