using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text nameText;
    public Text infoText;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetupTooltip(string name, string info)
    {
        nameText.text = name;
        infoText.text = info;
    }

    private void OnEnable()
    {
        //ÿ��tooltip����ʱ���л�һ�����꣬��Ȼÿ�����ɻ�����˸��
        UpdatePosition();
    }

    private void Update()
    {
        UpdatePosition();
    }

    //׷������λ��
    public void UpdatePosition()
    {
        Vector3 mousePos = Input.mousePosition;//��ȡ��ǰ�������
        Debug.Log("���λ��: " + mousePos);
        Debug.Log("Tooltipλ��: " + transform.position);

        //��ȡTooltip���ĸ���������
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        //��ȡtooltip�Ŀ�͸�
        float width = corners[3].x - corners[0].x;
        float height = corners[1].y - corners[0].y;

        //�����λ�ù��ͣ�tooltip��Ҫ����������Ϸ����ⳬ����Ļ����������if����һ����˼
        if (mousePos.y < height)
        {
            rectTransform.position = mousePos + Vector3.up * height * 0.6f;
        }else
        {
            rectTransform.position = mousePos + Vector3.down * height * 0.6f;
        }

        if (!(mousePos.x > width / 2 && (Screen.width - mousePos.x) > width / 2))
        {
            if (Screen.width - mousePos.x > width)
            {
                rectTransform.position = mousePos + Vector3.right * width * 0.6f;
            }
            else
            {
                rectTransform.position = mousePos + Vector3.left * width * 0.6f;
            }
        }
    }
}

