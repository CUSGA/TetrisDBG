using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCube : MonoBehaviour//BREAKPOINT: �����ͣ/��ͣ�뿪
{
    public Text numText;
    public Image cubeImage;

    public void SetCube(GameObject cube)
    {
        cubeImage.sprite = cube.GetComponent<Cube>().cubeData.cubeIcon;
    }
}
