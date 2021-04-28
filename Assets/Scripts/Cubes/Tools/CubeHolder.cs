using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [HideInInspector]
    public Cube cube;
    
    /// <summary>
    /// 根据传入的预制体，将其生成出来并和该CubeHolder绑定。
    /// </summary>
    /// <param name="c"></param>
    public void SetCube(GameObject c)
    {
        cube = Instantiate(c, transform).GetComponent<Cube>();
    }

    /// <summary>
    /// 将该Holder身上的Cube换成其他Cube
    /// </summary>
    /// <param name="c">你要换的Cube</param>
    public void ChangeCube(GameObject c)
    {
        Destroy(transform.GetChild(0).gameObject);
        cube = Instantiate(c, transform).GetComponent<Cube>();
    }
}
