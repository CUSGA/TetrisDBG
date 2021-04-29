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

    //�����Act��Buff�б���ʵʱ�ģ�Ҳ����˵��������Ϸ�Ľ����ܵ�ĳЩЧ��Ӱ����ı�ġ�
    //�ڸ��Ե�Enemy������洢�����Ǹ�Enemy�ĳ�ʼ���ݡ�
    [Header("��ǰ��Buff�б������ã������޸ġ�")]
    #region Buff�б�BuffList

    public int buffShieldNum = 0;

    public int buffPoisonNum = 0;

    #endregion

    [Header("��ǰ��Act�б������ã������޸ġ�")]
    #region Act�б�ActList

    //��ΪAttack�����Ƚ����⣬��ͬ���˻����Լ����صĹ������࣬���Զ�һ������������
    public int actAttackNum = 0;
    public float actAttackTime = 0;//�ù�����������ʱ�䣬�������0����Ϊ0�Ļ���Ĭ�ϸ�Ϊ5

    public int actArmorUpNum = 0;
    public float actArmorUpTime = 0;

    public int actAirRaidNum = 0;
    public int actAirRaidTime = 0;

    public int actTroubleMakerKingNum = 0;
    public int actTroubleIncreaseNum = 0;

    public int actCallOfDemonNum = 0;
    public int actCallOfDemonTime = 0;

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
        if (dmg <= buffShieldNum)
        {
            buffShieldNum -= dmg;
        }
        else
        {
            int rdmg = dmg - buffShieldNum;
            buffShieldNum = 0;
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
