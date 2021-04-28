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

    /// <summary>
    /// ����Holder���ϵ�Cube��������Cube
    /// </summary>
    /// <param name="c">��Ҫ����Cube</param>
    public void ChangeCube(GameObject c)
    {
        Destroy(transform.GetChild(0).gameObject);
        cube = Instantiate(c, transform).GetComponent<Cube>();
    }
}
