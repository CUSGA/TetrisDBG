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
}
