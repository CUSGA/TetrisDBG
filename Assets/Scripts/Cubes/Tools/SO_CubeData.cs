using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用来存储方块的基本数据
[CreateAssetMenu(fileName = "New Cube", menuName = "Cube/Cube Data")]
public class SO_CubeData : ScriptableObject
{
    public string cubeName;
    [Tooltip("Cube的英文名，用于检索和查找等，以免中文名出问题。")]
    public string cubeEnName;
    //TODO: 现在还根本没有AllCube数组啊啊啊
    [Tooltip("Cube的编号，应该要跟AllCube数组中的位置保持一致")]
    public int cubeCode;
    public Sprite cubeIcon;
    public Color bgColor;
    [Tooltip("该Cube可以出现的方块组合，0-6分别是IJLOSTZ（跟在GameManager中的Tet数组中顺序保持一致）。7是单个方块出现")]
    public int[] ableTet;

    /// <summary>
    /// 方块的描述文字
    /// </summary>
    [TextArea]
    public string description = "";
}
