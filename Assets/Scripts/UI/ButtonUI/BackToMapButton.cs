using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMapButton : MonoBehaviour
{
    public void BackToMap()
    {
        BattleManager.Instance.isGameOver = false;
        SceneController.Instance.TransitionToMapScene();
    }

    public void FromShopBackToMap()
    {
        SceneController.Instance.TransitionToMapScene();
        PlayerManager.Instance.curLevel += 1;
    }
}
