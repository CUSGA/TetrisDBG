using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����洢����Ļ�������
[CreateAssetMenu(fileName = "New Cube", menuName = "Cube/Cube Data")]
public class SO_CubeData : ScriptableObject
{
    public string cubeName;
    [Tooltip("Cube��Ӣ���������ڼ����Ͳ��ҵȣ����������������⡣")]
    public string cubeEnName;
    //TODO: ���ڻ�����û��AllCube���鰡����
    [Tooltip("Cube�ı�ţ�Ӧ��Ҫ��AllCube�����е�λ�ñ���һ��")]
    public int cubeCode;
    public Sprite cubeIcon;
    public Color bgColor;
    [Tooltip("��Cube���Գ��ֵķ�����ϣ�0-6�ֱ���IJLOSTZ������GameManager�е�Tet������˳�򱣳�һ�£���7�ǵ����������")]
    public int[] ableTet;

    /// <summary>
    /// �������������
    /// </summary>
    [TextArea]
    public string description = "";
}
