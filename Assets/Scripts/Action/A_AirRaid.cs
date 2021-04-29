using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_AirRaid : Act
{
    [Header("所需预制体")]
    [Tooltip("该Act触发时放入玩家卡组的污染物：炸弹Cube")]
    public GameObject pollutant_Bomb;

    public override void TriggerAction()
    {
        PlayerManager.Instance.tempDeck.Add(pollutant_Bomb);
    }

    public override string GetInfo()
    {
        return "每隔 <color=red>" + triggerTime + "</color> 秒触发一次，\n每次在玩家卡组中加入该状态层数" +
            " <color=red>（" + EnemyManager.Instance.currentEnemy.actAirRaidNum + "）</color> 个 <color=red>“炸弹”</color> 方块。\n" +
            " <color=red>“炸弹”</color> 方块被消除时，对玩家造成3点伤害";
    }
}
