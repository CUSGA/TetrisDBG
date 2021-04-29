using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        BattleManager.Instance.isGamePause = false;
        BattleManager.Instance.CreateNewTetromino();
        this.gameObject.SetActive(false);
    }
}
