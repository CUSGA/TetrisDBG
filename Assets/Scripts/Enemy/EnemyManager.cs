using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [Tooltip("����Enemy������")]
    public Transform enemyPoint;

    [Header("������Enemy")]
    public GameObject enemyTest;//�����õ�Enemy���Ժ���ʽ��Ӧ���Ǵӹؿ������д���Enemy�����ɡ�

    [HideInInspector]
    public Enemy currentEnemy;//��ǰ��Enemy

    private void Start()
    {
        //TODO: Ϊ�˷������Բ�ͨ��Stageֱ�����ɣ�ʵ����Ϸ��Ӧ��ɾȥ�����
        SetEnemy(enemyTest);
    }

    /// <summary>
    /// ��ָ���ص�ʵ��������Enemy�������������
    /// </summary>
    public void SetEnemy(GameObject enemy)
    {
        if (enemyPoint.childCount > 0)
        {
            Debug.LogWarning("����������enemyʱ��ǰ����������enemy�����и���");
            foreach (Transform item in enemyPoint)
            {
                Destroy(item.gameObject);
            }
        }
        currentEnemy = Instantiate(enemy, enemyPoint).GetComponent<Enemy>();
    }
}
