using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    [Tooltip("所有的Stage预制体")]
    public GameObject[] AllStage;

    //该Manager还记录一些数据，包括当前关卡名，关卡层数等等信息。

}
