using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage : MonoBehaviour
{
    [Tooltip("这个关卡的敌人")]
    public GameObject enemy_LV1;
    public GameObject enemy_LV2;
    public GameObject enemy_LV3;

    //public int level = 1;

    /// <summary>
    /// 该关卡可能的一些特殊的效果，用于在加载场景时调用，修改场景里的一些数据。
    /// </summary>
    public virtual void StageAbility()
    {
        Debug.Log("该场景没有特殊效果");
    }
}
