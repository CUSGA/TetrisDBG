using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [Tooltip("挂载Enemy的物体")]
    public Transform enemyPoint;

    [Header("测试用Enemy")]
    public GameObject enemyTest;//测试用的Enemy，以后正式版应该是从关卡数据中传入Enemy并生成。

    [HideInInspector]
    public Enemy currentEnemy;//当前的Enemy

    private void Start()
    {
        //TODO: 为了方便所以不通过Stage直接生成，实际游戏中应该删去这个。
        //SetEnemy(enemyTest);
    }

    /// <summary>
    /// 在指定地点实例化生成Enemy，并绑定相关数据
    /// </summary>
    public void SetEnemy(GameObject enemy)
    {
        if (enemyPoint.childCount > 0)
        {
            Debug.LogWarning("尝试新生成enemy时当前场景中已有enemy，进行覆盖");
            Debug.LogWarning("新生成的Enemy: " + enemy.name);
            foreach (Transform item in enemyPoint)
            {
                Destroy(item.gameObject);
            }
        }
        currentEnemy = Instantiate(enemy, enemyPoint).GetComponent<Enemy>();
    }
}
