using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_CallOfDemon : Act
{
    public GameObject littleDemonCube;

    public override void TriggerAction()
    {
        List<GameObject> allCubeOnDesk = new List<GameObject>();

        //把所有的方块放到一个数组中
        foreach (Transform cube in BattleManager.Instance.grid)
        {
            if (cube != null)
            {
                allCubeOnDesk.Add(cube.gameObject);
            }
        }

        if (EnemyManager.Instance.currentEnemy.actCallOfDemonNum >= allCubeOnDesk.Count)
        {
            Debug.Log("直接把全部改成小恶魔");
            foreach (var item in allCubeOnDesk)
            {
                item.GetComponent<CubeHolder>().ChangeCube(littleDemonCube);
            }
        }else
        {
            int nowL = allCubeOnDesk.Count;
            for (int i = 0; i < EnemyManager.Instance.currentEnemy.actCallOfDemonNum; i++)
            {
                int n = Random.Range(0, nowL);
                Debug.Log("变了一个" + allCubeOnDesk[n].GetComponent<CubeHolder>().cube.cubeData.cubeName);
                allCubeOnDesk[n].GetComponent<CubeHolder>().ChangeCube(littleDemonCube);

                //位置调换
                allCubeOnDesk[n] = allCubeOnDesk[nowL - 1];
                nowL--;
            }
        }
    }
}
