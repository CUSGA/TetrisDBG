using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHomeButton : MonoBehaviour
{
    public void TransToHome()
    {
        //BattleManager.Instance.isGamePause = false;
        PlayerManager.Instance.currentHealth = PlayerManager.Instance.maxHealth;
        SceneController.Instance.TransitionToHomeScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
