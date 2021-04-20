using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//负责游戏逻辑部分，包括生成新方块组合，检查行满并消除等。
public class GameManager : Singleton<GameManager>
{
    [Tooltip("掉落间隔")]
    public float fallTime;
    [HideInInspector]
    public float previousTime;//掉落计时器

    public GameObject[] Tetrominoes;
    public Transform spawner;

    //场景的高度和宽度
    public static int width = 10;
    public static int height = 20;

    //用来存储所有方块位置的二维数组。
    public Transform[,] grid = new Transform[width, height];

    #region 消除行时的总的触发效果计数器：TotalEffectCounter

    public int effectAttack = 0;
    public int effectShield = 0;

    #endregion

    int cleanCombo = 0;//当前清除行的连锁数。
    int oldCombo = 0;

    float waitTime = 0.5f;//每次删除行之类的停顿时间

    void Start()
    {
        CreateNewTetromino();
    }

    /// <summary>
    /// 在Spawner处随机生成一个方块组合
    /// </summary>
    public void CreateNewTetromino()
    {
        GameObject tet = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], spawner.position, Quaternion.identity);
        int n = Mathf.RoundToInt(Random.Range(0f, PlayerManager.Instance.Deck.Length - 1));//随机在卡组中抽取一个Cube并生成

        //在生成的方块组合下的每个Holder下都生成一个Cube。
        foreach (Transform children in tet.transform)
        {
            if (children.name != "RotatePoint")
            {
                children.GetComponent<CubeHolder>().SetCube(PlayerManager.Instance.Deck[n]);
            }
        }
    }

    /// <summary>
    /// 查询方块数组，看哪些行已经填满了并消除它们。
    /// </summary>
    public void CheckForLines()
    {
        StartCoroutine(ieCheckForLines());
    }

    IEnumerator ieCheckForLines()
    {

        //记录当前的连击数
        oldCombo = cleanCombo;
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                cleanCombo += 1;//连击数+1
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
    /// 检查i行是否已满
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
    /// 触发该行每个方块的效果，显示文字告知该行效果，结算效果，清空效果计数器
    /// </summary>
    private void TriggerLine(int i)
    {
        //触发该行每个方块的效果
        for (int j = 0; j < width; j++)
        {
            grid[j, i].GetComponent<CubeHolder>().cube.ClearAction();
        }

        //TODO: 显示文字告知该行效果
        Debug.Log("攻击：" + effectAttack + "，护盾：" + effectShield);

        HandleEffect();

        //让UIManager更新显示
        UIManager.Instance.UpdateUI();

        //清空效果计数器
        CleanEffectCounter();
    }

    /// <summary>
    /// 结算当前的效果
    /// </summary>
    private void HandleEffect()
    {
        //根据攻击对敌人造成伤害
        EnemyManager.Instance.currentEnemy.BeAttack(effectAttack);

        //增加护盾（加护盾Buff）
        PlayerManager.Instance.buffShield += effectShield;
    }

    /// <summary>
    /// 清空效果计数器
    /// </summary>
    private void CleanEffectCounter()
    {
        effectAttack = 0;
        effectShield = 0;
    }

    /// <summary>
    /// 删除第i行
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
    /// 把第i行上面的全部行都往下移一行
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
    /// 遍历场景中所有方块组合，清除其中的空组合。
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
    /// 检查当前场景中所有方块组合，每个都往下移到最低点。
    /// </summary>
    public void AllDown()
    {
        //从底向上，依次遍历所有的方块组合。
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, i] != null)
                {
                    Tetromino t = grid[j, i].gameObject.GetComponentInParent<Tetromino>();
                    //DEBUG: Debug.Log("正在检查：" + "[" + j + ", " + i + "]的父类：" + t.name);
                
                    //若该方块组合还未在本轮检查中向下移动过，执行移动
                    if(!t.downCheck)
                    {
                        //DEBUG: Debug.Log("开始检查");
                        while (true)
                        {
                            //若移动非法，也就是无法再移动，就退出。若移动合法，就继续移动。
                            if (!t.MoveDown())
                            {
                                //DEBUG: Debug.Log("移动非法，不再移动");
                                //添加方块记录入表格，并设置标记
                                t.CleanOldGrid();
                                t.AddToGrid();
                                t.downCheck = true;//将本方块组合标记为已被检查过
                                break;
                            }
                            //DEBUG: Debug.Log("移动合法，继续移动。");
                        }
                    }
                }else
                {
                    //DEBUG: Debug.Log("正在检查：" + "[" + j + ", " + i + "]的父类，为空");
                }
            }
        }

        //将所有方块组合的检查标记重置为否。
        Tetromino[] listTet =  FindObjectsOfType<Tetromino>();
        foreach (Tetromino tet in listTet)
        {
            tet.downCheck = false;
        }
    }
}
