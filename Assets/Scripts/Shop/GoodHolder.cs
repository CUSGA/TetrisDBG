using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodHolder : MonoBehaviour
{
    public Image goodImage;
    public GameObject good;

    private void Start()
    {
        good = ShopManager.Instance.GetRandomGood();
        goodImage.sprite = good.GetComponent<Cube>().cubeData.cubeIcon;
    }

    public void BuyGood()
    {
        if (good != null)
        {
            PlayerManager.Instance.Deck.Add(good);
            PlayerManager.Instance.ResetTempDeck();
        }
        else
        {
            Debug.Log("ÉÌÆ·Îª¿Õ");
        }

        GetComponent<Button>().interactable = false;
    }
}
