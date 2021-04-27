using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//��ΪSceneManager��unity�Դ����࣬����ֻ�ܸ���
public class SceneController : Singleton<SceneController>
{
    //�����ã�����
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
    /// ���ؽ���һ������ؿ���
    /// </summary>
    public void TransitionToRandomStage()
    {
        //��StageManager����������йؿ��������һ�����루Ŀǰֻ��һ���ؿ�����ֻ�ܽ�����һ�أ�
        int n = Mathf.FloorToInt(Random.Range(0f, StageManager.Instance.AllStage.Length));
        TransitionToBattleScene(StageManager.Instance.AllStage[n]);
    }

    /// <summary>
    /// ����ս�����������Ҫָ���Խ���ĳ���ؿ���ֱ�ӵ��������
    /// </summary>
    /// <param name="stage">�������ս����Ԥ����</param>
    public void TransitionToBattleScene(GameObject stage)
    {
        Debug.Log("��ʼ���س���");
        StartCoroutine(IETransitionToBattleScene(stage.GetComponent<Stage>().enemy));
        stage.GetComponent<Stage>().StageAbility();
        PlayerManager.Instance.ResetTempDeck();
    }

    IEnumerator IETransitionToBattleScene(GameObject stage)
    {
        //TODO: �ǵ�����л�����ʱ����
        yield return SceneManager.LoadSceneAsync("Scene1");
        EnemyManager.Instance.SetEnemy(stage);
        yield return null;
    }

    //���������������̵곡���ķ���
    public void TransitionToShopScene()
    {
        StartCoroutine(IETransitionToShopScene());
    }

    IEnumerator IETransitionToShopScene()
    {
        yield return SceneManager.LoadSceneAsync("ShopScene");
        yield return null;
    }

    //�����������л��ص�ͼ�����ķ���
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
