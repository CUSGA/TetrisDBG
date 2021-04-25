using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//测试用关卡1
public class Stage_Test_1 : Stage
{
    public override void StageAbility()
    {
        Debug.LogWarning("这一关的特效就是报个警告");
        //开玩笑的。一般来说可能一些不同的关卡，虽然敌人相同，但是可能这个关卡会自带一些特殊效果。
        //比如“缓慢”：方块下落速度降低等等。这些效果就写在这个函数里，在战斗场景加载好后调用，修改游戏数值
    }
}
