using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("��ҵ�״̬��")]
    //Player��Ѫ����������Ѫ�������ı���Buff��������
    public Slider playerHealthSlider;
    public Text playerHealthText;
    public GameObject playerBuffHolder;
    public GameObject playerActHolder;

    [Header("���˵�״̬��")]
    //ͬ�ϣ�ֻ��Enemy��
    public Slider enemyHealthSlider;
    public Text enemyHealthText;
    public GameObject enemyBuffHolder;
    public GameObject enemyActHolder;

    [Header("Buff��Act��Ԥ�����б�")]
    [Tooltip("���е�BuffԤ����")]
    public GameObject[] AllBuffs;
    [Tooltip("���е�ActԤ����")]
    public GameObject[] AllActs;

    [Header("���")]
    public Tooltip tooltip;

    public void UpdateUI()
    {
        Debug.Log("����UI");
        //����Player��ص�UI
        //����Player��Ѫ����ʾ
        UpdatePlayerHealthUI();
        //����Player��Buff��ʾ
        UpdatePlayerBuffUI();

        //TODO: ����Enemy��ص�UI
        UpdateEnemyHealthUI();
        UpdateEnemyBuffUI();
        UpdateEnemyActUI();
    }

    /// <summary>
    /// ����Player��Ѫ����ʾ
    /// </summary>
    private void UpdatePlayerHealthUI()
    {
        playerHealthSlider.value = (float)PlayerManager.Instance.currentHealth / (float)PlayerManager.Instance.maxHealth;
        playerHealthText.text = PlayerManager.Instance.currentHealth + "/" + PlayerManager.Instance.maxHealth;
    }

    /// <summary>
    /// ����Player��Buff��ʾ
    /// </summary>
    private void UpdatePlayerBuffUI()
    {
        if (PlayerManager.Instance.buffShield > 0)
        {
            //������ѯplayerBuffHolder���Ƿ��Ѿ���Shield��Buff��־
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_Shield");
            if (buffObj != null)//���ҵ���Ҳ����˵��ǰ�Ѿ������ɸ�buff���壬�͸���������ʾ����
            {
                buffObj.GetComponent<Buff>().numText.text = PlayerManager.Instance.buffShield.ToString();
            }else//��û���ҵ���Ҳ����˵��ǰû�����ɸ�buff���壬������һ������ֵ�޸���ʾ����
            {
                Buff b = Instantiate(AllBuffs[0], playerBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = PlayerManager.Instance.buffShield.ToString();
                b.belong = 0;
            }
        }else//��buff����С�ڵ���0���Ͱѵ�ǰ�е�buff����ɾ����
        {
            //������ѯplayerBuffHolder���Ƿ��Ѿ���Shield��Buff��־
            Transform buffObj = FindBuffObjectFromHolder(0, "Buff_Shield");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }
    }

    private void UpdateEnemyHealthUI()
    {
        enemyHealthSlider.value = (float)EnemyManager.Instance.currentEnemy.currentHealth / (float)EnemyManager.Instance.currentEnemy.maxHealth;
        enemyHealthText.text = EnemyManager.Instance.currentEnemy.currentHealth + "/" + EnemyManager.Instance.currentEnemy.maxHealth;
    }

    private void UpdateEnemyBuffUI()
    {
        if (EnemyManager.Instance.currentEnemy.buffShield > 0)
        {
            Transform buffObj = FindBuffObjectFromHolder(1, "Buff_Shield");
            if (buffObj != null)//���ҵ���Ҳ����˵��ǰ�Ѿ������ɸ�buff���壬�͸���������ʾ����
            {
                buffObj.GetComponent<Buff>().numText.text = EnemyManager.Instance.currentEnemy.buffShield.ToString();
            }
            else//��û���ҵ���Ҳ����˵��ǰû�����ɸ�buff���壬������һ������ֵ�޸���ʾ����
            {
                Buff b = Instantiate(AllBuffs[0], enemyBuffHolder.transform).GetComponent<Buff>();
                b.numText.text = EnemyManager.Instance.currentEnemy.buffShield.ToString();
                b.belong = 1;
            }
        }
        else//��buff����С�ڵ���0���Ͱѵ�ǰ�е�buff����ɾ����
        {
            //������ѯplayerBuffHolder���Ƿ��Ѿ���Shield��Buff��־
            Transform buffObj = FindBuffObjectFromHolder(1, "Buff_Shield");
            if (buffObj != null)
                Destroy(buffObj.gameObject);
        }
    }

    private void UpdateEnemyActUI()
    {
        if (EnemyManager.Instance.currentEnemy.actAttackNum > 0)
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_Attack");
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actAttackNum.ToString();
            }
            else
            {
                Act b = Instantiate(AllActs[0], enemyActHolder.transform).GetComponent<Act>();
                b.numText.text = EnemyManager.Instance.currentEnemy.actAttackNum.ToString();
                b.belong = 1;
            }
        }else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_Attack");
            if (actObj != null)
                Destroy(actObj.gameObject);
        }


        if (EnemyManager.Instance.currentEnemy.actArmorUpNum > 0)
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_ArmorUp");
            if (actObj != null)
            {
                actObj.GetComponent<Act>().numText.text = EnemyManager.Instance.currentEnemy.actArmorUpNum.ToString();
            }
            else
            {
                Act b = Instantiate(AllActs[1], enemyActHolder.transform).GetComponent<Act>();
                b.numText.text = EnemyManager.Instance.currentEnemy.actArmorUpNum.ToString();
                b.belong = 1;
            }
        }
        else
        {
            Transform actObj = FindBuffObjectFromHolder(3, "Act_ArmorUp");
            if (actObj != null)
                Destroy(actObj.gameObject);
        }
    }

    /// <summary>
    /// ��ָ����BuffHolder��Ѱ��ָ����buff���岢���أ���û�ҵ��ͷ���null
    /// </summary>
    /// <param name="t">0�������player��buffHolder��1����enemy�ģ�2����player��act�б�3����enemy��</param>
    /// <param name="buffName">Ҫ���ҵ�buff���֣����硰Buff_Shield��</param>
    /// <returns></returns>
    public Transform FindBuffObjectFromHolder(int t, string buffName)
    {
        if (t == 0)
        {
            foreach (Transform item in playerBuffHolder.transform)
            {
                if (item.name == buffName + "(Clone)")//��Ϊ����ʵ������Ԥ������涼���һ�������ı�ʶ�������ڲ���ʱҲҪ����
                {
                    return item;
                }
            }
            return null;
        } else if (t == 1)
        {
            foreach (Transform item in enemyBuffHolder.transform)
            {
                if (item.name == buffName + "(Clone)")
                {
                    return item;
                }
            }
            return null;
        }
        else if (t == 2)
        {
            foreach (Transform item in playerActHolder.transform)
            {
                if (item.name == buffName + "(Clone)")
                {
                    return item;
                }
            }
            return null;
        }
        else if (t == 3)
        {
            foreach (Transform item in enemyActHolder.transform)
            {
                if (item.name == buffName + "(Clone)")
                {
                    return item;
                }
            }
            return null;
        }

        Debug.LogError("��FindBuffObjectFromHolder�У�����ĵ�һ������t�����Ϲ淶������0��1����");
        return null;
    }
}
