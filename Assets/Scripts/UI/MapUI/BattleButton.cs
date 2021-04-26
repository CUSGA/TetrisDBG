using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    public void TransToRandomBattle()
    {
        SceneController.Instance.TransitionToRandomStage();
    }

    public void TransToTestBattle()
    {
        SceneController.Instance.TransitionToBattleScene(StageManager.Instance.AllStage[0]);
    }

    public void TransToBomberAirShipBattle()
    {
        SceneController.Instance.TransitionToBattleScene(StageManager.Instance.AllStage[1]);
    }
}
