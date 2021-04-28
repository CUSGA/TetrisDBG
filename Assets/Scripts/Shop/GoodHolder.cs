using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GoodHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

        //GetComponent<Button>().interactable = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShopUIManager.Instance.tooltip.gameObject.SetActive(true);
        ShopUIManager.Instance.tooltip.SetupTooltip(good.GetComponent<Cube>().cubeData.cubeName, good.GetComponent<Cube>().cubeData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShopUIManager.Instance.tooltip.gameObject.SetActive(false);
    }
}
