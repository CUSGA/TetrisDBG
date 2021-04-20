using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����������һϵ�����Player�����ݣ�����Ѫ�������ܡ��쳣״̬�����顢���ɶ�ġ�
public class PlayerManager : Singleton<PlayerManager>
{
    public int maxHealth = 100;
    public int currentHealth;

    [Tooltip("��ǰ�ܹ��ٻ�����������Cube���ͣ�Ҳ������ҵĿ���")]
    public GameObject[] Deck;

    [Header("Buff�б�")]
    #region Buff�б� BuffList

    public int buffShield = 0;

    #endregion

    [Header("Act�б�")]
    #region Act�б�ActList

    //��ΪAttack�����Ƚ����⣬��ͬ���˻����Լ����صĹ������࣬���Զ�һ������������
    public int actAttack = 0;
    public int actAttackTime = 0;//�ù�����������ʱ�䣬�������0����Ϊ0�Ļ���Ĭ�ϸ�Ϊ5

    public int actArmorUp = 0;

    #endregion

    private void Start()
    {
        //TODO: Ѫ������ÿ�ο�ս�������������õ�Ȩ��֮�ơ�
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Player������
    /// </summary>
    /// <param name="dmg">���������˺���</param>
    public void BeAttack(int dmg)
    {
        //����Buff�����绤�ܣ����˵ȣ�Ȼ�����Ѫ��
        if (dmg <= buffShield)
        {
            buffShield -= dmg;
        }else
        {
            int rdmg = dmg - buffShield;
            buffShield = 0;
            currentHealth -= rdmg;
            if (currentHealth <= 0)
            {
                //TODO: GAME OVER
                currentHealth = 0;
                Debug.LogWarning("GAME OVER");
            }
        }

        //����UI��ʾ
        UIManager.Instance.UpdateUI();
    }
}
