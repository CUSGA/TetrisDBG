using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [Tooltip("����Enemy������")]
    public Transform enemyPoint;

    [Header("������Enemy")]
    public GameObject enemyTest;//TODO: �����õ�Enemy���Ժ���ʽ��Ӧ���Ǵӹؿ������д���Enemy�����ɡ�

    [HideInInspector]
    public Enemy currentEnemy;//��ǰ��Enemy

    private void Start()
    {
        //TODO: Ҳ�ǲ����ã��Ժ�Ҫ�ĳ��ɹؿ���ؽű����õġ�
        SetEnemy(enemyTest);
    }

    /// <summary>
    /// ��ָ���ص�ʵ��������Enemy�������������
    /// </summary>
    public void SetEnemy(GameObject enemy)
    {
        currentEnemy = Instantiate(enemy, enemyPoint).GetComponent<Enemy>();
    }
}
