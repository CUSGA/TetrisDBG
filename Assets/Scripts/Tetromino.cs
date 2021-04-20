using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [Tooltip("方块组合的旋转中心点")]
    public Transform rotationPoint;

    [HideInInspector]
    public bool downCheck = false;//这个是在下落检查中标记是否已检查过。
    [HideInInspector]
    public bool moveAble = true;

    #region Read from GameManager
    public float fallTime
    {
        get
        {
            return GameManager.Instance.fallTime;
        }
    }

    public float previousTime
    {
        get
        {
            return GameManager.Instance.previousTime;
        }
        set
        {
            GameManager.Instance.previousTime = value;
        }
    }

    #endregion


    void Update()
    {
        if (moveAble)
        {
            //检测按键并移动方块组合
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0);
                //若移动后方块们不在可移动范围内，就移回移动前的位置。
                if (!ValidMove())
                    transform.position -= new Vector3(-1, 0, 0);
            }else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(1, 0, 0);
            }else if (Input.GetKeyDown(KeyCode.UpArrow))//旋转
            {
                transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1) ,90f);
                if (!ValidMove())
                    transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1), -90f);

                //在每次旋转过后都要把每个子物体的角度旋转回来
                foreach (Transform children in transform)
                {
                    children.rotation = Quaternion.Euler(Vector3.zero);
                }
            }

            //检测时间并下落，若按住下下键则下落速度翻十倍。
            if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())//若是因为下落而无法移动，也就是说碰到地面
                {
                    transform.position -= new Vector3(0, -1, 0);
                    //若已无法下落，就把方块组合记录入方块数组，并停止一切移动并生成一个新方块组合
                    AddToGrid();
                    //检查是否有行已被填满
                    GameManager.Instance.CheckForLines();
                    moveAble = false;
                }
                //重置下落时间计时器
                previousTime = Time.time;
            }
        }

    }

    /// <summary>
    /// 循环遍历方块组中每个方块是否都在允许移动的范围内
    /// </summary>
    /// <returns></returns>
    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            if (children.name != "RotatePoint")//旋转点不算在出界检查的范围内。
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                //检查是否出界
                if (roundedX < 0 || roundedX >= GameManager.width || roundedY < 0 || roundedY >= GameManager.height)
                {
                    //DEBUG: Debug.Log("因为出界而无法移动");
                    return false;
                }

                //检查是否和其他已经放好的方块重叠。
                if (GameManager.Instance.grid[roundedX, roundedY] != null)
                {
                    //DEBUG: Debug.Log("因为碰到其他方块而无法移动：" + GameManager.Instance.grid[roundedX, roundedY] + "其父类是：" + GameManager.Instance.grid[roundedX, roundedY].parent.name);
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// 将本方块组内所有方块加入到方块数组内。
    /// </summary>
    public void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            if (children.name != "RotatePoint")
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                GameManager.Instance.grid[roundedX, roundedY] = children;
            }
        }
    }

    /// <summary>
    /// 检查该方块组合是否已经清空。若是则销毁自身。
    /// </summary>
    public void CheckIsAllClear()
    {
        if (transform.childCount <= 1)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 尝试向下移动，若成功则落实移动返回true，否则撤销移动并返回false
    /// </summary>
    public bool MoveDown()
    {
        CleanOldGrid();
        transform.position += new Vector3(0, -1, 0);
        if (!ValidMove())//若是因为下落而无法移动，也就是说碰到地面或其他方块
        {
            transform.position -= new Vector3(0, -1, 0);//归位
            AddToGrid();
            return false;
        }else//若是合法移动，返回true
        {
            AddToGrid();
            return true;
        }
    }

    /// <summary>
    /// 清空下落实锤后，下落前的数组数据。
    /// </summary>
    public void CleanOldGrid()
    {
        foreach (Transform children in transform)
        {
            if (children.name != "RotatePoint")
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                GameManager.Instance.grid[roundedX, roundedY] = null;
            }
        }
    }

}
