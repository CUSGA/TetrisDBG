using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetFloat("Speed", speed);
    }

}
