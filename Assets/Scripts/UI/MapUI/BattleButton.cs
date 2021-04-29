using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButton : MonoBehaviour
{
    public int level;

    private void Start()
    {
        CanSelected();
    }

    public void CanSelected()
    {
        if (level == PlayerManager.Instance.curLevel)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

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

    public void TransToTroubleMakerKingBattle()
    {
        SceneController.Instance.TransitionToBattleScene(StageManager.Instance.AllStage[2]);
    }

    public void TransToRandomLV1Battle()
    {
        SceneController.Instance.TransitionToRandomStage(1);
    }

    public void TransToRandomLV2Battle()
    {
        SceneController.Instance.TransitionToRandomStage(2);
    }

    public void TransToRandomLV3Battle()
    {
        SceneController.Instance.TransitionToRandomStage(3);
    }

    public void GoToShop()
    {
        SceneController.Instance.TransitionToShopScene();
    }
}
