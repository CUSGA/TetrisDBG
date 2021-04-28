using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckCube : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text numText;
    public Image cubeImage;
    Cube currentCube;

    public void SetCube(GameObject cube)
    {
        currentCube = cube.GetComponent<Cube>();
        cubeImage.sprite = currentCube.cubeData.cubeIcon;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<DeckExplorer>().deckExplorerTooltip.SetActive(true);
        GetComponentInParent<DeckExplorer>().deckExplorerTooltip.GetComponent<Tooltip>().SetupTooltip(currentCube.cubeData.cubeName, currentCube.cubeData.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInParent<DeckExplorer>().deckExplorerTooltip.SetActive(false);
    }
}
