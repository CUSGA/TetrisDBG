using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                if (FindObjectOfType<T>(true))
                    _instance = FindObjectOfType<T>(true);
                else
                {
                    Debug.LogWarning("����" + typeof(T).ToString() +  "ʱ�����ã�����������һ��");
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                    obj.name = typeof(T).ToString();
                }
            }
            return _instance;
        }
    }
}

