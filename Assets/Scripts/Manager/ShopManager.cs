using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public GameObject[] AllShopCube;

    public GameObject GetRandomGood()
    {
        int n = Mathf.FloorToInt(Random.Range(0f, AllShopCube.Length));
        return AllShopCube[n];
    }
}
