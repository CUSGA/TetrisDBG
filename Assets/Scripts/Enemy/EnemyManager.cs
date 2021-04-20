using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [Tooltip("挂载Enemy的物体")]
    public Transform enemyPoint;

    [Header("测试用Enemy")]
    public GameObject enemyTest;//TODO: 测试用的Enemy，以后正式版应该是从关卡数据中传入Enemy并生成。

    [HideInInspector]
    public Enemy currentEnemy;//当前的Enemy

    private void Start()
    {
        //TODO: 也是测试用，以后要改成由关卡相关脚本调用的。
        SetEnemy(enemyTest);
    }

    /// <summary>
    /// 在指定地点实例化生成Enemy，并绑定相关数据
    /// </summary>
    public void SetEnemy(GameObject enemy)
    {
        currentEnemy = Instantiate(enemy, enemyPoint).GetComponent<Enemy>();
    }
}
