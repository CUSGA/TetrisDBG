using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    [Tooltip("����ؿ��ĵ���")]
    public GameObject enemy_LV1;
    public GameObject enemy_LV2;
    public GameObject enemy_LV3;

    //public int level = 1;

    /// <summary>
    /// �ùؿ����ܵ�һЩ�����Ч���������ڼ��س���ʱ���ã��޸ĳ������һЩ���ݡ�
    /// </summary>
    public virtual void StageAbility()
    {
        Debug.Log("�ó���û������Ч��");
    }
}
