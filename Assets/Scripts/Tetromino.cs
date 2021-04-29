using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    [Tooltip("������ϵ���ת���ĵ�")]
    public Transform rotationPoint;

    [HideInInspector]
    public bool downCheck = false;//��������������б���Ƿ��Ѽ�����
    [HideInInspector]
    public bool moveAble = true;

    #region Read from GameManager
    public float fallTime
    {
        get
        {
            return BattleManager.Instance.fallTime;
        }
    }

    public float previousTime
    {
        get
        {
            return BattleManager.Instance.previousTime;
        }
        set
        {
            BattleManager.Instance.previousTime = value;
        }
    }

    #endregion


    void Update()
    {
        if (moveAble && !BattleManager.Instance.isGameOver)
        {
            //��ⰴ�����ƶ��������
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-1, 0, 0);
                //���ƶ��󷽿��ǲ��ڿ��ƶ���Χ�ڣ����ƻ��ƶ�ǰ��λ�á�
                if (!ValidMove())
                    transform.position -= new Vector3(-1, 0, 0);
            }else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(1, 0, 0);
            }else if (Input.GetKeyDown(KeyCode.UpArrow))//��ת
            {
                transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1) ,90f);
                if (!ValidMove())
                    transform.RotateAround(rotationPoint.position, new Vector3(0, 0, 1), -90f);

                //��ÿ����ת����Ҫ��ÿ��������ĽǶ���ת����
                foreach (Transform children in transform)
                {
                    children.rotation = Quaternion.Euler(Vector3.zero);
                }
            }

            //���ʱ�䲢���䣬����ס���¼��������ٶȷ�ʮ����
            if(Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())//������Ϊ������޷��ƶ���Ҳ����˵��������
                {
                    transform.position -= new Vector3(0, -1, 0);
                    //�����޷����䣬�Ͱѷ�����ϼ�¼�뷽�����飬��ֹͣһ���ƶ�������һ���·������
                    AddToGrid();
                    //����Ƿ������ѱ�����
                    BattleManager.Instance.CheckForLines();
                    moveAble = false;
                }
                //��������ʱ���ʱ��
                previousTime = Time.time;
            }
        }

    }

    /// <summary>
    /// ѭ��������������ÿ�������Ƿ��������ƶ��ķ�Χ��
    /// </summary>
    /// <returns></returns>
    public bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            if (children.name != "RotatePoint")//��ת�㲻���ڳ�����ķ�Χ�ڡ�
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                //����Ƿ����
                if (roundedX < 0 || roundedX >= BattleManager.width || roundedY < 0 || roundedY >= BattleManager.height)
                {
                    //Debug.Log("��Ϊ������޷��ƶ�");
                    return false;
                }

                //����Ƿ�������Ѿ��źõķ����ص���
                if (BattleManager.Instance.grid[roundedX, roundedY] != null)
                {
                    //Debug.Log("��Ϊ��������������޷��ƶ���" + BattleManager.Instance.grid[roundedX, roundedY] + "�丸���ǣ�" + BattleManager.Instance.grid[roundedX, roundedY].parent.name);
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// ���������������з�����뵽���������ڡ�
    /// </summary>
    public void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            if (children.name != "RotatePoint")
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                BattleManager.Instance.grid[roundedX, roundedY] = children;
            }
        }
    }

    /// <summary>
    /// ���÷�������Ƿ��Ѿ���ա���������������
    /// </summary>
    public void CheckIsAllClear()
    {
        if (transform.childCount <= 1)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ���������ƶ������ɹ�����ʵ�ƶ�����true���������ƶ�������false
    /// </summary>
    public bool MoveDown()
    {
        CleanOldGrid();
        transform.position += new Vector3(0, -1, 0);
        if (!ValidMove())//������Ϊ������޷��ƶ���Ҳ����˵�����������������
        {
            transform.position -= new Vector3(0, -1, 0);//��λ
            AddToGrid();
            return false;
        }else//���ǺϷ��ƶ�������true
        {
            AddToGrid();
            return true;
        }
    }

    /// <summary>
    /// �������ʵ��������ǰ���������ݡ�
    /// </summary>
    public void CleanOldGrid()
    {
        foreach (Transform children in transform)
        {
            if (children.name != "RotatePoint")
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                BattleManager.Instance.grid[roundedX, roundedY] = null;
            }
        }
    }

}
