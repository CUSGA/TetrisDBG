using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUIManager : Singleton<MapUIManager>
{
    public GameObject shopButton;
    public Image playerHealthSlider;
    public Text playerHealthText;

    private float originalSize1;
    //public int curLevel;
    public new void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(this);

        if (shopButton != null)
        {
            if ((PlayerManager.Instance.curLevel + 1) % 3 == 0)
            {
                shopButton.SetActive(true);
            }
            else
            {
                shopButton.SetActive(false);
            }
        }
    }

    private void Start()
    {
        originalSize1 = playerHealthSlider.rectTransform.rect.width;

        playerHealthSlider.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize1 * (float)PlayerManager.Instance.currentHealth / (float)PlayerManager.Instance.maxHealth);
        playerHealthText.text = PlayerManager.Instance.currentHealth + " / " + PlayerManager.Instance.maxHealth;
    }
}
