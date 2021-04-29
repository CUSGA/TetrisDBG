using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeButton : MonoBehaviour
{
    public void GoToHome()
    {
        SceneController.Instance.TransitionToHomeScene();
    }

    public void GoToMap()
    {
        SceneController.Instance.TransitionToMapScene();
    }

    public void GoToMap_Test()
    {
        SceneController.Instance.TransitionToMap_TestScene();
    }

    public void GoToShop()
    {
        SceneController.Instance.TransitionToShopScene();
    }
}
