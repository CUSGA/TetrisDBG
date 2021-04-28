using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHomeButton : MonoBehaviour
{
    public void TransToHome()
    {
        SceneController.Instance.TransitionToHomeScene();
    }
}
