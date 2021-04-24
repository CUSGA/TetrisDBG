using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ϸ�߼����֣����������·�����ϣ���������������ȡ�
public class GameManager : Singleton<GameManager>
{
    [Tooltip("������")]
    public float fallTime;
    [HideInInspector]
    public float previousTime;//�����ʱ��

    public GameObject[] Tetrominoes;
    public Transform spawner;

    //�����ĸ߶ȺͿ��
    public static int width = 10;
    public static int height = 20;

    //�����洢���з���λ�õĶ�ά���顣
    public Transform[,] grid = new Transform[width, height];

    #region ������ʱ���ܵĴ���Ч����������TotalEffectCounter

    public int effectAttack = 0;
    public int effectShield = 0;

    #endregion

    int cleanCombo = 0;//��ǰ����е���������
    int oldCombo = 0;

    float waitTime = 0.5f;//ÿ��ɾ����֮���ͣ��ʱ��

    void Start()
    {
        CreateNewTetromino();
    }

    /// <summary>
    /// ��Spawner���������һ���������
    /// </summary>
    public void CreateNewTetromino()
    {
        //����ڿ����г�ȡһ��Cube
        int n = Mathf.FloorToInt(Random.Range(0f, PlayerManager.Instance.Deck.Length));
        GameObject nCube = PlayerManager.Instance.Deck[n];
        //�ڸ�Cube�Ŀ����ɷ�������������һ��
        int m = Mathf.FloorToInt(Random.Range(0f, nCube.GetComponent<Cube>().cubeData.ableTet.Length));
        m = nCube.GetComponent<Cube>().cubeData.ableTet[m];//�鵽�ķ�����ϵı��

        GameObject tet = Instantiate(Tetrominoes[m], spawner.position, Quaternion.identity);

        //�����ɵķ�������µ�ÿ��Holder�¶�����һ��Cube��
        foreach (Transform children in tet.transform)
        {
            if (children.name != "RotatePoint")
            {
                children.GetComponent<CubeHolder>().SetCube(nCube);
            }
        }
    }

    /// <summary>
    /// ��ѯ�������飬����Щ���Ѿ������˲��������ǡ�
    /// </summary>
    public void CheckForLines()
    {
        StartCoroutine(ieCheckForLines());
    }

    IEnumerator ieCheckForLines()
    {

        //��¼��ǰ��������
        oldCombo = cleanCombo;
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                cleanCombo += 1;//������+1
                TriggerLine(i);
                DeleteLine(i);
                yield return new WaitForSeconds(waitTime);
                RowDown(i);
                AllDown();
                yield return new WaitForSeconds(waitTime);
                CleanEmptyTetromino();
            }
        }

        CreateNewTetromino();
    }

    /// <summary>
    /// ���i���Ƿ�����
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        return true;
    }

    /// <summary>
    /// ��������ÿ�������Ч������ʾ���ָ�֪����Ч��������Ч�������Ч��������
    /// </summary>
    private void TriggerLine(int i)
    {
        //��������ÿ�������Ч��
        for (int j = 0; j < width; j++)
        {
            grid[j, i].GetComponent<CubeHolder>().cube.ClearAction();
        }

        //TODO: ��ʾ���ָ�֪����Ч��
        Debug.Log("������" + effectAttack + "�����ܣ�" + effectShield);

        HandleEffect();

        //��UIManager������ʾ
        UIManager.Instance.UpdateUI();

        //���Ч��������
        CleanEffectCounter();
    }

    /// <summary>
    /// ���㵱ǰ��Ч��
    /// </summary>
    private void HandleEffect()
    {
        //���ݹ����Ե�������˺�
        EnemyManager.Instance.currentEnemy.BeAttack(effectAttack);

        //���ӻ��ܣ��ӻ���Buff��
        PlayerManager.Instance.buffShield += effectShield;
    }

    /// <summary>
    /// ���Ч��������
    /// </summary>
    private void CleanEffectCounter()
    {
        effectAttack = 0;
        effectShield = 0;
    }

    /// <summary>
    /// ɾ����i��
    /// </summary>
    /// <param name="i"></param>
    private void DeleteLine(int i)
    {
        
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    /// <summary>
    /// �ѵ�i�������ȫ���ж�������һ��
    /// </summary>
    /// <param name="i"></param>
    private void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    /// <summary>
    /// �������������з�����ϣ�������еĿ���ϡ�
    /// </summary>
    public void CleanEmptyTetromino()
    {
        Tetromino[] tetList = FindObjectsOfType<Tetromino>();
        foreach (Tetromino tet in tetList)
        {
            tet.CheckIsAllClear();
        }
    }

    /// <summary>
    /// ��鵱ǰ���������з�����ϣ�ÿ���������Ƶ���͵㡣
    /// </summary>
    public void AllDown()
    {
        //�ӵ����ϣ����α������еķ�����ϡ�
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, i] != null)
                {
                    Tetromino t = grid[j, i].gameObject.GetComponentInParent<Tetromino>();
                    //DEBUG: Debug.Log("���ڼ�飺" + "[" + j + ", " + i + "]�ĸ��ࣺ" + t.name);
                
                    //���÷�����ϻ�δ�ڱ��ּ���������ƶ�����ִ���ƶ�
                    if(!t.downCheck)
                    {
                        //DEBUG: Debug.Log("��ʼ���");
                        while (true)
                        {
                            //���ƶ��Ƿ���Ҳ�����޷����ƶ������˳������ƶ��Ϸ����ͼ����ƶ���
                            if (!t.MoveDown())
                            {
                                //DEBUG: Debug.Log("�ƶ��Ƿ��������ƶ�");
                                //��ӷ����¼���񣬲����ñ��
                                t.CleanOldGrid();
                                t.AddToGrid();
                                t.downCheck = true;//����������ϱ��Ϊ�ѱ�����
                                break;
                            }
                            //DEBUG: Debug.Log("�ƶ��Ϸ��������ƶ���");
                        }
                    }
                }else
                {
                    //DEBUG: Debug.Log("���ڼ�飺" + "[" + j + ", " + i + "]�ĸ��࣬Ϊ��");
                }
            }
        }

        //�����з�����ϵļ��������Ϊ��
        Tetromino[] listTet =  FindObjectsOfType<Tetromino>();
        foreach (Tetromino tet in listTet)
        {
            tet.downCheck = false;
        }
    }
}
