using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����������һϵ�����Player�����ݣ�����Ѫ�������ܡ��쳣״̬�����顢���ɶ�ġ�
public class PlayerManager : Singleton<PlayerManager>
{
    public int maxHealth = 100;
    public int currentHealth;

    //TODO: �������Ӧ�øĳ�List����
    [Tooltip("��ǰ�ܹ��ٻ�����������Cube���ͣ�Ҳ������ҵĿ���")]
    public List<GameObject> Deck = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> tempDeck = new List<GameObject>();
    //public GameObject[] Deck;

    [Header("Buff�б�")]
    #region Buff�б� BuffList

    public int buffShield = 0;

    public int buffShieldMultiplyChip = 0;
    public int buffShieldMultiply = 0;

    public int buffAttackChip = 0;

    #endregion

    [Header("Act�б�")]
    #region Act�б�ActList

    //��ΪAttack�����Ƚ����⣬��ͬ���˻����Լ����صĹ������࣬���Զ�һ������������
    public int actAttackNum = 0;
    public float actAttackTime = 0;//�ù�����������ʱ�䣬�������0����Ϊ0�Ļ���Ĭ�ϸ�Ϊ5

    public int actArmorUpNum = 0;
    public float actArmorUpTime = 0;

    #endregion

    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        //TODO: Ѫ������ÿ�ο�ս�������������õ�Ȩ��֮�ơ�
        currentHealth = maxHealth;

        ResetTempDeck();
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

    /// <summary>
    /// ��������Buff��Act
    /// </summary>
    public void ResetState()
    {
        buffShield = 0;

        actAttackNum = 0;
        actAttackTime = 0;
        actArmorUpNum = 0;
        actArmorUpTime = 0;
    }

    /// <summary>
    /// ����ʱ����tempDeck��ԭ����ҿ���Deck������
    /// </summary>
    public void ResetTempDeck()
    {
        tempDeck.Clear();
        foreach (GameObject item in Deck)
        {
            tempDeck.Add(item);
        }
    }
}
