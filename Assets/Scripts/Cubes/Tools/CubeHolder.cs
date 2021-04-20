using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [HideInInspector]
    public Cube cube;
    
    /// <summary>
    /// ���ݴ����Ԥ���壬�������ɳ������͸�CubeHolder�󶨡�
    /// </summary>
    /// <param name="c"></param>
    public void SetCube(GameObject c)
    {
        cube = Instantiate(c, transform).GetComponent<Cube>();
    }
}
