using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//因为SceneManager是unity自带的类，所以只能改名
public class SceneController : Singleton<SceneController>
{
    //测试用！！！
    public GameObject enemyPrefab;

    public void GoToBattle()
    {
        TransitionToBattleScene(enemyPrefab);
    }

    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 加载进入一个随机关卡。
    /// </summary>
    public void TransitionToRandomStage()
    {
        //从StageManager所储存的所有关卡中随机抽一个进入（目前只有一个关卡所以只能进入这一关）
        int n = Mathf.FloorToInt(Random.Range(0f, StageManager.Instance.AllStage.Length));
        TransitionToBattleScene(StageManager.Instance.AllStage[n]);
    }

    /// <summary>
    /// 进入战斗场景，如果要指向性进入某个关卡就直接调用这个。
    /// </summary>
    /// <param name="stage">所进入的战斗的预制体</param>
    public void TransitionToBattleScene(GameObject stage)
    {
        Debug.Log("开始加载场景");
        StartCoroutine(IETransitionToBattleScene(stage.GetComponent<Stage>().enemy));
        stage.GetComponent<Stage>().StageAbility();
        PlayerManager.Instance.ResetTempDeck();
    }

    IEnumerator IETransitionToBattleScene(GameObject stage)
    {
        //TODO: 记得这里，切换场景时改名
        yield return SceneManager.LoadSceneAsync("Scene1");
        EnemyManager.Instance.SetEnemy(stage);
        yield return null;
    }

    //从其他场景进入商店场景的方法
    public void TransitionToShopScene()
    {
        StartCoroutine(IETransitionToShopScene());
    }

    IEnumerator IETransitionToShopScene()
    {
        yield return SceneManager.LoadSceneAsync("ShopScene");
        yield return null;
    }

    //从其他场景切换回地图场景的方法
    public void TransitionToMapScene()
    {
        StartCoroutine(IETransitionToMapScene());
        PlayerManager.Instance.ResetTempDeck();
    }

    IEnumerator IETransitionToMapScene()
    {
        yield return SceneManager.LoadSceneAsync("MapScene_Test");
        PlayerManager.Instance.ResetState();
        yield return null;
    }
}
