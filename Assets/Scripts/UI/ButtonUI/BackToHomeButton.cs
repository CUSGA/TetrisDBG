using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHomeButton : MonoBehaviour
{
    public void TransToHome()
    {
        BattleManager.Instance.isGameOver = false;
        SceneController.Instance.TransitionToHomeScene();
    }
}
