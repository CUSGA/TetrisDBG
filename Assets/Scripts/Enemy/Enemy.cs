using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//����Enemy�ĸ��࣬��������Enemy�����ݡ���Buff��Action�����ܹ�����
public class Enemy : MonoBehaviour
{
    public Sprite img;
    public string enemyName;//��Ϊ��GameObject��name��ͻ�ˣ����Ըĸ���ֵ������
    public int maxHealth;
    public int currentHealth;

    [Header("Buff�б�")]
    #region Buff�б�BuffList

    public int buffShield = 0;

    #endregion

    [Header("Act�б�")]
    #region Act�б�ActList

    //��ΪAttack�����Ƚ����⣬��ͬ���˻����Լ����صĹ������࣬���Զ�һ������������
    public int actAttack = 0;
    public float actAttackTime = 0;//�ù�����������ʱ�䣬�������0����Ϊ0�Ļ���Ĭ�ϸ�Ϊ5

    public int actArmorUp = 0;

    #endregion

    protected void Start()
    {
        //TODO: Ѫ������ÿ�ο�ս�������������õ�Ȩ��֮�ơ�
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Enemy������
    /// </summary>
    /// <param name="dmg">���������˺���</param>
    public void BeAttack(int dmg)
    {
        Debug.Log("�����ܵ�������" + dmg + "��");
        if (dmg <= buffShield)
        {
            buffShield -= dmg;
        }
        else
        {
            int rdmg = dmg - buffShield;
            buffShield = 0;
            currentHealth -= rdmg;
            if (currentHealth <= 0)
            {
                //TODO: GAME OVER
                currentHealth = 0;
                Debug.LogWarning("WIN");
            }
        }

        //����UI��ʾ
        UIManager.Instance.UpdateUI();
    }
}
